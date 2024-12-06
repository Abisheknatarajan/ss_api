using Entities;
using ServiceInterfaces;
using UseCaseInterfaces;
using Utils;
using ViewModels;

namespace UseCases;
    /// <summary>
    /// ログイン認証のユースケース
    /// </summary>
    public class LoginAuthenticationUseCase : ILoginAuthenticationUseCase
    {

        private ILoginAuthenticationService LoginAuthenticationService;

        public LoginAuthenticationUseCase(ILoginAuthenticationService loginAuthenticationService)
        {
            LoginAuthenticationService = loginAuthenticationService;
        }
        public string executeAuthentication(LoginAuthenticationDto request)
        {
            var data1 = BeanUtil.Copy<LoginAuthenticationDto, LoginAuthenticationEntity>(request);
            var data = LoginAuthenticationService.executeAuthentication(data1);
            return data;
        }
    }
