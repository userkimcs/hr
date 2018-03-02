

using HR.Data.Entities;
using System;
namespace HR.Core.Helpers
{
    public class EntityFactory
    {
        public static Employee CreateEmployee(string FirstName, string LastName, string IdCard, string Email, 
            string PhoneNumber, string City, string District, string Town, DateTime BirthDay, DateTime HireDate, 
            string Sex, Department d)
        {
            // Gia su la nam 
            Sex sexValue =  Data.Entities.Sex.Male; // For male
            if (sexValue == Data.Entities.Sex.Male)
            {
                sexValue = Data.Entities.Sex.Male;
            }
            else
            {
                sexValue = Data.Entities.Sex.Female;
            }
            return new Employee
            {
                FirstName = FirstName,
                LastName = LastName,
                IdCard = IdCard,
                Email = Email,
                PhoneNumber = PhoneNumber,
                Address = City + ", " + District + ", " + Town,
                Sex = sexValue, 
                BirthDay = BirthDay, 
                HireDate = HireDate,
                Department = d,
                Position = Position.Staff,
            };
        }
    }
}
