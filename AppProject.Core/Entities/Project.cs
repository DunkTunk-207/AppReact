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
        public Guid Id { get; private set; }
        [Required]
        public string Name { get; private set; }
        [Required]
        public string Manager { get; private set; }
        [Required]
        public string Director { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int Duration { get; private set; }
        public string Currency { get; private set; }
        public Guid ClientId { get; private set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; private set; }

        public Project(string name, string manager, string director, DateTime startDate,
            DateTime endDate, int duration, string currency, Guid clientId)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Project name cannot be empty");
            if (string.IsNullOrEmpty(manager))
                throw new ArgumentException("Manager name cannot be empty");
            if (string.IsNullOrEmpty(director))
                throw new ArgumentException("Director name cannot be empty");
            if (startDate >= endDate)
                throw new ArgumentException("Start date must be before end date");
            if (duration <= 0)
                throw new ArgumentException("Duration must be positive");
            if (clientId == Guid.Empty)
                throw new ArgumentException("Client ID is required");

            Id = Guid.NewGuid();
            Name = name;
            Manager = manager;
            Director = director;
            StartDate = startDate;
            EndDate = endDate;
            Duration = duration;
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
            ClientId = clientId;
        }


        public void Update(string name, string manager, string director,
            DateTime startDate, DateTime endDate, int duration, string currency)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Project name cannot be empty");
            if (string.IsNullOrEmpty(manager))
                throw new ArgumentException("Manager name cannot be empty");
            if (string.IsNullOrEmpty(director))
                throw new ArgumentException("Director name cannot be empty");
            if (startDate >= endDate)
                throw new ArgumentException("Start date must be before end date");
            if (duration <= 0)
                throw new ArgumentException("Duration must be positive");

            Name = name;
            Manager = manager;
            Director = director;
            StartDate = startDate;
            EndDate = endDate;
            Duration = duration;
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        }
    }
}
