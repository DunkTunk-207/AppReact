using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppProject.Infrastructure.Entities
{
    public class Project
    {
        [Key]
        public Guid Id {get; set;}
        [Required]
        public string Name {get; set;}
        [Required]
        public string Manager { get; set; }
        [Required]
        public string Director { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration {get; set;}
        public string Currency {get; set;}
        public Guid ClientId {get; set;}
        [ForeignKey("ClientId")]
        public virtual Client Client {get; set;}
    }
}
