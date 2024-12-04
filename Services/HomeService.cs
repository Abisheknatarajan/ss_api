using Entities;
using Repository;
using ServiceInterfaces;
using ViewModels;

namespace Services;
public class HomeService : IHomeService
{
    private IHomeRepository Repository;
    public HomeService(IHomeRepository repository)
    {
        Repository = repository;
    }

    public string Home(string name)
    {
        return Repository.Home(name);
    }

}