using System.Collections.Generic;

using Entities;

namespace ServiceInterfaces;

    /// <summary>
    /// サービスインターフェース
    /// </summary>
    public interface IRemoteRegisterService
    {
        string executeRemoteRegister(RemoteRegisterEntity request);
    }
