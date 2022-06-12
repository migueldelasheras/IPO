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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Protectora
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            App.DefineIdioma("es-ES");
            
        }

        
        Usuario u = new Usuario("admin", "admin");
        string idioma;
        //private string[] usuarios = { "admin", "alumno" };
        //private string[] contrasenas = { "admin", "alumno" };

        

        

        private void passContrasena_KeyUp(object sender, KeyEventArgs e)
        {

            
            if (e.Key == Key.Return)
            {
                btnLogin_Click(sender,e);
            }
 
        }

        

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsuario.Text.Equals(u.nombre)&&passContrasena.Password.Equals(u.contrasena))
            {


                //Menu menu = new Menu();
                //menu.Show();
                lblIncorrecto.Visibility = Visibility.Hidden;
                Menu menu = new Menu(u,idioma,this);
                if ((bool)chRecordar.IsChecked)
                {
                    Visibility = Visibility.Hidden;
                    
                    menu.Show();
                }
                else
                {
                    Visibility = Visibility.Hidden;
                    passContrasena.Password = "";
                    menu.Show();
                }
            }
            else
            {
                lblIncorrecto.Visibility = Visibility.Visible;
            }
        }

        private void cbIdioma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            idioma = "";
            int cbi = cbIdioma.SelectedIndex;
            switch (cbi)
            {
                case 0:
                    idioma = "es-ES";
                    break;
                case 1:
                    idioma = "en-UK";
                    break;
            }
            Resources.MergedDictionaries.Add(App.DefineIdioma(idioma));
        }

        private void cbContrasena_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage imagOriginal = new BitmapImage(new Uri("passNovisible.png", UriKind.Relative));
            BitmapImage imagDestino = new BitmapImage(new Uri("passVisible.png", UriKind.Relative));

            if ((bool)cbContrasena.IsChecked)
            {
                textPassword.Text = passContrasena.Password;
                textPassword.Visibility = Visibility.Visible;
                passContrasena.Visibility = Visibility.Hidden;
                imgContrasena.ImageSource = imagDestino;

            }
            else
            {
                textPassword.Visibility = Visibility.Hidden;
                passContrasena.Visibility = Visibility.Visible;
                imgContrasena.ImageSource = imagOriginal;
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
