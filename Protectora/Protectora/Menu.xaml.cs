using Protectora.Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;

namespace Protectora
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        Usuario u;
        string idioma;
        MainWindow login;
        private List<Voluntario> listadoVoluntarios;
        private List<Socio> listadoSocios;
        private List<Aviso> listadoAvisos;
        private List<Perro> listadoPerros;
        public Menu(Usuario u,String idioma,MainWindow login)
        {
            InitializeComponent();
            this.u = u;
            this.idioma = idioma;
            this.login = login;
            Resources.MergedDictionaries.Add(App.DefineIdioma(idioma));
            listadoVoluntarios = cargarVoluntarios();
            listadoSocios = cargarSocios();
            listadoAvisos = cargarAvisos();
            listadoPerros = cargarPerros();
            
            
            dgVoluntarios.DataContext = listadoVoluntarios;
            dgSocios.DataContext = listadoSocios;
            dgAvisos.DataContext = listadoAvisos;
            dgPerros.DataContext = listadoPerros;

        }

        //Funcionalidades para salir de la aplicación
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
            
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //Cargar la lista de voluntarios del xml "voluntarios.xml"
        private List<Voluntario> cargarVoluntarios()
        {
            List<Voluntario> listado = new List<Voluntario>();
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Datos/voluntarios.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoVoluntario = new Voluntario("", "", "", "", null, 0, "", 0,"");

                nuevoVoluntario.dni = node.Attributes["dni"].Value;
                nuevoVoluntario.nombre = node.Attributes["nombre"].Value;
                nuevoVoluntario.tlf = node.Attributes["tlf"].Value;
                nuevoVoluntario.correo = node.Attributes["correo"].Value;
                nuevoVoluntario.imagen = new Uri(node.Attributes["imagen"].Value, UriKind.Relative);
                nuevoVoluntario.horario = Convert.ToInt32(node.Attributes["horario"].Value);
                nuevoVoluntario.zona = node.Attributes["zona"].Value;
                nuevoVoluntario.conocimientos = Convert.ToInt32(node.Attributes["conocimientos"].Value);
                nuevoVoluntario.observaciones = node.Attributes["observaciones"].Value;
                
                listado.Add(nuevoVoluntario);
            }
            return listado;
        }
        //cargar la lista de socios de "socios.xml"
        private List<Socio> cargarSocios()
        {
            List<Socio> listado = new List<Socio>();
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Datos/socios.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach(XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoSocio = new Socio("", "", "", "", null, "", 0, "");
                
                nuevoSocio.dni = node.Attributes["dni"].Value;
                nuevoSocio.nombre = node.Attributes["nombre"].Value;
                nuevoSocio.tlf = node.Attributes["tlf"].Value;
                nuevoSocio.correo = node.Attributes["correo"].Value;
                nuevoSocio.imagen = new Uri(node.Attributes["imagen"].Value, UriKind.Relative);
                nuevoSocio.aportacion = Convert.ToDouble(node.Attributes["aportacion"].Value);
                nuevoSocio.cuenta = node.Attributes["cuenta"].Value;
                nuevoSocio.forma_pago = node.Attributes["forma_pago"].Value;
                nuevoSocio.entrada = Convert.ToDateTime(node.Attributes["entrada"].Value);

                listado.Add(nuevoSocio);
            }
            return listado;
        }
        //cargar la lista de avisos de "avisos.xml"
        private List<Aviso> cargarAvisos()
        {
            List<Aviso> listado = new List<Aviso>();
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Datos/Avisos.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoAviso = new Aviso(0);

                nuevoAviso.id = Convert.ToInt32(node.Attributes["id"].Value);
                nuevoAviso.raza= node.Attributes["raza"].Value;
                nuevoAviso.imagen= new Uri(node.Attributes["imagen"].Value, UriKind.Relative);
                nuevoAviso.nombre= node.Attributes["nombre"].Value;
                nuevoAviso.contacto= node.Attributes["contacto"].Value;
                nuevoAviso.peso = Convert.ToDouble(node.Attributes["peso"].Value);
                nuevoAviso.sexo= Convert.ToInt32(node.Attributes["sexo"].Value);
                nuevoAviso.fecha = Convert.ToDateTime(node.Attributes["fecha"].Value);
                nuevoAviso.descripcion= node.Attributes["descripcion"].Value;
                nuevoAviso.zona= node.Attributes["zona"].Value;
                nuevoAviso.extra= node.Attributes["extra"].Value;

                

                listado.Add(nuevoAviso);
            }
            return listado;
        }

        //cargar la lista de perros de "perros.xml"
        private List<Perro> cargarPerros()
        {
            List<Perro> listado = new List<Perro>();
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Datos/Perros.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                Perro nuevoPerro = new Perro(0, "", null, "", 0, 0, 0, 0,
                        0, 0, 0, 0, 0, "", "", 3);

                nuevoPerro.id = Convert.ToInt32(node.Attributes["id"].Value);
                nuevoPerro.nombre = node.Attributes["nombre"].Value;
                nuevoPerro.imagen = new Uri(node.Attributes["imagen"].Value, UriKind.Relative);
                nuevoPerro.raza = node.Attributes["raza"].Value;
                nuevoPerro.sexo = Convert.ToInt32(node.Attributes["sexo"].Value);
                nuevoPerro.edad = Convert.ToInt32(node.Attributes["edad"].Value);
                nuevoPerro.padrino = Convert.ToInt32(node.Attributes["padrino"].Value);
                nuevoPerro.tipo = Convert.ToInt32(node.Attributes["tipo"].Value);
                nuevoPerro.peso = Convert.ToDouble(node.Attributes["peso"].Value);
                nuevoPerro.entrada = Convert.ToDateTime(node.Attributes["entrada"].Value);
                nuevoPerro.chip = Convert.ToInt32(node.Attributes["chip"].Value);
                nuevoPerro.ppp = Convert.ToInt32(node.Attributes["ppp"].Value);
                nuevoPerro.vacunado = Convert.ToInt32(node.Attributes["vacunado"].Value);
                nuevoPerro.esterilizado = Convert.ToInt32(node.Attributes["esterilizado"].Value);
                nuevoPerro.descripcion = node.Attributes["descripcion"].Value;
                nuevoPerro.enfermedad = node.Attributes["enfermedad"].Value;
                nuevoPerro.estado = Convert.ToInt32(node.Attributes["estado"].Value);

                listado.Add(nuevoPerro);
            }
            return listado;
        }

        //boton de añadir socio
        private void btnAnadirSocio_Click(object sender, RoutedEventArgs e)
        {
            if (txtdniSocio.IsReadOnly == true)
            {
                dgSocios.SelectedIndex = -1;
                txtNombreSocio.IsReadOnly = false;
                txtdniSocio.IsReadOnly = false;
                txttlfSocio.IsReadOnly = false;
                txtCorreoSocio.IsReadOnly = false;
                txtAportacionSocio.IsReadOnly = false;
                txtCuentaSocio.IsReadOnly = false;
                txtPagoSocio.IsReadOnly = false;
                txtEntradaSocio.IsEnabled = true;
                imagenSocio.Visibility = Visibility.Hidden;
                lblImagenSocio.Visibility = Visibility.Visible;
                txtAnadirImgSocio.Visibility = Visibility.Visible;

                btnEliminarSocio.IsEnabled = false;
                btnModificarSocio.IsEnabled = false;

                

                BitmapImage imagDestino = new BitmapImage(new Uri("imagenes/guardar.png", UriKind.Relative));
                imagAñadirSocio.Source = imagDestino;
                lblAñadirSocio.Content = Resources["lblConfirmar"];



            }
            else
            {

                Socio nuevoSocio;

                if (txtdniSocio.Text!=""&& txtNombreSocio.Text!=""&&txtCorreoSocio.Text!=""&&
                    txtAportacionSocio.Text!="" && txtEntradaSocio.Text!=null)
                {
                    Uri imagen = new Uri(txtAnadirImgSocio.Text, UriKind.Relative);
                    nuevoSocio = new Socio(txtdniSocio.Text, txtNombreSocio.Text, txtCorreoSocio.Text,
                    txttlfSocio.Text, imagen, txtCuentaSocio.Text, Convert.ToDouble(txtAportacionSocio.Text), txtPagoSocio.Text);
                    nuevoSocio.entrada = Convert.ToDateTime(txtEntradaSocio.Text);
                    listadoSocios.Add(nuevoSocio);
                    dgSocios.Items.Refresh();
                }
                

                txtNombreSocio.IsReadOnly = true;
                txtdniSocio.IsReadOnly = true;
                txttlfSocio.IsReadOnly = true;
                txtCorreoSocio.IsReadOnly = true;
                txtAportacionSocio.IsReadOnly = true;
                txtCuentaSocio.IsReadOnly = true;
                txtPagoSocio.IsReadOnly = true;
                txtEntradaSocio.IsEnabled = false;
                imagenSocio.Visibility = Visibility.Visible;
                lblImagenSocio.Visibility = Visibility.Hidden;
                txtAnadirImgSocio.Visibility = Visibility.Hidden;

                btnEliminarSocio.IsEnabled = true;
                btnModificarSocio.IsEnabled = true;

                BitmapImage imagDestino = new BitmapImage(new Uri("imagenes/add.png", UriKind.Relative));
                imagAñadirSocio.Source = imagDestino;
                lblAñadirSocio.Content = Resources["lblAnadirSocio"];
            }



        }
        //boton de modificar socio

        private void btnModificarSocio_Click(object sender, RoutedEventArgs e)
        {
            if (txtdniSocio.IsReadOnly == true)
            {
                txtNombreSocio.IsReadOnly = false;
                txtdniSocio.IsReadOnly = false;
                txttlfSocio.IsReadOnly = false;
                txtCorreoSocio.IsReadOnly = false;
                txtAportacionSocio.IsReadOnly = false;
                txtCuentaSocio.IsReadOnly = false;
                txtPagoSocio.IsReadOnly = false;
                txtEntradaSocio.IsEnabled = true;
                imagenSocio.Visibility = Visibility.Hidden;
                lblImagenSocio.Visibility = Visibility.Visible;
                txtAnadirImgSocio.Visibility = Visibility.Visible;

                btnAnadirSocio.IsEnabled = false;
                btnEliminarSocio.IsEnabled = false;

                BitmapImage imagDestino = new BitmapImage(new Uri("imagenes/guardar.png", UriKind.Relative));
                imgeditarSocio.Source = imagDestino;
                lbleditarSocio.Content = Resources["lblConfirmar"];

            }
            else
            {
                txtNombreSocio.IsReadOnly = true;
                txtdniSocio.IsReadOnly = true;
                txttlfSocio.IsReadOnly = true;
                txtCorreoSocio.IsReadOnly = true;
                txtAportacionSocio.IsReadOnly = true;
                txtCuentaSocio.IsReadOnly = true;
                txtPagoSocio.IsReadOnly = true;
                txtEntradaSocio.IsEnabled = false;
                imagenSocio.Visibility = Visibility.Visible;
                lblImagenSocio.Visibility = Visibility.Hidden;
                txtAnadirImgSocio.Visibility = Visibility.Hidden;

                btnAnadirSocio.IsEnabled = true;
                btnEliminarSocio.IsEnabled = true;

                BitmapImage imagDestino = new BitmapImage(new Uri("imagenes/edit.png", UriKind.Relative));
                imgeditarSocio.Source = imagDestino;
                lbleditarSocio.Content = Resources["lblModificarSocio"];
            }
        }
        //boton de eliminar socio

        private void btnEliminarSocio_Click(object sender, RoutedEventArgs e)
        {
            if (btnAnadirSocio.IsEnabled==true)
            {
                dgSocios.SelectedIndex = -1;
                
               

                btnAnadirSocio.IsEnabled = false;
                btnModificarSocio.IsEnabled = false;

                BitmapImage imagDestino = new BitmapImage(new Uri("imagenes/guardar.png", UriKind.Relative));
                imagEliminarSocio.Source = imagDestino;
                lblEliminarSocio.Content = Resources["lblConfirmar"];

            }
            else
            {
               

                btnAnadirSocio.IsEnabled = true;
                btnModificarSocio.IsEnabled = true;

                if (dgSocios.SelectedIndex>= 0)
                {
                    listadoSocios.RemoveAt(dgSocios.SelectedIndex);
                    dgSocios.Items.Refresh();
                }
                

                BitmapImage imagDestino = new BitmapImage(new Uri("imagenes/delete.png", UriKind.Relative));
                imagEliminarSocio.Source = imagDestino;
                lblEliminarSocio.Content = Resources["lblEliminarSocio"];
            }
        }
        //boton de añadir voluntario

        private void btnAnadirVolunt_Click(object sender, RoutedEventArgs e)
        {
            if (lbldni.IsReadOnly == true)
            {
                dgVoluntarios.SelectedIndex = -1;
                lblNombre.IsReadOnly = false;
                lbldni.IsReadOnly = false;
                lblTlf.IsReadOnly = false;
                lblCorreo.IsReadOnly = false;
                lblHorario.IsEnabled = true;
                lblZona.IsReadOnly = false;
                lblObservaciones.IsReadOnly = false;
                lblConoc.IsEnabled = true;
                imagenVoluntario.Visibility = Visibility.Hidden;
                lblImagenVoluntario.Visibility = Visibility.Visible;
                txtAnadirImgVoluntario.Visibility = Visibility.Visible;

                btnEliminarVolunt.IsEnabled = false;
                btnModificarVolunt.IsEnabled = false;



                BitmapImage imagDestino = new BitmapImage(new Uri("imagenes/guardar.png", UriKind.Relative));
                imagAñadirVoluntario.Source = imagDestino;
                lblAñadirVoluntario.Content = Resources["lblConfirmar"];



            }
            else
            {
                Uri imagen = new Uri(txtAnadirImgVoluntario.Text, UriKind.Relative);
                Voluntario nuevoVoluntario = new Voluntario(lbldni.Text, lblNombre.Text, lblCorreo.Text,
                    lblTlf.Text, imagen, lblHorario.SelectedIndex, lblZona.Text, lblConoc.SelectedIndex, lblObservaciones.Text);

                if (lbldni.Text!=""&&lblNombre.Text!=""&&lblTlf.Text!=""&&lblCorreo.Text!="")
                {
                    listadoVoluntarios.Add(nuevoVoluntario);
                    dgVoluntarios.Items.Refresh();
                }

                

                lblNombre.IsReadOnly = true;
                lbldni.IsReadOnly = true;
                lblTlf.IsReadOnly = true;
                lblCorreo.IsReadOnly = true;
                lblHorario.IsEnabled = false;
                lblZona.IsReadOnly = true;
                lblObservaciones.IsReadOnly = true;
                lblConoc.IsEnabled = false;
                imagenVoluntario.Visibility = Visibility.Visible;
                lblImagenVoluntario.Visibility = Visibility.Hidden;
                txtAnadirImgVoluntario.Visibility = Visibility.Hidden;

                btnEliminarVolunt.IsEnabled = true;
                btnModificarVolunt.IsEnabled = true;

                BitmapImage imagDestino = new BitmapImage(new Uri("imagenes/add.png", UriKind.Relative));
                imagAñadirVoluntario.Source = imagDestino;
                lblAñadirVoluntario.Content = Resources["lblAnadir"];
            }
        }
        //boton de eliminar voluntario

        private void btnEliminarVolunt_Click(object sender, RoutedEventArgs e)
        {
            if (btnAnadirVolunt.IsEnabled==true)
            {
                dgVoluntarios.SelectedIndex = -1;
                

                btnAnadirVolunt.IsEnabled = false;
                btnModificarVolunt.IsEnabled = false;



                BitmapImage imagDestino = new BitmapImage(new Uri("imagenes/guardar.png", UriKind.Relative));
                imagEliminarVoluntario.Source = imagDestino;
                lblEliminarVoluntario.Content = Resources["lblConfirmar"];



            }
            else
            {

                btnAnadirVolunt.IsEnabled = true;
                btnModificarVolunt.IsEnabled = true;

                if (dgVoluntarios.SelectedIndex >= 0)
                {
                    listadoVoluntarios.RemoveAt(dgVoluntarios.SelectedIndex);
                    dgVoluntarios.Items.Refresh();
                }


                BitmapImage imagDestino = new BitmapImage(new Uri("imagenes/delete.png", UriKind.Relative));
                imagEliminarVoluntario.Source = imagDestino;
                lblEliminarVoluntario.Content = Resources["lblEliminar"];
            }
        }
        //boton de modificar voluntario

        private void btnModificarVolunt_Click(object sender, RoutedEventArgs e)
        {
            if (btnAnadirVolunt.IsEnabled==true)
            {
                
                lblNombre.IsReadOnly = false;
                lbldni.IsReadOnly = false;
                lblTlf.IsReadOnly = false;
                lblCorreo.IsReadOnly = false;
                lblHorario.IsEnabled = true;
                lblZona.IsReadOnly = false;
                lblObservaciones.IsReadOnly = false;
                lblConoc.IsEnabled = true;
                imagenVoluntario.Visibility = Visibility.Hidden;
                lblImagenVoluntario.Visibility = Visibility.Visible;
                txtAnadirImgVoluntario.Visibility = Visibility.Visible;

                btnEliminarVolunt.IsEnabled = false;
                btnAnadirVolunt.IsEnabled = false;



                BitmapImage imagDestino = new BitmapImage(new Uri("imagenes/guardar.png", UriKind.Relative));
                imagEditarVoluntario.Source = imagDestino;
                lblEditarVoluntario.Content = Resources["lblConfirmar"];



            }
            else
            {

                lblNombre.IsReadOnly = true;
                lbldni.IsReadOnly = true;
                lblTlf.IsReadOnly = true;
                lblCorreo.IsReadOnly = true;
                lblHorario.IsEnabled = false;
                lblZona.IsReadOnly = true;
                lblObservaciones.IsReadOnly = true;
                lblConoc.IsEnabled = false;
                imagenVoluntario.Visibility = Visibility.Visible;
                lblImagenVoluntario.Visibility = Visibility.Hidden;
                txtAnadirImgVoluntario.Visibility = Visibility.Hidden;

                btnEliminarVolunt.IsEnabled = true;
                btnAnadirVolunt.IsEnabled = true;

                BitmapImage imagDestino = new BitmapImage(new Uri("imagenes/edit.png", UriKind.Relative));
                imagEditarVoluntario.Source = imagDestino;
                lblEditarVoluntario.Content = Resources["lblModificar"];
            }
        }
        //boton de añadir aviso

        private void btnAnadirAviso_Click(object sender, RoutedEventArgs e)
        {
            if (btnEliminarAviso.IsEnabled == true)
            {
                dgAvisos.SelectedIndex = -1;
                txtAvisoRaza.IsReadOnly = false;
                cbGenero.IsEnabled = true;
                txtAvisoContacto.IsReadOnly = false;
                txtAvisoNombre.IsReadOnly = false;
                txtAvisoPeso.IsReadOnly = false;
                txtAvisoDescripcion.IsReadOnly = false;
                txtAvisoFecha.IsEnabled = true;
                txtAvisoZona.IsReadOnly = false;
                txtAvioExtra.IsReadOnly = false;
                imagenAviso.Visibility = Visibility.Hidden;
                lblImagenAviso.Visibility = Visibility.Visible;
                txtAnadirImgAviso.Visibility = Visibility.Visible;

                btnEliminarAviso.IsEnabled = false;
                btnModificarAviso.IsEnabled = false;

                BitmapImage imagDestino = new BitmapImage(new Uri("imagenes/guardar.png", UriKind.Relative));
                imagAñadirAviso.Source = imagDestino;
                lblAñadirAviso.Content = Resources["lblConfirmar"];

            }
            else
            {

                if (txtAvisoRaza.Text != ""&&txtAvisoPeso.Text!="")
                {
                    
                    Aviso nuevoAviso = new Aviso(listadoAvisos[listadoAvisos.Count - 1].id + 1);
                    nuevoAviso.raza = txtAvisoRaza.Text;
                    nuevoAviso.sexo = cbGenero.SelectedIndex;
                    nuevoAviso.contacto = txtAvisoContacto.Text;
                    nuevoAviso.nombre = txtAvisoNombre.Text;
                    nuevoAviso.peso = Convert.ToDouble(txtAvisoPeso.Text);
                    nuevoAviso.descripcion = txtAvisoDescripcion.Text;
                    nuevoAviso.fecha = Convert.ToDateTime(txtAvisoFecha.Text);
                    nuevoAviso.zona = txtAvisoZona.Text;
                    nuevoAviso.extra = txtAvioExtra.Text;
                    Uri imagen = new Uri(txtAnadirImgAviso.Text, UriKind.Relative);
                    nuevoAviso.imagen = imagen;

                    listadoAvisos.Add(nuevoAviso);
                    dgAvisos.Items.Refresh();
                }

                txtAvisoRaza.IsReadOnly = true;
                cbGenero.IsEnabled = false;
                txtAvisoContacto.IsReadOnly = true;
                txtAvisoNombre.IsReadOnly = true;
                txtAvisoPeso.IsReadOnly = true;
                txtAvisoDescripcion.IsReadOnly = true;
                txtAvisoFecha.IsEnabled = false;
                txtAvisoZona.IsReadOnly = true;
                txtAvioExtra.IsReadOnly = true;
                imagenAviso.Visibility = Visibility.Visible;
                lblImagenAviso.Visibility = Visibility.Hidden;
                txtAnadirImgAviso.Visibility = Visibility.Hidden;

                btnEliminarAviso.IsEnabled = true;
                btnModificarAviso.IsEnabled = true;

                BitmapImage imagDestino = new BitmapImage(new Uri("imagenes/add.png", UriKind.Relative));
                imagAñadirAviso.Source = imagDestino;
                lblAñadirAviso.Content = Resources["lblAnadirAviso"];

            }

        }

        //boton de eliminar aviso
        private void btnEliminarAviso_Click(object sender, RoutedEventArgs e)
        {
            if (btnAnadirAviso.IsEnabled == true)
            {
                dgAvisos.SelectedIndex = -1;

                btnAnadirAviso.IsEnabled = false;
                btnModificarAviso.IsEnabled = false;

                BitmapImage imagDestino = new BitmapImage(new Uri("imagenes/guardar.png", UriKind.Relative));
                imagEliminarAviso.Source = imagDestino;
                lblEliminarAviso.Content = Resources["lblConfirmar"];
            }
            else
            {
                if (dgAvisos.SelectedIndex >= 0)
                {
                    listadoAvisos.RemoveAt(dgAvisos.SelectedIndex);
                    dgAvisos.Items.Refresh();
                }

                btnAnadirAviso.IsEnabled = true;
                btnModificarAviso.IsEnabled = true;

                BitmapImage imagDestino = new BitmapImage(new Uri("imagenes/delete.png", UriKind.Relative));
                imagEliminarAviso.Source = imagDestino;
                lblEliminarAviso.Content = Resources["lblEliminarAviso"];
            }
        }
        //boton de modificar aviso
        private void btnModificarAviso_Click(object sender, RoutedEventArgs e)
        {
            if (btnEliminarAviso.IsEnabled == true)
            {
                btnAnadirAviso.IsEnabled = false;
                btnEliminarAviso.IsEnabled = false;

                txtAvisoRaza.IsReadOnly = false;
                cbGenero.IsEnabled = true;
                txtAvisoContacto.IsReadOnly = false;
                txtAvisoNombre.IsReadOnly = false;
                txtAvisoPeso.IsReadOnly = false;
                txtAvisoDescripcion.IsReadOnly = false;
                txtAvisoFecha.IsEnabled = true;
                txtAvisoZona.IsReadOnly = false;
                txtAvioExtra.IsReadOnly = false;
                imagenAviso.Visibility = Visibility.Hidden;
                lblImagenAviso.Visibility = Visibility.Visible;
                txtAnadirImgAviso.Visibility = Visibility.Visible;

                BitmapImage imagDestino = new BitmapImage(new Uri("imagenes/guardar.png", UriKind.Relative));
                imgeditarAviso.Source = imagDestino;
                lbleditarAviso.Content = Resources["lblConfirmar"];


            }
            else
            {
                btnAnadirAviso.IsEnabled = true;
                btnEliminarAviso.IsEnabled = true;

                txtAvisoRaza.IsReadOnly = true;
                cbGenero.IsEnabled = false;
                txtAvisoContacto.IsReadOnly = true;
                txtAvisoNombre.IsReadOnly = true;
                txtAvisoPeso.IsReadOnly = true;
                txtAvisoDescripcion.IsReadOnly = true;
                txtAvisoFecha.IsEnabled = false;
                txtAvisoZona.IsReadOnly = true;
                txtAvioExtra.IsReadOnly = true;
                imagenAviso.Visibility = Visibility.Visible;
                lblImagenAviso.Visibility = Visibility.Hidden;
                txtAnadirImgAviso.Visibility = Visibility.Hidden;

                BitmapImage imagDestino = new BitmapImage(new Uri("imagenes/edit.png", UriKind.Relative));
                imgeditarAviso.Source = imagDestino;
                lbleditarAviso.Content = Resources["lblModificarAviso"];

            }
        }

        //mostrar/ocultar el boton del padrino del perro
        

        //mostrar ventana del padrino
        private void btnPadrinoPerro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listadoPerros[dgPerros.SelectedIndex].padrino != 0)
                {
                    int idPadrino = listadoPerros[dgPerros.SelectedIndex].padrino;
                    VtnPadrino ventanaPadrino = new VtnPadrino(idPadrino, idioma);
                    ventanaPadrino.Show();
                }
                else
                {
                    string mensaje = (string)Resources["lblNoPadrino"];
                    string caption = "Warning";
                    MessageBox.Show(mensaje, caption, MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }catch(Exception ex)
            {
                MessageBox.Show("No has seleccionado ningún item","WARNING",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }

        //boton para añadir un perro nuevo
        private void btnAnadirPerro_Click(object sender, RoutedEventArgs e)
        {
            if (btnEliminarPerro.IsEnabled == true)
            {
                dgPerros.SelectedIndex = -1;

                cbEstado.IsEnabled = true;
                lblNombrePerro.IsReadOnly = false;
                txtFechaPerro.IsEnabled = true;
                lblchipPerro.IsReadOnly = false;
                cbGeneroPerro.IsEnabled = true;
                cbTipoPerro.IsEnabled = true;
                lblpesoPerro.IsReadOnly = false;
                lblRazaPerro.IsReadOnly = false;
                cbPPP.IsEnabled = true;
                cbVacunado.IsEnabled = true;
                cbEsterilizado.IsEnabled = true;
                lblDescripcionPerro.IsReadOnly = false;
                lblEnfermedadPerro.IsReadOnly = false;
                imagenPerro.Visibility = Visibility.Hidden;
                lblImagenPerro.Visibility = Visibility.Visible;
                txtAnadirImgPerro.Visibility = Visibility.Visible;

                btnEliminarPerro.IsEnabled = false;
                btnModificarPerro.IsEnabled = false;

                BitmapImage imagDestino = new BitmapImage(new Uri("imagenes/guardar.png", UriKind.Relative));
                imagAñadirPerro.Source = imagDestino;
                lblAñadirPerro.Content = Resources["lblConfirmar"];

            }
            else
            {

                if (lblNombrePerro.Text != "" && lblRazaPerro.Text != "")
                {

                    Perro nuevoPerro = new Perro(listadoPerros[listadoPerros.Count - 1].id + 1,"",null,"",0,0,0,0,
                        0,0,0,0,0,"","",3);

                    
                    nuevoPerro.estado = cbEstado.SelectedIndex;
                    nuevoPerro.nombre = lblNombrePerro.Text;
                    nuevoPerro.raza = lblRazaPerro.Text;
                    if (!string.IsNullOrEmpty(lblchipPerro.Text))
                    {
                        nuevoPerro.chip = Convert.ToInt32(lblchipPerro.Text);

                    }
                    nuevoPerro.sexo = cbGeneroPerro.SelectedIndex;
                    nuevoPerro.tipo = cbTipoPerro.SelectedIndex;
                    if (!string.IsNullOrEmpty(lblpesoPerro.Text))
                    {
                        nuevoPerro.peso = Convert.ToDouble(lblpesoPerro.Text);

                    }
                    if (!string.IsNullOrEmpty(txtFechaPerro.Text))
                    {
                        nuevoPerro.entrada = Convert.ToDateTime(txtFechaPerro.Text);

                    }
                    nuevoPerro.ppp = cbPPP.SelectedIndex;
                    nuevoPerro.vacunado = cbVacunado.SelectedIndex;
                    nuevoPerro.esterilizado = cbEsterilizado.SelectedIndex;
                    nuevoPerro.descripcion = lblDescripcionPerro.Text;
                    nuevoPerro.enfermedad = lblEnfermedadPerro.Text;
                    Uri imagen = new Uri(txtAnadirImgPerro.Text, UriKind.Relative);
                    nuevoPerro.imagen = imagen;


                    listadoPerros.Add(nuevoPerro);
                    dgPerros.Items.Refresh();
                }

                cbEstado.IsEnabled = false;
                lblNombrePerro.IsReadOnly = true;
                txtFechaPerro.IsEnabled = false;
                lblchipPerro.IsReadOnly = true;
                cbGeneroPerro.IsEnabled = false;
                cbTipoPerro.IsEnabled = false;
                lblpesoPerro.IsReadOnly = true;
                lblRazaPerro.IsReadOnly = true;
                cbPPP.IsEnabled = false;
                cbVacunado.IsEnabled = false;
                cbEsterilizado.IsEnabled = false;
                lblDescripcionPerro.IsReadOnly = true;
                lblEnfermedadPerro.IsReadOnly = true;
                imagenPerro.Visibility = Visibility.Visible;
                lblImagenPerro.Visibility = Visibility.Hidden;
                txtAnadirImgPerro.Visibility = Visibility.Hidden;


                btnEliminarPerro.IsEnabled = true;
                btnModificarPerro.IsEnabled = true;

                BitmapImage imagDestino = new BitmapImage(new Uri("imagenes/add.png", UriKind.Relative));
                imagAñadirPerro.Source = imagDestino;
                lblAñadirPerro.Content = Resources["lblAñadirPerro"];

            }
        }
        //boton para eliminar un perro de la lista   MIRAR!!!
        private void btnEliminarPerro_Click(object sender, RoutedEventArgs e)
        {
            if (btnAnadirPerro.IsEnabled == true)
            {
                dgPerros.SelectedIndex = -1;

                btnAnadirPerro.IsEnabled = false;
                btnModificarPerro.IsEnabled = false;

                BitmapImage imagDestino = new BitmapImage(new Uri("imagenes/guardar.png", UriKind.Relative));
                imagEliminarPerro.Source = imagDestino;
                lblEliminarPerro.Content = Resources["lblConfirmar"];
            }
            else
            {
                if (dgPerros.SelectedIndex >= 0)
                {
                    listadoPerros.RemoveAt(dgPerros.SelectedIndex);
                    dgPerros.Items.Refresh();
                }

                btnAnadirPerro.IsEnabled = true;
                btnModificarPerro.IsEnabled = true;

                BitmapImage imagDestino = new BitmapImage(new Uri("imagenes/delete.png", UriKind.Relative));
                imagEliminarPerro.Source = imagDestino;
                lblEliminarPerro.Content = Resources["lblEliminarPerro"];
                dgPerros.SelectedIndex = 0;
            }
        }
        //boton para editar un perro
        private void btnModificarPerro_Click(object sender, RoutedEventArgs e)
        {
            if (btnAnadirPerro.IsEnabled == true)
            {
                btnAnadirPerro.IsEnabled = false;
                btnEliminarPerro.IsEnabled = false;

                cbEstado.IsEnabled = true;
                lblNombrePerro.IsReadOnly = false;
                txtFechaPerro.IsEnabled = true;
                lblchipPerro.IsReadOnly = false;
                cbGeneroPerro.IsEnabled = true;
                cbTipoPerro.IsEnabled = true;
                lblpesoPerro.IsReadOnly = false;
                lblRazaPerro.IsReadOnly = false;
                cbPPP.IsEnabled = true;
                cbVacunado.IsEnabled = true;
                cbEsterilizado.IsEnabled = true;
                lblDescripcionPerro.IsReadOnly = false;
                lblEnfermedadPerro.IsReadOnly = false;
                imagenPerro.Visibility = Visibility.Hidden;
                lblImagenPerro.Visibility = Visibility.Visible;
                txtAnadirImgPerro.Visibility = Visibility.Visible;

                BitmapImage imagDestino = new BitmapImage(new Uri("imagenes/guardar.png", UriKind.Relative));
                imagEditarPerro.Source = imagDestino;
                lblEditarPerro.Content = Resources["lblConfirmar"];

            }
            else
            {
                btnAnadirPerro.IsEnabled = true;
                btnEliminarPerro.IsEnabled = true;

                cbEstado.IsEnabled = false;
                lblNombrePerro.IsReadOnly = true;
                txtFechaPerro.IsEnabled = false;
                lblchipPerro.IsReadOnly = true;
                cbGeneroPerro.IsEnabled = false;
                cbTipoPerro.IsEnabled = false;
                lblpesoPerro.IsReadOnly = true;
                lblRazaPerro.IsReadOnly = true;
                cbPPP.IsEnabled = false;
                cbVacunado.IsEnabled = false;
                cbEsterilizado.IsEnabled = false;
                lblDescripcionPerro.IsReadOnly = true;
                lblEnfermedadPerro.IsReadOnly = true;
                imagenPerro.Visibility = Visibility.Visible;
                lblImagenPerro.Visibility = Visibility.Hidden;
                txtAnadirImgPerro.Visibility = Visibility.Hidden;

                BitmapImage imagDestino = new BitmapImage(new Uri("imagenes/edit.png", UriKind.Relative));
                imagEditarPerro.Source = imagDestino;
                lblEditarPerro.Content = Resources["lblEditarPerro"];

            }
        }

        //boton para cambiar de usuario
        private void btnCambiar_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;
            login.Show();
            
        }

        //boton para abrir el video de ayuda
        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("https://www.youtube.com/watch?v=iT90y1ADZjk");
            Process.Start(new ProcessStartInfo(uri.AbsoluteUri));
        }
    }
}
