using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Dominio
{
    public class Voluntario
    {
        public string dni { set; get; }
        public string nombre { set; get; }
        public string correo { set; get; }
        public string tlf { set; get; }
        public Uri imagen { set; get; }
        public int horario { set; get;}
        public string zona { get; set; }
        public int conocimientos { set; get; }
        public string observaciones { set; get; }

        public Voluntario(string dni, string nombre, string correo, string tlf, 
            Uri imagen, int horario, string zona, int conocimientos,string observaciones)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.correo = correo;
            this.tlf = tlf;
            this.imagen = imagen;
            this.horario = horario;
            this.zona = zona;
            this.conocimientos = conocimientos;
            this.observaciones = observaciones;
        }
    }
}
