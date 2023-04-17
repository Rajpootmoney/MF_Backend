using Backend_Models.Models;
using MF_DataAccess.Data;
using MF_DataAccess.Repository.IRepository;
using MF_Models.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF_DataAccess.Repository
{
    public class GenderTypeRepository : IGenderTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public GenderTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddGender(GenderType gender)
        {
            _context.GenderType.Add(gender);
            return Save();
        }

        public bool DeleteGender(GenderType gender)
        {
            _context.GenderType.Remove(gender);
            return Save();
        }

        public ICollection<GenderType> GetGenderType()
        {
            return _context.GenderType.ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() == 1 ? true : false;
        }
    }
}
