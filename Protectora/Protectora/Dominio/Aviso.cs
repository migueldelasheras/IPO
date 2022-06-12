using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Dominio
{
    class Aviso
    {
        public int id { get; set; }
        public string raza { get; set; }
        public Uri imagen { set; get; }
        public string nombre { get; set; }
        public int sexo { get; set; }
        public double peso { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }
        public string zona { get; set; }
        public string contacto { get; set; }
        public string extra { get; set; }

        public Aviso(int id)
        {
            this.id = id;
        }
    }
}