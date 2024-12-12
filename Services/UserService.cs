using Entities;
using Repository;
using ServiceInterfaces;
using ViewModels;

namespace Services;
public class UserService : IUserService
{
    private IUserRepository Repository;
    public UserService(IUserRepository repository)
    {
        Repository = repository;
    }

    public string User(UserEntity request)
    {
        return Repository.User(request);
    }
    public List<SystemListEntity> usageList()
    {
        return Repository.usageList();
    }
    public List<UserEntity> userList()
    {
        return Repository.userList();
    }

}