using System.Collections.Generic;
using Entities;
using ViewModels;

namespace Repository
{
    /** リポジトリー */
    public interface ILoginAuthenticationRepository
    {
        /// <summary>
        /// </summary>
        string authenticationCheck(LoginAuthenticationEntity request);

    }
}
