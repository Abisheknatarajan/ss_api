using System.Collections.Generic;

using Entities;

namespace ServiceInterfaces;

    /// <summary>
    /// サービスインターフェース
    /// </summary>
    public interface ILoginAuthenticationService
    {
        string executeAuthentication(LoginAuthenticationEntity request);
    }
