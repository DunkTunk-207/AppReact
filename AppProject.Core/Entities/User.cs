using System;
using System.ComponentModel.DataAnnotations;

namespace AppProject.Infrastructure.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; private set; }
        
        [Required]
        [StringLength(50)]
        public string FirstName { get; private set; }
        
        [Required]
        [StringLength(50)]
        public string LastName { get; private set; }
        
        [Required]
        public string Role { get; private set; }

        public User(string firstName, string lastName, string role)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentException("First name cannot be empty");
            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentException("Last name cannot be empty");
            if (string.IsNullOrEmpty(role))
                throw new ArgumentException("Role cannot be empty");

            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Role = role;
        }

        public void Update(string firstName, string lastName, string role)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentException("First name cannot be empty");
            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentException("Last name cannot be empty");
            if (string.IsNullOrEmpty(role))
                throw new ArgumentException("Role cannot be empty");

            FirstName = firstName;
            LastName = lastName;
            Role = role;
        }
    }
}