using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Dominio
{
    class Padrino
    {
        public int id { get; set; }
        public string dni { get; set; }
        public string nombre { get; set; }
        public string perro { get; set; }
        public string tlf { get; set; }
        public string direccion { get; set; }
        public string cuenta { get; set; }
        public string forma_pago { get; set; }
        public double aportacion { get; set; }
        public DateTime entrada { get; set; }
        public Uri imagen { get; set; }

        public Padrino(int id)
        {
            this.id = id;
        }
    }
}
