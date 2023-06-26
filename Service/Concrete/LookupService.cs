using Data.Interface;
using Domain.Entities.Lookups;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class LookupService : ILookupService
    {
        private readonly IRepository<LanguageLookup> _languagesRepository;
        private readonly IRepository<CountryLookup> _countryRepository;
        private readonly IRepository<NationalityLookup> _nationalityRepository;

        public LookupService(IRepository<LanguageLookup> languagesRepository, IRepository<CountryLookup> countryRepository, IRepository<NationalityLookup> nationalityRepository) 
        {
            _languagesRepository = languagesRepository;
            _countryRepository = countryRepository;
            _nationalityRepository = nationalityRepository;
        }
        List<CountryLookup> ILookupService.GetCountryLookups()
        {
            return _countryRepository.GetAll().ToList();
        }

        List<LanguageLookup> ILookupService.GetLanguageValues()
        {
            return _languagesRepository.GetAll().ToList();
        }

        List<NationalityLookup> ILookupService.GetNationalityLookups()
        {
            return _nationalityRepository.GetAll().ToList();
        }
    }
}
