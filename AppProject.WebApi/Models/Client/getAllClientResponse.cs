using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppProject.WebApi.Models.Client
{
    public class GetAllClientResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
    }
}