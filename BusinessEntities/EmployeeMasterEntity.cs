using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class EmployeeMasterEntity
    {
        public int EmpId { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<System.DateTime> EmployeeDOB { get; set; }
        public string EmpAddress1 { get; set; }
        public string EmpAddress2 { get; set; }
        public string EmpEmail { get; set; }
        public string EmpMobile { get; set; }
        public string EmpLandline { get; set; }
        public Nullable<System.DateTime> DateofJoining { get; set; }
        public string EmpPosition { get; set; }
        public string EmpRole { get; set; }


    }
}
