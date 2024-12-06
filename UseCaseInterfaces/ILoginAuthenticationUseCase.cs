using ViewModels;

namespace UseCaseInterfaces;
    
/// <summary>
/// ログイン認証ユースケースインターフェース
/// </summary>
public interface ILoginAuthenticationUseCase
{
    public string executeAuthentication(LoginAuthenticationDto request);
}