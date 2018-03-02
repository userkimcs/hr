using System.Collections.Generic;
using HR.Core.Contracts;
using HR.Data.Entities;
using HR.Data.Contracts;
namespace HR.Core.Services
{
    public class LocationService : ILocationService
    {
        private IRepository<City> _cityRepository;
        private IRepository<District> _districtRepository;
        private IRepository<Town> __townRepository;
        public LocationService(IRepository<City> _cityRepository, 
            IRepository<District> _districtRepository, IRepository<Town> __townRepository)
        {
            this.__townRepository = __townRepository;
            this._cityRepository = _cityRepository;
            this._districtRepository = _districtRepository;
        }

        public List<City> GetCities()
        {
            return _cityRepository.GetAll();
        }

        public List<District> GetDistrictsByCity(long cityId)
        {
            return _districtRepository.Search(p => p.CityId == cityId);
        }

        public List<Town> GetTownsByDistrict(long districtId)
        {
            return __townRepository.Search(p => p.DistrictId == districtId);
        }


        public City GetCity(long id)
        {
            return _cityRepository.GetById(id);
        }

        public District GetDistrict(long id)
        {
            return _districtRepository.GetById(id);
        }

        public Town GetTown(long id)
        {
            return __townRepository.GetById(id);
        }
    }
}
