
/// <summary>
/// La classe MainWindow de type MetroWindow sert à charger la fenetre et utiliser des evenement liée au bouton ...
/// Elle est composé :
///     - d'un attribut m = " instancier un manager pour pouvoir utlisier dans toutes les fenetre "
///     - d'un constructeur qui affiche la fenetre
///     - d'une méthode Button_Click pour acceder à la fenetre principal
///     - d'une méthode Button_Click_Connexion pour acceder à la fenetre de connexion
/// </summary>

using System.Speech.Synthesis;
using System.Windows;
using EasyPhone.Interface;
using MahApps.Metro.Controls;

namespace EasyPhone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public static Manager m = new Manager(new Persistance.PersistanceXML());
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 w = new Window1();
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            speechSynthesizer.Speak("Lets go !");
            this.Close();
            w.ShowDialog();       
        }
        private void Button_Click_Connexion(object sender, RoutedEventArgs e)
        {
            Login wl = new Login();
            this.Close();
            wl.ShowDialog();
        }
    }
}
