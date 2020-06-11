﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bsa2er_MVC.Models
{
    public class Instructor
    {
        [Key]
        public int Ins_Id { get; set; }
        

    
        public virtual ICollection<Program> Programs { get; set; }
        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}