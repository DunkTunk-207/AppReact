using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppProject.WebApi.Models.Client
{
    public class CreateClientRequest
    {
        public string Name { get; set; }
        public string Contact { get; set; }
    }
}
