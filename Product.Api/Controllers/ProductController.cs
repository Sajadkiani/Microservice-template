using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EventBus.Abstractions;
using Product.Api.Application.Queries.Users;
using Product.Api.Infrastructure.Services;
using Product.Api.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.Api.Application.Commands.Products;

namespace Product.Api.Controllers
{
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IEventBus eventBus;

        public ProductController(
            IMapper mapper,
            ICurrentUser currentUser,
            IEventBus eventBus
        )
        {
            this.mapper = mapper;
            this.eventBus = eventBus;
        }

        [HttpPost]
        [Authorize]
        public async Task AddUserAsync([FromBody] ProductViewModel.AddProductInput input)
        {
            var command = mapper.Map<AddProductCommand>(input);
            await eventBus.SendMediator(command);
        }
    }
}