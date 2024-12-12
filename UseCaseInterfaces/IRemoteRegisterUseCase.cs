using ViewModels;

namespace UseCaseInterfaces;
    
/// <summary>
/// リモートデスクトップIDと名前を登録
/// </summary>
public interface IRemoteRegisterUseCase
{
    public string executeRegister(RemoteRegisterDto request);
}