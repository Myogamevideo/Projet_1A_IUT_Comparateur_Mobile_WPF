/// <summary>
/// La Classe PeristanceTXT est une enfant de l'InterfacePersistance
/// Elle est composé :
///     - d'une methode Sauvegarder
///     - d'une méthode lireFichierTelephone qui permet de Charger une liste de Telephone d'un fichier .txt
///     - d'une méthode lireFichierPrixTelephone qui permet de Charger une liste de PrixTelephone
///     - d'une méthode lireFichierMarque qui permet de Charger une liste de Marque
///     - d'une méthode lireFichierCompte qui permet de Charger une liste de Compte
/// </summary>
/// 
using EasyPhone.Class;

namespace EasyPhone.Persistance
{
    public class Stub : InterfacePersistance
    {
        public ListMarque lireFichierMarque(ListMarque marque)
        {
            ListMarque a = new ListMarque();
            Marque samsung = new Marque { TitleMarque = "samsung", ImageMarque = "Image/samsung.png" };
            Marque apple = new Marque { TitleMarque = "samsung", ImageMarque = "Image/samsung.png" };
            Marque asus = new Marque { TitleMarque = "samsung", ImageMarque = "Image/samsung.png" };
            Marque honor = new Marque { TitleMarque = "samsung", ImageMarque = "Image/samsung.png" };
            Marque huawei = new Marque { TitleMarque = "samsung", ImageMarque = "Image/samsung.png" };
            Marque lg = new Marque { TitleMarque = "samsung", ImageMarque = "Image/samsung.png" };
            Marque microsoft = new Marque { TitleMarque = "samsung", ImageMarque = "Image/samsung.png" };
            Marque nokia = new Marque { TitleMarque = "samsung", ImageMarque = "Image/samsung.png" };
            Marque oneplus = new Marque { TitleMarque = "samsung", ImageMarque = "Image/samsung.png" };
            Marque sony = new Marque { TitleMarque = "samsung", ImageMarque = "Image/samsung.png" };
            Marque wiko = new Marque { TitleMarque = "samsung", ImageMarque = "Image/samsung.png" };

            a.Ajouter(samsung);
            a.Ajouter(apple);
            a.Ajouter(asus);
            a.Ajouter(honor);
            a.Ajouter(huawei);
            a.Ajouter(lg);
            a.Ajouter(microsoft);
            a.Ajouter(nokia);
            a.Ajouter(oneplus);
            a.Ajouter(sony);
            a.Ajouter(wiko);
            return a;
        }
        public ListCompte lireFichierCompte(ListCompte comptes)
        {
            ListCompte a = new ListCompte();
            Compte admin = new Compte { ID = "pat" , MDP = "69" , Nom = "Patrick"};
            a.Ajouter(admin);
            return a;
        }
        public ListPrixTelephone lireFichierPrixTelephone(ListPrixTelephone prixTelephones)
        {
            ListPrixTelephone a = new ListPrixTelephone();
            PrixTelephone prix = new PrixTelephone { Prix = 6000 , Telephone = "samsung s9" , TitleVendeur = "Fnac" };
            a.Ajouter(prix);
            return a;
        }
        public void Sauvegarder(string fichier, ListTelephone liste, ListMarque marque, ListCompte compte, ListPrixTelephone prixTelephones)
        {

        }
        public ListTelephone lireFichierTelephone(string nom, ListTelephone liste)
        {
            ListTelephone a = new ListTelephone();
            Telephone s9 = new Telephone { Title = "s9", TopPrix = "300€" };
            liste.Add(s9);
            return a;
        }

    }
}
