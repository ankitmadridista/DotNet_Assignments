using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 

namespace SecWebApp.Models
{
    public class Cities
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}