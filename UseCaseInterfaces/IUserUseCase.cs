using Entities;
using ViewModels;

namespace UseCaseInterfaces;

public interface IUserUseCase
{
    public string execute(UserDto request);
    public string userBy(UserByDto request);
    public List<SystemListEntity> usageList();
    public List<UserEntity> userList();

}