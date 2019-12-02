/// <summary>
/// La classe Window1 de type MetroWindow sert à charger la fenetre et utiliser des evenement liée au bouton ...
/// Elle est composé :
///     - d'un attribut m = " l'instance du manageur "
///     - d'un constructeur qui affiche la fenetre et faire du binding à la fenetre
///     - d'une méthode Button_Click_Home pour acceder à la fenetre principal
///     - d'une méthode Button_Click_Account pour acceder à la fenetre de connexion
///     - d'une méthode Button_Click_Comparateur pour acceder à la fenetre du comparateur
///     - d'une méthode SelectionChanged qui permet de changer élément sélectionner
///     - d'une méthode Ltmarque_SelectionChanged qui permet de changer la marque sélectionner
///     - d'une méthode Lttelephone_SelectionChanged qui permet de changer le telephone sélectionner
///     - d'une méthode Choixtrie_SelectionChanged qui permet de changer la maniere de trier la liste de telephone
///     - d'une méthode Button_Click qui permet de charger la page web du vendeur tier qui vends le telephone selectionner au prix selectionner
///     - d'une méthode Button_Click_Article1 qui permet de charger la page web de Article1 du telephone selectionner
///     - d'une méthode Button_Click_Article2 qui permet de charger la page web de Article2 du telephone selectionner
///     - d'une méthode Button_Click_Ajouter_Comparateur qui permet d'ajouter un telephone au comparateur
/// </summary>
/// 
using System.Windows;
using System.Windows.Controls;
using EasyPhone.Class;
using System.Diagnostics;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using EasyPhone.Interface;

namespace EasyPhone
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : MetroWindow
    {
        Manager m = MainWindow.m;
        public Window1()
        {
            InitializeComponent();
            ltmarque.DataContext = m.marque;
            DataContext = m.viewModel;
        }

        private void SelectionChanged()
        {
            int a = ltmarque.Items.IndexOf(ltmarque.SelectedItem);
            int b;
            if (lttelephone.Items.IndexOf(lttelephone.SelectedItem) >= 0) { b = lttelephone.Items.IndexOf(lttelephone.SelectedItem); }
            else { b = 0; }
            m.telephone.Clear();
            m.prix.Clear();
            m.Manager_Ajouter_NewTelephone(a, b);
            for (int i = 0; i < m.prixTelephones.Count; i++)
            {
                if (m.telephone.Exists(x => x.Title == m.prixTelephones[i].Telephone))
                {
                    m.Manager_Ajouter_Prix2(i);
                }
            }
            m.prix.Sort(PrixTelephone.ComparePrixTelephonePG);
            //string topprix = m.prix[0].Prix;
            //m.telephone[0].TopPrix = topprix;
            lttelephone.DataContext = m.tab_marque[a];
            ltprix.ItemsSource = m.prix;
            lttelephoneapercu.ItemsSource = m.telephone;
            lttelephoneapercu2.ItemsSource = m.telephone;
            ltprix.Items.Refresh();
            lttelephoneapercu.Items.Refresh();
            lttelephoneapercu2.Items.Refresh();
        }

        private void Ltmarque_SelectionChanged(object sender, SelectionChangedEventArgs e) { SelectionChanged(); }
        private void Lttelephone_SelectionChanged(object sender, SelectionChangedEventArgs e) { SelectionChanged();}
        private void Choixtrie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int a = ltmarque.Items.IndexOf(ltmarque.SelectedItem);
            if (choixtrie.SelectedIndex == 0) { m.tab_marque[a].Sort(Telephone.CompareNomTelphone); lttelephone.Items.Refresh(); }
            if (choixtrie.SelectedIndex == 3){ m.tab_marque[a].Sort(Telephone.CompareNoteTelphone); lttelephone.Items.Refresh(); }
            if (choixtrie.SelectedIndex == 1) { m.tab_marque[a].Sort(Telephone.ComparePrixTelphonePG); lttelephone.Items.Refresh(); }
            if (choixtrie.SelectedIndex == 2) { m.tab_marque[a].Sort(Telephone.ComparePrixTelphoneGP); lttelephone.Items.Refresh(); }
        }

       private void Button_Click(object sender, RoutedEventArgs e)
        {
            string lien = "https://www.google.com/";
            int a = lttelephone.Items.IndexOf(lttelephone.SelectedItem);
            if (m.prix[a].TitleVendeur == "Boulanger"){lien = "https://www.boulanger.com/resultats?tr="+ m.prix[a].Telephone;}
            if (m.prix[a].TitleVendeur == "Darty") { lien = "https://www.darty.com/nav/recherche?text=" + m.prix[a].Telephone; }
            if (m.prix[a].TitleVendeur == "Fnac") { lien = "https://www.fnac.com/SearchResult/ResultList.aspx?SCat=0!1&Search=" + m.prix[a].Telephone; }
            if (m.prix[a].TitleVendeur == "Amazon") { lien = "https://www.amazon.fr/s?k=" + m.prix[a].Telephone; }
            Process.Start(lien);
        }
        private void Button_Click_Article1(object sender, RoutedEventArgs e)
        {
            string lien = "https://www.google.com/";
            lien = m.telephone[0].Article1;
            if (lien == "") { Process.Start("https://www.google.com/"); }
            else { Process.Start(lien); }
        }

        private void Button_Click_Article2(object sender, RoutedEventArgs e)
        {
            string lien = "https://www.google.com/";
            lien = m.telephone[0].Article2;
            if (lien == "") { Process.Start("https://www.google.com/"); }
            else { Process.Start(lien); }
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

        private void Button_Click_Ajouter_Comparateur(object sender, RoutedEventArgs e)
        {
            int a = ltmarque.Items.IndexOf(ltmarque.SelectedItem);
            int b;
            if (lttelephone.Items.IndexOf(lttelephone.SelectedItem) >= 0) { b = lttelephone.Items.IndexOf(lttelephone.SelectedItem); }
            else { b = 0; }
            m.viewModel.BadgeValue = (m.comparator.Count+1).ToString();
            if (m.comparator.Count <= 2)
            {
                m.comparator.Add((m.tab_marque[a])[b]);
            }
            else
            {
                this.ShowMessageAsync("⛔ Comparateur remplie ⛔", "", MessageDialogStyle.Affirmative);
            }
        }
    }
}
