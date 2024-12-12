
using Entities;
using ViewModels;

namespace ServiceInterfaces
{
    public interface IUserService
    {
        string User(UserEntity request);
        string userBy(UsedByEntity request);

        public List<SystemListEntity> usageList();
        public List<UserEntity> userList();
    }
}