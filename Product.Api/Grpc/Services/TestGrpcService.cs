using System;
using System.Threading.Tasks;
using AutoMapper;
using EventBus.Abstractions;
using Grpc.Core;
using ProductGrpcServer;

namespace Product.Api.Grpc.Services;

public class TestGrpcService : TestGrpc.TestGrpcBase
{
    private readonly IMapper mapper;
    private readonly IEventBus eventBus;

    public TestGrpcService(
        IMapper mapper,
        IEventBus eventBus
    )
    {
        this.mapper = mapper;
        this.eventBus = eventBus;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        Console.WriteLine("this the first grpc");
        return base.SayHello(request, context);
    }
}