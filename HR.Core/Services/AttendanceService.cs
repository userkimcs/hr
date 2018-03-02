

using HR.Core.Contracts;
using HR.Data.Contracts;
using HR.Data.Entities;
using System;
using System.Linq;
namespace HR.Core.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IRepository<Attendance> _attendanceRepository;

        public AttendanceService(IRepository<Attendance> _attendanceRepository)
        {
            this._attendanceRepository = _attendanceRepository;
        }

        public bool IsMorningRollUp(long empId)
        {
            var atd = _attendanceRepository
                .Search(t => t.EmployeeId == empId
                            && DateTime.Now.Date == t.Day.Value.Date
                            && DateTime.Now.Month == t.Day.Value.Month
                            && DateTime.Now.Year == t.Day.Value.Year 
                            && t.Morning == true
                ).FirstOrDefault();
            return atd == null ? false : true;
        }

        public bool IsAfternoonRollUp(long empId)
        {
            var atd = _attendanceRepository
                .Search(t => t.EmployeeId == empId
                            && DateTime.Now.Date == t.Day.Value.Date
                            && DateTime.Now.Month == t.Day.Value.Month
                            && DateTime.Now.Year == t.Day.Value.Year
                            && t.Afternoon == true
                ).FirstOrDefault();
            return atd == null ? false : true;
        }

        public System.Collections.Generic.List<Data.Entities.Attendance> EmployeeMonthlyRollUp(int month, long empId)
        {
            return _attendanceRepository
                .Search(t => t.EmployeeId == empId 
                        && t.Day.Value.Month == month
                );
        }

        public System.Collections.Generic.List<Data.Entities.Attendance> DepartmentMonthlyRollUp(int month, long depId)
        {
            return _attendanceRepository
                .Search(t => t.Employee.DepartmentId == depId
                        && t.Day.Value.Month == month
                );
        }

        public void MorningRollUp(long empId)
        {
            if (IsMorningRollUp(empId) 
                || IsAfternoonRollUp(empId))
            {
                // do nothing
            }
            else
            { 
                Attendance atd = new Attendance();
                atd.Morning = true;
                atd.EmployeeId = empId;
                _attendanceRepository.Insert(atd);
            }
        }

        public void AfternoonRollUp(long empId)
        {
            var atd = _attendanceRepository
                .Search(t => t.EmployeeId == empId 
                            && DateTime.Now.Date == t.Day.Value.Date 
                            && DateTime.Now.Month == t.Day.Value.Month
                            && DateTime.Now.Year == t.Day.Value.Year
                ).FirstOrDefault();
            if (atd != null)
            {
                atd.Afternoon = true;
                _attendanceRepository.Update(atd);
            }
            else
            {
                Attendance attent = new Attendance();
                attent.EmployeeId = empId;
                attent.Afternoon = true;
                _attendanceRepository.Insert(attent);
            }
        }
    }
}
