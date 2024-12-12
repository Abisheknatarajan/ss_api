
using Entities;
using ViewModels;

namespace ServiceInterfaces
{
    public interface IUserService
    {
        string User(UserEntity request);
        public List<SystemListEntity> usageList();
        public List<UserEntity> userList();
    }
}