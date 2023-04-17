using Backend_Models.Models;
using MF_Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MF_Models.Models.CustomerForm;

namespace MF_DataAccess.DTOs
{
    public class CustomerFormDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int GenderTypeId { get; set; }
        public int CountryId { get; set; }
        //public Country Country { get; set; }
        //[ForeignKey("CountryId")]
        public bool WantNewsFeed { get; set; }
    }
}
