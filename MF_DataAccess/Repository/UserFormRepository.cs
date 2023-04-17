using Backend_Models.Models;
using MF_DataAccess.Data;
using MF_DataAccess.Repository.IRepository;
using MF_Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF_DataAccess.Repository
{

    public class UserFormRepository : IUserFormRepositoy
    {
        private readonly ApplicationDbContext _context;
        public UserFormRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool AddCustomer(CustomerForm customerForm)
        {
            _context.CustomerForms.Add(customerForm);
            return Save();
        }

        public bool CustomerExists(int customerId)
        {
            return _context.CustomerForms.Any(x => x.Id == customerId);
        }

        public bool DeleteCustomer(CustomerForm customerForm)
        {
            _context.CustomerForms.Remove(customerForm);
            return Save();
        }

        public CustomerForm GetCustomerForm(int customerId)
        {
            return _context.CustomerForms.Find(customerId);
        }

        public ICollection<CustomerForm> GetCustomerForms()
        {
            return _context.CustomerForms.Include(nameof(Country)).Include(nameof(GenderType)).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() == 1 ? true : false;
        }



        public bool UpdateCustomer(CustomerForm customerForm)
        {
            _context.CustomerForms.Update(customerForm);
            return Save();
        }
    }
}
