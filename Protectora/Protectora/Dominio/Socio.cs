using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Dominio
{
    class Socio
    {
        public string dni { set; get; }
        public string nombre { set; get; }
        public string correo { set; get; }
        public string tlf { set; get; }
        public Uri imagen { set; get; }
        public string cuenta { get; set; }
        public double aportacion { get; set; }
        public string forma_pago { get; set; }
        public DateTime entrada { get; set; }

        public Socio(string dni, string nombre, string correo, string tlf, 
            Uri imagen, string cuenta, double aportacion, string forma_pago)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.correo = correo;
            this.tlf = tlf;
            this.imagen = imagen;
            this.cuenta = cuenta;
            this.aportacion = aportacion;
            this.forma_pago = forma_pago;
            
        }
    }
}
