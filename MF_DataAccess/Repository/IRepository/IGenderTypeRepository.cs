using Backend_Models.Models;
using MF_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF_DataAccess.Repository.IRepository
{
    public interface IGenderTypeRepository
    {
        ICollection<GenderType> GetGenderType();
        bool AddGender(GenderType gender);
        bool DeleteGender(GenderType gender);
        bool Save();
    }
}
