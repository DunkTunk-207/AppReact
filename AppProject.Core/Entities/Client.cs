using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppProject.Infrastructure.Entities
{
    public class Client
    {
        [Key]
        public Guid Id { get; private set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; private set; }
        
        [Required]
        [StringLength(50)]
        public string Contact { get; private set; }
        
        public Guid? ProjectId { get; private set; }
        public virtual ICollection<Project> Projects { get; private set; }

        public Client(string name, string contact)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Client name cannot be empty");
            if (string.IsNullOrEmpty(contact))
                throw new ArgumentException("Contact cannot be empty");

            Id = Guid.NewGuid();
            Name = name;
            Contact = contact;
            Projects = new HashSet<Project>();
        }

        public void Update(string name, string contact)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Client name cannot be empty");
            if (string.IsNullOrEmpty(contact))
                throw new ArgumentException("Contact cannot be empty");

            Name = name;
            Contact = contact;
        }
    }
}