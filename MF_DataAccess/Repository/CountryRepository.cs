using Backend_Models.Models;
using MF_DataAccess.Data;
using MF_DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF_DataAccess.Repository
{

    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;
        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddCountry(Country country)
        {
            _context.Countries.Add(country);
            return Save();
        }

        public bool DeleteCountry(Country country)
        {
            _context.Countries.Remove(country);
            return Save();
        }

        public ICollection<Country> GetContries()
        {
            return _context.Countries.ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() == 1 ? true : false;
        }
    }
}
