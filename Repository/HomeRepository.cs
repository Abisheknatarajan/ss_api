
using Context;
using DatabaseModels;
using Entities;
using Repository;

#nullable disable
namespace Repository;


public class HomeRepository : IHomeRepository
{
    private readonly ApiDbContext Context;
    public HomeRepository(ApiDbContext context)
    {
        Context = context;
    }


    public string Home(string name)
    {
        var tableInfo = new User()
        {
            UserName = name
        };
        Context.Users.Add(tableInfo);
        Context.SaveChanges();
        return "";
    }
}

