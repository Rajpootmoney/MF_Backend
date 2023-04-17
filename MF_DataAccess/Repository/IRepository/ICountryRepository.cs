using Backend_Models.Models;
using MF_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF_DataAccess.Repository.IRepository
{
    public interface ICountryRepository
    {
        ICollection<Country> GetContries();
        bool AddCountry(Country country);
        bool DeleteCountry(Country country);
        bool Save();
    }
}
