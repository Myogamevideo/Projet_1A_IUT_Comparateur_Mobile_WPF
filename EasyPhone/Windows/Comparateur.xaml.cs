/// <summary>
/// La classe Comparateur de type MetroWindow sert à charger la fenetre et utiliser des evenement liée au bouton ...
/// Elle est composé :
///     - d'un attribut m = " l'instance du manageur "
///     - d'un constructeur qui affiche la fenetre et faire du binding à la fenetre
///     - d'une méthode Button_Click_Home pour acceder à la fenetre principal
///     - d'une méthode Button_Click_Account pour acceder à la fenetre de connexion
///     - d'une méthode Button_Click_Comparateur pour acceder à la fenetre du comparateur
///     - d'une méthode Button_Click_Supprimer_Comparateur qui permet de supprimer un element du comparateur
///     - d'une méthode Lttelephoneapercu_SelectionChanged qui permet de changer élément sélectionner
/// </summary>

using EasyPhone.Interface;
using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;

namespace EasyPhone
{
    /// <summary>
    /// Interaction logic for Comparateur.xaml
    /// </summary>
    public partial class Comparateur : MetroWindow
    {
        Manager m = MainWindow.m;
        public Comparateur()
        {
            InitializeComponent();
            lttelephoneapercu.ItemsSource = m.comparator;
        }
        private void Button_Click_Home(object sender, RoutedEventArgs e)
        {
            Window1 w = new Window1();
            this.Close();
            w.ShowDialog();
        }

        private void Button_Click_Comparateur(object sender, RoutedEventArgs e)
        {
            Comparateur w = new Comparateur();
            this.Close();
            w.ShowDialog();
        }

        private void Button_Click_Account(object sender, RoutedEventArgs e)
        {
            Login wl = new Login();
            this.Close();
            wl.ShowDialog();
        }
        public void Button_Click_Supprimer_Comparateur(object sender, RoutedEventArgs e)
        {
            m.comparator.RemoveAt(lttelephoneapercu.Items.IndexOf(lttelephoneapercu.SelectedItem));
            lttelephoneapercu.ItemsSource = m.comparator;
            lttelephoneapercu.Items.Refresh();
        }

        private void Lttelephoneapercu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Supprimer_comparateur.IsEnabled = true;
        }
    }
}
