using System.Threading.Tasks;
using AutoMapper;
using EventBus.Abstractions;
using Grpc.Core;
using Product.Api.Application.Queries.Users;
using ProductGrpcServer;

namespace Product.Api.Grpc;

public class AuthGrpcService : ProductGrpc.ProductGrpcBase
{
    private readonly IMapper mapper;
    private readonly IEventBus eventBus;

    public AuthGrpcService(
        IMapper mapper,
        IEventBus eventBus
    )
    {
        this.mapper = mapper;
        this.eventBus = eventBus;
    }

    public override async Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest request, ServerCallContext context)
    {
        var token = await eventBus.SendMediator(new RefreshTokenQuery { RefreshToken = request.RefreshToken});
        return mapper.Map<RefreshTokenResponse>(token);
    }
}