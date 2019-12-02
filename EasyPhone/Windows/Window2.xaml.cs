/// <summary>
/// La classe Window2 de type MetroWindow sert à charger la fenetre et utiliser des evenement liée au bouton ...
/// Elle est composé :
///     - d'un attribut m = " l'instance du manageur "
///     - d'un constructeur qui affiche la fenetre et faire du binding à la fenetre et cacher certaine partie du site en focntion du type utlisateur
///     - d'une méthode Button_Click_Home pour acceder à la fenetre principal
///     - d'une méthode Button_Click_Account pour acceder à la fenetre de connexion
///     - d'une méthode SelectionChanged qui permet de changer élément sélectionner
///     - d'une méthode SauvegarderButton_Click permet de sauvegarder
///     - d'une méthode buttonRajouter_Click permet de rajouter une marque 
///     - d'une méthode buttonSupprimer_Click permet de supprimer une marque
///     - d'une méthode buttonPrixRajouter_Click permet de rajouter un prix au telephone selectionner
///     - d'une méthode buttonPrixSupprimer_Click permet de supprimer un prix du telephone selectionner
///     - d'une méthode buttonSupprimerArticle_Click permet de supprimer un telephone selectionner
///     - d'une méthode buttonRajouterArticle_Click permet de rajouter un telephone à la marque selectionner
///     - d'une méthode Ltmarque_SelectionChanged qui permet de changer la marque sélectionner
///     - d'une méthode Lttelephone_SelectionChanged qui permet de changer le telephone sélectionner
///     - d'une méthode btnOpenFile_Click qui permet de rajouter une image au dossier Image et donner le lien de Image
///     - d'une méthode btnOpenFile_Click2 qui permet de rajouter une image au dossier Image et donner le lien de Image
///     - d'une méthode btnOpenFile_Click3 qui permet de rajouter une image au dossier Image et donner le lien de Image
/// </summary>

using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using EasyPhone.Class;
using EasyPhone.Interface;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;

