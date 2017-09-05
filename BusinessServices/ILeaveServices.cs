using BusinessEntities;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    /// <summary>
    /// Product Service Contract
    /// </summary>
    public interface ILeaveServices
    {
        LeaveMasterEntity GetLeaveById(int leaveId);
        IEnumerable<LeaveMasterEntity> GetAllLeaves();
        //int CreateLeave(Leave_Master leaveEntity);
        bool UpdateLeave(int leaveId, LeaveMasterEntity leaveEntity);
        bool DeleteLeave(int leaveId);
        int CreateLeave(LeaveMasterEntity leaveMasterEntity);
    }

}
