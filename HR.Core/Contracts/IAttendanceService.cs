

using HR.Data.Entities;
using System.Collections.Generic;
namespace HR.Core.Contracts
{
    public interface IAttendanceService
    {
        void MorningRollUp(long empId);
        void AfternoonRollUp(long empId);
        bool IsMorningRollUp(long empId);
        bool IsAfternoonRollUp(long empId);

        List<Attendance> EmployeeMonthlyRollUp(int month, long empId);
        List<Attendance> DepartmentMonthlyRollUp(int month, long depId);
    }
}
