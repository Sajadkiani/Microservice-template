namespace Product.Domain.Validations.Users;

public interface IUserBcScopeValidation
{
    bool IsExistEmail(string email);
    bool IsExistUserName(string userName);
}