using Entities;
using Repository;
using ServiceInterfaces;
using ViewModels;

namespace Services;
public class LoginAuthenticationService : ILoginAuthenticationService
{

    private ILoginAuthenticationRepository Repository;
    
    public LoginAuthenticationService(ILoginAuthenticationRepository repository)
    {
        Repository = repository;
    }    
    
    public string executeAuthentication(LoginAuthenticationEntity request)
    {
        return Repository.authenticationCheck(request);
    }
}