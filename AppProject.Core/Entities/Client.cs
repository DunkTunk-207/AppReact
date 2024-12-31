using System.ComponentModel.DataAnnotations;

namespace AppProject.Infrastructure.Entities
{
    public class Client
    {
        [Key]
        public Guid Id {get; set;}
        [Required]
        public string Name {get; set;}
        [Required]
        public string Contact { get; set; }
        public Guid? ProjectId {get; set;}
        public virtual ICollection<Project> Projects {get; set;}
    }
}
