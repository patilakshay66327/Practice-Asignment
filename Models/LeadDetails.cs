using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeAssignment.Models
{
    public class LeadDetails
    {
        [Key]
        public int leadId { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(100)")]
        public String leadFirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public String leadLastName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public String leadAddress { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public String leadEmail { get; set; }
    }
}
