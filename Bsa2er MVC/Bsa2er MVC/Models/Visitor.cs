using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bsa2er_MVC.Models
{
    public class Visitor
    {
        [Key]
        public int Id { get; set; }
        public string IpAddress { get; set; }
        public DateTime DateTimeOfVisit { get; set; }
    }
}