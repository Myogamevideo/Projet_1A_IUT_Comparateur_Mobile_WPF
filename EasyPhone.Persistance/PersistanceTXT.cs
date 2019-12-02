/// <summary>
/// La Classe PeristanceTXT est une enfant de l'InterfacePersistance
/// Elle est composé :
///     - d'une methode Sauvegarder qui permet de Sauvegarder , dans un fichier .txt , pour l'instant seulement les listes de Telephone (samsung , apple ...)
///     - d'une méthode lireFichierTelephone qui permet de Charger une liste de Telephone d'un fichier .txt
///     - d'une méthode lireFichierPrixTelephone qui permet de Charger une liste de PrixTelephone d'un fichier .txt
///     - d'une méthode lireFichierMarque qui permet de Charger une liste de Marque d'un fichier .txt
///     - d'une méthode lireFichierCompte qui permet de Charger une liste de Compte d'un fichier .txt
/// </summary>

using EasyPhone.Class;
using System;
using System.IO;

namespace EasyPhone.Persistance
{
    public class PersistanceTXT : InterfacePersistance
    {
        public void Sauvegarder(string fichier, ListTelephone liste, ListMarque marque, ListCompte compte, ListPrixTelephone prixTelephones)
        {
            StreamWriter file2 = new StreamWriter("DocText/" + fichier + ".txt");
            foreach (Telephone nom in liste)
            {
                file2.WriteLine(nom.Title);
                file2.WriteLine(nom.Image);
                file2.WriteLine(nom.Note);
                file2.WriteLine(nom.TopPrix);
                file2.WriteLine(nom.Conclusion);
                file2.WriteLine(nom.PointFort1);
                file2.WriteLine(nom.PointFort2);
                file2.WriteLine(nom.PointFort3);
                file2.WriteLine(nom.PointFaible1);
                file2.WriteLine(nom.PointFaible2);
                file2.WriteLine(nom.PointFaible3);
                file2.WriteLine(nom.Article1);
                file2.WriteLine(nom.Article2);
            }
            file2.Close();
        }
        public ListTelephone lireFichierTelephone(string nom, ListTelephone liste)
        {
            string line1;
            StreamReader file = new StreamReader("DocText/" + nom + ".txt");
            while ((line1 = file.ReadLine()) != null)
            {
                string Title;
                string Image;
                string Note;
                string TopPrix;
                string Conclusion;
                string PointFort1;
                string PointFort2;
                string PointFort3;
                string PointFaible1;
                string PointFaible2;
                string PointFaible3;
                string Article1;
                string Article2;
                Title = line1;
                Image = file.ReadLine();
                Note = file.ReadLine();
                TopPrix = file.ReadLine();
                Conclusion = file.ReadLine();
                PointFort1 = file.ReadLine();
                PointFort2 = file.ReadLine();
                PointFort3 = file.ReadLine();
                PointFaible1 = file.ReadLine();
                PointFaible2 = file.ReadLine();
                PointFaible3 = file.ReadLine();
                Article1 = file.ReadLine();
                Article2 = file.ReadLine();
                liste.Add(new Telephone() { Title = Title, Image = "/" + Image, Note = Note, TopPrix = TopPrix, Conclusion = Conclusion, PointFort1 = PointFort1, PointFort2 = PointFort2, PointFort3 = PointFort3, PointFaible1 = PointFaible1, PointFaible2 = PointFaible2, PointFaible3 = PointFaible3, Article1 = Article1, Article2 = Article2 });
            }
            file.Close();
            return liste;
        }

        public ListPrixTelephone lireFichierPrixTelephone(ListPrixTelephone prixTelephones)
        {
            string line1;
            StreamReader file = new StreamReader("DocText/prix.txt");
            while ((line1 = file.ReadLine()) != null)
            {
                string TitleVendeur;
                string ImageVendeur;
                int Prix;
                string Telephone;
                TitleVendeur = line1;
                ImageVendeur = file.ReadLine();
                Prix = Convert.ToInt32(file.ReadLine());
                Telephone = file.ReadLine();
                prixTelephones.Add(new PrixTelephone() { TitleVendeur = TitleVendeur, ImageVendeur = "/" + ImageVendeur, Prix = Prix, Telephone = Telephone });
            }
            file.Close();
            return prixTelephones;
        }
        public ListMarque lireFichierMarque(ListMarque marque)
        {
            string line1;
            string line2;

            StreamReader file = new StreamReader("DocText/marque.txt");
            while ((line1 = file.ReadLine()) != null && (line2 = file.ReadLine()) != null)
            {
                string TitleM;
                string ImageM;
                TitleM = line1;
                ImageM = line2;
                marque.Add(new Marque() { TitleMarque = TitleM, ImageMarque = "/" + ImageM });
            }
            file.Close();
            return marque;

        }
        public ListCompte lireFichierCompte(ListCompte compte)
        {
            string line1;
            StreamReader file = new StreamReader("DocText/compte.txt");
            while ((line1 = file.ReadLine()) != null)
            {
                string titre;
                string image;
                string ID;
                string MDP;
                string nom;
                string prenom;
                string email;
                titre = "Salut " + line1 + " !";
                image = file.ReadLine();
                ID = file.ReadLine();
                MDP = file.ReadLine();
                nom = file.ReadLine();
                prenom = file.ReadLine();
                email = file.ReadLine();
                compte.Add(new Compte() { Titre = titre, Image = "/" + image, ID = ID, MDP = MDP, Nom = nom, Prenom = prenom, Email = email });
            }
            file.Close();
            return compte;
        }
    }
}
