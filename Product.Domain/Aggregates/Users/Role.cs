using Product.Domain.SeedWork;

namespace Product.Domain.Aggregates.Users;

public class Role : Entity
{
    public Role(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }

    private List<UserRole> _userRoles;

    public IReadOnlyCollection<UserRole> UserRoles => _userRoles;
}