using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class LeaveMasterEntity
    {
        ////public int LeaveId { get; set; }
        ////public int EmpId { get; set; }
        ////public Nullable<decimal> LeaveAllocated { get; set; }
        ////public Nullable<int> LeaveApplied { get; set; }
        ////public Nullable<int> LeaveUsed { get; set; }
        ////public Nullable<decimal> Leaveforwarded { get; set; }
        ////public Nullable<int> CompOff { get; set; }
        ////public int ApprovedBy { get; set; }

        ////public virtual Employee_Master Employee_Master { get; set; }
        public int LeaveId { get; set; }
        public string LeaveDetails { get; set; }
    }
}
