

using HR.Core.Helpers;
using HR.Data.Entities;
using System.Collections.Generic;
namespace HR.Core.Contracts
{
    public interface IAdminService
    {
        LOGIN_RESULT Login(string username, string password);
    }
}
