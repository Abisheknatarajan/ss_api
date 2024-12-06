
using System.Text;
using Context;
using DatabaseModels;
using Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Repository;
using ViewModels;

#nullable disable
namespace Repository;

public class LoginAuthenticationRepository : ILoginAuthenticationRepository
{
    private readonly ApiDbContext Context;
    public LoginAuthenticationRepository(ApiDbContext context)
    {
        Context = context;
    }

    public string authenticationCheck(LoginAuthenticationEntity request)
    {
        var hashedPassword = HashPassword(request.password);
        var user = Context.Users.FirstOrDefault(u => u.Email == request.email && u.Password == hashedPassword);
        if(user != null){
            return "OK";
        } else {
            return "";
        }
    }
    
    private string HashPassword(string password)
    {
        using (var sha256 = System.Security.Cryptography.SHA256.Create())
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}

