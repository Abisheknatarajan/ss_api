

using Entities;
using ServiceInterfaces;
using UseCaseInterfaces;
using Utils;
using ViewModels;

namespace UseCases;

public class HomeUseCase : IHomeUseCase
{
    private IHomeService Service;

    public HomeUseCase(IHomeService service)
    {
        Service = service;
    }

    public string execute(string name)
    {
        // var data1 = BeanUtil.Copy<HomeDto, HomeEntity>(nurseDto);
        var data = Service.Home(name);
        return data;
    }

}