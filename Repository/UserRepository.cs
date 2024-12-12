
using Context;
using DatabaseModels;
using Entities;
using Repository;
using ViewModels;

#nullable disable
namespace Repository;


public class UserRepository : IUserRepository
{
    private readonly ApiDbContext Context;
    public UserRepository(ApiDbContext context)
    {
        Context = context;
    }


    public string User(UserEntity request)
    {
        var existingUser = Context.Users.FirstOrDefault(u => u.Email == request.Email);
        if (existingUser != null)
        {
            return "Email is already registered.";
        }
        var tableInfo = new User()
        {
            UserName = request.Name,
            Email = request.Email,
            Password = request.Password
        };
        Context.Users.Add(tableInfo);
        Context.SaveChanges();
        return "User registered successfully.";
    }

    public List<SystemListEntity> usageList()
    {
        var systemList = Context.SystemLists.Select
                (s => new SystemListEntity
                {
                    remoteId = s.RemoteId,
                    remoteName = s.RemoteName,
                    usedBy = s.UserBy
                }
            )
            .ToList();

        return systemList;
    }
    public List<UserEntity> userList()
    {
        var systemList = Context.Users.Select(s => new UserEntity
        {
            Name = s.UserName,
        })
            .ToList();

        return systemList;
    }
    public string userBy(UsedByEntity request)
    {
        var data = Context.SystemLists.FirstOrDefault(u => u.RemoteId == request.RemoteId);
        if (data != null)
        {
            data.UserBy = request.User;
            Context.SaveChanges();
            return "User registered successfully.";
        }
        return "User registered Unsuccessfully.";

    }
}

