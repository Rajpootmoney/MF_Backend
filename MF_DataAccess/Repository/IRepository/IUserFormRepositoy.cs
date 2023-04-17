using MF_Models.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF_DataAccess.Repository.IRepository
{
    public interface IUserFormRepositoy
    {

        ICollection<CustomerForm> GetCustomerForms();
        CustomerForm GetCustomerForm(int customerId);
        bool AddCustomer(CustomerForm customerForm);
        bool CustomerExists(int customerId);
        bool UpdateCustomer(CustomerForm customerForm);
        bool DeleteCustomer(CustomerForm customerForm);
        bool Save();
    }
}
