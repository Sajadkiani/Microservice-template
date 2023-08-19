using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Product.Api.Application.Commands.Products;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
{

    public AddProductCommandHandler(
        )
    {
    }

    public Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}