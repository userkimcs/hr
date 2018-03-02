using HR.Data.Entities;
using System;
using System.Collections.Generic;


namespace HR.Core.Contracts
{
    public interface ILocationService
    {
        List<City> GetCities();
        List<District> GetDistrictsByCity(long cityId);
        List<Town> GetTownsByDistrict(long districtId);

        City GetCity(long id);
        District GetDistrict(long id);
        Town GetTown(long id);
    }
}
