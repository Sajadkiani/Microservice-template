using MediatR;

namespace Product.Api.Application.Commands.Products;

public class AddProductCommand : IRequest<int>
{
    public string Name { get; }

    public AddProductCommand(string name)
    {
        Name = name;
    }
}
