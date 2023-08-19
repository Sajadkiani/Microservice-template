﻿using System.Threading;
using System.Threading.Tasks;
using EventBus.Abstractions;
using Product.Api.Infrastructure.Exceptions;
using MassTransit;
using MediatR;
using IMediator = MediatR.IMediator;

namespace Product.Api.Infrastructure.Brokers;

public class EventBus : IEventBus
{
    private readonly IPublishEndpoint publishEndpoint;
    private readonly IMediator mediator;
    private readonly ISendEndpointProvider  sendEndpoint;

    public EventBus(IPublishEndpoint publishEndpoint, IMediator mediator, ISendEndpointProvider  sendEndpoint)
    {
        this.publishEndpoint = publishEndpoint;
        this.mediator = mediator;
        this.sendEndpoint = sendEndpoint;
    }
    
    public Task<TResponse> SendMediator<TResponse>(IRequest<TResponse> command)
    {
        return mediator.Send(command);
    }

    public Task PublishMediator<TNotification>(TNotification notification)
    {
        return mediator.Publish(notification);
    }

    public Task Publish<TIntegrationEvent>(TIntegrationEvent @event) 
    {
        if (@event is null)
            throw new ApplicationException.Internal(
                new AppMessage($"notification:{nameof(@event)} is null."));
        
        return publishEndpoint.Publish(@event);
    }

    public async Task Send<TRequest>(TRequest request, CancellationToken cancellationToken = new CancellationToken())
        where TRequest : IRequest
    {
        await sendEndpoint.Send(request, cancellationToken);
    }
}