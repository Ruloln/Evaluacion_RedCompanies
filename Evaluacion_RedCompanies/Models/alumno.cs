using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion_RedCompanies.Models
{
    public class alumno
    {
        public int id { get; set; }

        public string nombre { get; set; }
        public string apellido { get; set; }
        public string cedula { get; set; }
        public int aula_id { get; set; }
    }
}