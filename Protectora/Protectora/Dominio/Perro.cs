using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Dominio
{
    class Perro
    {

        public int id { get; set; }
        public string nombre { get; set; }
        public Uri imagen { get; set; }
        public string raza { get; set; }
        public int sexo { get; set; }
        public int edad { get; set; }
        public int padrino { get; set; }
        public int tipo { get; set; }
        public double peso { get; set; }
        public DateTime entrada { get; set; }
        public int chip { get; set; }
        public int ppp { get; set; }
        public int vacunado { get; set; }
        public int esterilizado { get; set; }
        public string descripcion { get; set; }
        public string enfermedad { get; set; }
        public int estado { get; set; }

        public Perro(int id, string nombre, Uri imagen, string raza, int sexo, int edad, 
            int padrino, int tipo, double peso, int chip, int ppp, 
            int vacunado, int esterilizado, string descripcion, string enfermedad, int estado)
        {
            this.id = id;
            this.nombre = nombre;
            this.imagen = imagen;
            this.raza = raza;
            this.sexo = sexo;
            this.edad = edad;
            this.padrino = padrino;
            this.tipo = tipo;
            this.peso = peso;
            
            this.chip = chip;
            this.ppp = ppp;
            this.vacunado = vacunado;
            this.esterilizado = esterilizado;
            this.descripcion = descripcion;
            this.enfermedad = enfermedad;
            this.estado = estado;
        }
    }
}
