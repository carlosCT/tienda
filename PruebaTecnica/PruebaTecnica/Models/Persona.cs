using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaTecnica.Models
{
    public class Persona
    {

        public int codigo { get; set; }

        public string nombre { get; set; }

        public string cargo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}