using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora
{
    public class Usuario
    {
        public string nombre { set; get; }
        public string contrasena { set; get; }
        public DateTime ult_acceso { set; get; }

        public Usuario(string nombre, string contrasena)
        {
            this.nombre = nombre;
            this.contrasena = contrasena;
            this.ult_acceso = DateTime.Today;
        }
    }
}
