using Entities;
using ServiceInterfaces;
using UseCaseInterfaces;
using Utils;
using ViewModels;

namespace UseCases;
    /// <summary>
    /// リモートデスクトップIDと名前を登録
    /// </summary>
    public class RemoteRegisterUseCase : IRemoteRegisterUseCase
    {

        private IRemoteRegisterService RemoteRegisterService;

        public RemoteRegisterUseCase(IRemoteRegisterService remoteRegisterService)
        {
            RemoteRegisterService = remoteRegisterService;
        }
        public string executeRegister(RemoteRegisterDto request)
        {
            var data1 = BeanUtil.Copy<RemoteRegisterDto, RemoteRegisterEntity>(request);
            var data = RemoteRegisterService.executeRemoteRegister(data1);
            return data;
        }
    }