namespace EasyPhone
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : MetroWindow
    {
        Manager m = MainWindow.m;
        public Window2()
        {
            InitializeComponent();
            m.compteAfficher.Ajouter(m.compte[m.NB]);
            ltcompte.ItemsSource = m.compteAfficher;
            ltmarque.ItemsSource = m.marque;
            ltmarque2.ItemsSource = m.marque;
            if (m.compte[m.NB].Titre == "Salut Redactrice !") { ListeMarque.Visibility = Visibility.Hidden; ListePrix.Visibility = Visibility.Hidden; }
            if (m.compte[m.NB].Titre == "Salut Admin !") { ListeMarque.Visibility = Visibility.Visible; }
        }
       
        private void SauvegarderButton_Click(object sender, RoutedEventArgs e)
        {
            m.Manager_Sauvegarder();
            this.ShowMessageAsync("☑ Sauvegarder ☑","", MessageDialogStyle.Affirmative);
        }
        private void buttonRajouter_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text))
            {
                string TitleM = textBox3.Text;
                string ImageM = "Image/" + textBox4.Text;
                if(m.Manager_Ajouter_Marque(TitleM, ImageM))
                {
                    ltmarque.ItemsSource = m.marque;
                    ltmarque.Items.Refresh();
                    ltmarque2.ItemsSource = m.marque;
                    ltmarque2.Items.Refresh();
                    this.ShowMessageAsync("☑ Marque bien ajouter ☑", "", MessageDialogStyle.Affirmative);
                }
                else
                {
                    this.ShowMessageAsync("❌ Marque non ajouter ❌", "Probléme lors de l'ajout", MessageDialogStyle.Affirmative);
                }

            }
            else
            {
                this.ShowMessageAsync("❌ Marque non ajouter ❌", "Veuillez remplir les champs avec une (*) ", MessageDialogStyle.Affirmative);
            }
        }
        private void buttonSupprimer_Click(object sender, RoutedEventArgs e)
        {
            m.marque.RemoveAt(ltmarque.Items.IndexOf(ltmarque.SelectedItem));
            ltmarque.ItemsSource = m.marque;
            ltmarque.Items.Refresh();
            ltmarque2.ItemsSource = m.marque;
            ltmarque2.Items.Refresh();
            this.ShowMessageAsync("☑ Marque bien supprimer ☑", "", MessageDialogStyle.Affirmative);
        }
        private void buttonPrixRajouter_Click(object sender, RoutedEventArgs e)
        {
            int a = lttelephone.Items.IndexOf(lttelephone.SelectedItem);
            string telephoneselectionner = m.telephone[a].Title;
            if (!string.IsNullOrEmpty(textBox18.Text) && !string.IsNullOrEmpty(textBox19.Text) && !string.IsNullOrEmpty(textBox20.Text))
            {
                string TitleVendeur = textBox18.Text;
                string ImageVendeur = "Image/" + textBox19.Text;
                int Prix = Convert.ToInt32(textBox20.Text);
                if(m.Manager_Ajouter_Prix(TitleVendeur, ImageVendeur, Prix, telephoneselectionner))
                {
                    for (int i = 0; i < m.prix.Count; i++)
                    {
                        if (m.prixTelephones.Exists(x => x.TitleVendeur == m.prix[i].TitleVendeur))
                        {
                            m.Manager_Ajouter_PrixTelephone(m.prix[i]);
                        }
                        else
                        {
                            m.Manager_Ajouter_PrixTelephone(m.prix[i]);
                        }
                    }
                    ltprix.ItemsSource = m.prix;
                    ltprix.Items.Refresh();
                    this.ShowMessageAsync("☑ Prix bien ajouter ☑", "", MessageDialogStyle.Affirmative);
                }
                else
                {
                    this.ShowMessageAsync("❌ Prix non ajouter ❌", "Probléme lors de l'ajout", MessageDialogStyle.Affirmative);
                }
            }
            else
            {
                this.ShowMessageAsync("❌ Prix non ajouter ❌", "Veuillez remplir les champs avec une (*) ", MessageDialogStyle.Affirmative);
            }
        }
        private void buttonPrixSupprimer_Click(object sender, RoutedEventArgs e)
        {
            m.prix.RemoveAt(ltprix.Items.IndexOf(ltprix.SelectedItem));
            for (int i = 0; i < m.prix.Count; i++)
            {
                if (m.prixTelephones.Exists(x => x.TitleVendeur == m.prix[i].TitleVendeur))
                {
                }
            }
            ltprix.ItemsSource = m.prix;
            ltprix.Items.Refresh();
            this.ShowMessageAsync("☑ Prix bien supprimer ☑", "", MessageDialogStyle.Affirmative);
        }
        private void buttonSupprimerArticle_Click(object sender, RoutedEventArgs e)
        {
            int a = ltmarque2.Items.IndexOf(ltmarque2.SelectedItem);
            int b;
            if (lttelephone.Items.IndexOf(lttelephone.SelectedItem) >= 0)
            {
                b = lttelephone.Items.IndexOf(lttelephone.SelectedItem);
            }
            else
            {
                b = 0;
            }
            m.tab_marque[a].RemoveAt(b);
            lttelephoneapercu.Items.Refresh();
            lttelephone.Items.Refresh();
            this.ShowMessageAsync("☑ Article bien supprimer ☑", "", MessageDialogStyle.Affirmative);
        }
        private void buttonRajouterArticle_Click(object sender, RoutedEventArgs e) {
            if (!string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrEmpty(textBox8.Text))
            {
                int a = ltmarque2.Items.IndexOf(ltmarque2.SelectedItem);
                string TitleA = textBox5.Text;
                string ImageA = "Image/" + textBox6.Text;
                string NoteA = textBox7.Text;
                string TopPrixA = textBox8.Text;
                string ConclusionA = textBox9.Text;
                string PointFort1A = textBox10.Text;
                string PointFort2A = textBox11.Text;
                string PointFort3A = textBox12.Text;
                string PointFaible1A = textBox13.Text;
                string PointFaible2A = textBox14.Text;
                string PointFaible3A = textBox15.Text;
                string Article1A = textBox16.Text;
                string Article2A = textBox17.Text;
                if (m.Manager_Ajouter_Telephone(a, TitleA, ImageA, NoteA, TopPrixA, ConclusionA, PointFort1A, PointFort2A, PointFort3A, PointFaible1A, PointFaible2A, PointFaible3A, Article1A, Article2A))
                {
                    lttelephoneapercu.Items.Refresh();
                    lttelephone.Items.Refresh();
                    this.ShowMessageAsync("☑ Article bien ajouter ☑", "", MessageDialogStyle.Affirmative);
                }
                else
                {
                    this.ShowMessageAsync("❌ Article non ajouter ❌", "Probléme lors de l'ajout", MessageDialogStyle.Affirmative);
                }
            }
            else
            {
                this.ShowMessageAsync("❌ Article non ajouter ❌", "Veuillez remplir les champs avec une (*) ", MessageDialogStyle.Affirmative);
            }
        }
        private void SelectionChanged()
        {
            int a = ltmarque2.Items.IndexOf(ltmarque2.SelectedItem);
            int b;
            if (lttelephone.Items.IndexOf(lttelephone.SelectedItem) >= 0) { b = lttelephone.Items.IndexOf(lttelephone.SelectedItem); }
            else { b = 0; }
            m.telephone.Clear();
            m.prix.Clear();
            lttelephone.ItemsSource = m.tab_marque[a];
            m.Manager_Ajouter_NewTelephone(a, b);
            lttelephoneapercu.ItemsSource = m.telephone;
            for (int i = 0; i < m.prixTelephones.Count; i++)
            {
                if (m.telephone.Exists(x => x.Title == m.prixTelephones[i].Telephone))
                {
                    m.Manager_Ajouter_Prix2(i);
                }
            }
            m.prix.Sort(PrixTelephone.ComparePrixTelephonePG);
            ltprix.ItemsSource = m.prix;
            ltprix.Items.Refresh();
            lttelephoneapercu.Items.Refresh();
        }
        private void Ltmarque2_SelectionChanged(object sender, SelectionChangedEventArgs e) { SelectionChanged(); }
        private void Lttelephone_SelectionChanged(object sender, SelectionChangedEventArgs e) { SelectionChanged(); }
        private void Button_Click_Home(object sender, RoutedEventArgs e)
        {
            Window1 w = new Window1();
            this.Close();
            w.ShowDialog();
        }

        private void Button_Click_Account(object sender, RoutedEventArgs e)
        {
            Login wl = new Login();
            this.Close();
            wl.ShowDialog();
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
                textBox4.Text = Path.GetFileName(openFileDialog.FileName);
                string path = Path.GetFileName(openFileDialog.FileName);
            File.Copy(openFileDialog.FileName, Path.Combine("Image/", path));
        }

        private void btnOpenFile_Click2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
                textBox19.Text = Path.GetFileName(openFileDialog.FileName);
                string path = Path.GetFileName(openFileDialog.FileName);
            File.Copy(openFileDialog.FileName, Path.Combine("Image/", path));
        }

        private void btnOpenFile_Click3(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
                textBox6.Text = Path.GetFileName(openFileDialog.FileName);
            string path = Path.GetFileName(openFileDialog.FileName);
            File.Copy(openFileDialog.FileName, Path.Combine("Image/", path));
        }
    }
}
