using System.Collections.Generic;
using Entities;
using ViewModels;

namespace Repository
{
    /** リポジトリー */
    public interface IRemoteRegisterRepository
    {
        /// <summary>
        /// </summary>
        string executeRemoteRegister(RemoteRegisterEntity request);

    }
}
