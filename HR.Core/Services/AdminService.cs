using HR.Core.Contracts;
using HR.Core.Helpers;
using HR.Data;
using HR.Data.Contracts;
using HR.Data.Entities;
using HR.Data.Repository;
using System.Collections.Generic;


namespace HR.Core.Services
{
    public class AdminService : IAdminService
    {
        private IRepository<Admin> _adminRepository;
        public AdminService(IRepository<Admin> _repos)
        {
            this._adminRepository = _repos; // Injection 
        }

        // Login into system 
        // Return LOGIN_RESULT (Successfull or ....)
        // 
        public LOGIN_RESULT Login(string username, string password)
        {
            var result = this._adminRepository.Search(t => t.UserName == username && t.Password == password);
            if (result.Count < 1) 
            {
                return LOGIN_RESULT.ERROR; 
            }
            else
            {
                return LOGIN_RESULT.SUCCESSFULL;
            }
        }

    }
}
