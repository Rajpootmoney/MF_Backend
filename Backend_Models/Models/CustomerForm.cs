using Backend_Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF_Models.Models
{
    public class CustomerForm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int GenderTypeId { get; set; }
        public GenderType GenderType { get; set; }
        [ForeignKey("GenderTypeId")]
        public int CountryId { get; set; }
        public Country Country { get; set; }
        [ForeignKey("CountryId")]
        public bool WantNewsFeed { get; set; }
    }
}
