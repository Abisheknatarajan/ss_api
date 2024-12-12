using Entities;
using Repository;
using ServiceInterfaces;
using ViewModels;

namespace Services;
public class RemoteRegisterService : IRemoteRegisterService
{

    private IRemoteRegisterRepository Repository;
    
    public RemoteRegisterService(IRemoteRegisterRepository repository)
    {
        Repository = repository;
    }    
    
    public string executeRemoteRegister(RemoteRegisterEntity request)
    {
        return Repository.executeRemoteRegister(request);
    }
}