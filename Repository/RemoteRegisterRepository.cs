
using System.Text;
using Context;
using DatabaseModels;
using Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Repository;
using ViewModels;

#nullable disable
namespace Repository;

public class RemoteRegisterRepository : IRemoteRegisterRepository
{
    private readonly ApiDbContext Context;
    public RemoteRegisterRepository(ApiDbContext context)
    {
        Context = context;
    }

    public string executeRemoteRegister(RemoteRegisterEntity request)
    {
        var status = "";
        if(request.mode == "register"){
            var existingId = Context.SystemLists.FirstOrDefault(u => u.RemoteId == request.remoteID);
            if (existingId != null)
            {
                return  "RemoteId is Already Registered";
            }
            var tableInfo = new SystemList()
            {
                RemoteId = request.remoteID,
                RemoteName = request.remoteUserName,
            };
            Context.SystemLists.Add(tableInfo);
            Context.SaveChanges();
           status =  "Remote System Registered Successfully";
        } else {
            var existingId = Context.SystemLists.FirstOrDefault(u => u.Id == request.id);
            if (existingId != null)
            {
                existingId.RemoteId = request.remoteID;
                existingId.RemoteName = request.remoteUserName;
                Context.SaveChanges();
                status = "Remote System User Name Updated Successfully";
            }
        }

        return status;
    }
}

