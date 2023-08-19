using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Product.Api.ViewModels;
using Product.Domain.IServices;
using MediatR;

namespace Product.Api.Application.Queries.Users;

public class GetUserRolesQueryHandler : IRequestHandler<GetUserRolesQuery, IEnumerable<AuthViewModel>>
{
    private readonly IQueryExecutor queryExecutor;

    public GetUserRolesQueryHandler(
        IQueryExecutor queryExecutor
    )
    {
        this.queryExecutor = queryExecutor;
    }
    
    public Task<IEnumerable<AuthViewModel>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
    {
        return queryExecutor.QueryAsync<AuthViewModel>(
            $"select r.id, r.name from userroles as ur left join roles as r on ur.roleid = r.id where ur.userid ={request.UserId}");
        
    }
}