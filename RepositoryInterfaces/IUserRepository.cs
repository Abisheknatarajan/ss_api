using Entities;
using ViewModels;

namespace Repository;

public interface IUserRepository

{
    string User(UserEntity request);
    public List<SystemListEntity> usageList();
    public List<UserEntity> userList();

}