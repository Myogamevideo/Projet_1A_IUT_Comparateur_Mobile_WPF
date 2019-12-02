/// <summary>
/// La classe Login de type MetroWindow sert à charger la fenetre et utiliser des evenement liée au bouton ...
/// Elle est composé :
///     - d'un attribut m = " l'instance du manageur "
///     - d'un constructeur qui affiche la fenetre
///     - d'une méthode Button_Click pour acceder à la fenetre de lancement
///     - d'une méthode ButtonLogin_Click pour lancer la connexion de utlisateur
///     - d'une méthode Button_KeyDown pour lancer la connexion de utlisateur grace au clavier
///     - d'une méthode Textbox2_KeyDown pour changer de textbox grace au clavier
///     - d'une méthode Textbox1_KeyDown pour changer de textbox grace au clavier
/// </summary>

using System.Speech.Synthesis;
using System.Windows;
using System.Windows.Input;
using EasyPhone.Interface;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace EasyPhone
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        Manager m = MainWindow.m;
        public Login()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            this.Close();
            w.ShowDialog();
        }
        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            string MDP = passwordbox1.Password.ToString();
            string ID = textbox1.Text;
            if (m.Connection(ID, MDP))
            {
                SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
                speechSynthesizer.Speak("Connexion !");
                Window2 w = new Window2();
                this.Close();
                w.ShowDialog();
                return;
            }
            else
            {
                this.ShowMessageAsync("⛔ Veuillez réessayer ⛔", "Mot de passe ou identifiant incorrect", MessageDialogStyle.Affirmative);
            }
        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string MDP = passwordbox1.Password.ToString();
                string ID = textbox1.Text;
                if (m.Connection(ID, MDP))
                {
                    SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
                    speechSynthesizer.Speak("Connexion !");
                    Window2 w = new Window2();
                    this.Close();
                    w.ShowDialog();
                    return;
                }
                else
                {
                    this.ShowMessageAsync("⛔ Veuillez réessayer ⛔", "Mot de passe ou identifiant incorrect", MessageDialogStyle.Affirmative);
                }
            }
        }

        private void Textbox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button.Focus();
            }

        }
        private void Textbox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                passwordbox1.Focus();
            }
        }
    }
}

