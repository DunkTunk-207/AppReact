using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppProject.Core.Models.Project
{
    public class CreateProjectRequest
    {
        public string Name { get; set; }
        public string ClientName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Manager { get; set; }
        public string Director { get; set; }
        public string Currency { get; set; }
        public Guid ClientId { get; set; }
    }
}
