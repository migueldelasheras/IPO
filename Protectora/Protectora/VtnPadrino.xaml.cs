using Protectora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace Protectora
{
    /// <summary>
    /// Lógica de interacción para VtnPadrino.xaml
    /// </summary>
    public partial class VtnPadrino : Window
    {
        private int id;
        private List<Padrino> listadoPadrinos;
        public VtnPadrino(int idPadrino,string idioma)
        {
            this.id = idPadrino;
            InitializeComponent();
            Resources.MergedDictionaries.Add(App.DefineIdioma(idioma));

            listadoPadrinos = cargarPadrinos();

            Padrino elegido = listadoPadrinos[id-1];
            DataContext = elegido;
            

        }

        private List<Padrino> cargarPadrinos()
        {
            List<Padrino> listado = new List<Padrino>();
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Datos/padrinos.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoPadrino = new Padrino(0);

                nuevoPadrino.id = Convert.ToInt32(node.Attributes["id"].Value);
                nuevoPadrino.dni = node.Attributes["dni"].Value;
                nuevoPadrino.nombre = node.Attributes["nombre"].Value;
                nuevoPadrino.perro = node.Attributes["perro"].Value;
                nuevoPadrino.tlf = node.Attributes["tlf"].Value;
                nuevoPadrino.direccion = node.Attributes["direccion"].Value;
                nuevoPadrino.cuenta = node.Attributes["cuenta"].Value;
                nuevoPadrino.forma_pago = node.Attributes["forma_pago"].Value;
                nuevoPadrino.aportacion = Convert.ToDouble(node.Attributes["aportacion"].Value);
                nuevoPadrino.entrada = Convert.ToDateTime(node.Attributes["entrada"].Value);
                nuevoPadrino.imagen = new Uri(node.Attributes["imagen"].Value, UriKind.Relative);


                listado.Add(nuevoPadrino);
            }
            return listado;
        }
    }
}
