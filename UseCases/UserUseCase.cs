

using Entities;
using ServiceInterfaces;
using UseCaseInterfaces;
using Utils;
using ViewModels;

namespace UseCases;

public class UserUseCase : IUserUseCase
{
    private IUserService Service;

    public UserUseCase(IUserService service)
    {
        Service = service;
    }

    public string execute(UserDto request)
    {
        var data1 = BeanUtil.Copy<UserDto, UserEntity>(request);
        var data = Service.User(data1);
        return data;
    }

    public List<SystemListEntity> usageList()
    {
        var data = Service.usageList();
        return data;
    }
    public List<UserEntity> userList()
    {
        var data = Service.userList();
        return data;
    }
    public string userBy(UserByDto request)
    {
        var data1 = BeanUtil.Copy<UserByDto, UsedByEntity>(request);
        var data = Service.userBy(data1);
        return data;
    }
}