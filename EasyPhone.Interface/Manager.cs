using EasyPhone.Class;
using System.Collections.Generic;
/// <summary>
/// La classe Manager sert à representer une strategie Interface qui fait le lien entre les métiers et la vue , cela permet une meilleur dynamique et performance du logicielle
/// Elle est composé :
///     - d'un attribue NB = " la position dans la liste de compte du compte à afficher lors de la connection "
///     - d'une instance de viewModel = " permet affichage du badge "
///     - d'un attribue pour la p = " permet d'utiliser la persistance "
///     - d'une instance marque  = " permet de creer une liste de Marque "
///     - d'une instance samsung = " permet de creer une liste de Telephone pour la marque samsung "
///     - d'une instance apple = " permet de creer une liste de Telephone pour la marque apple "
///     - d'une instance asus = " permet de creer une liste de Telephone pour la marque asus "
///     - d'une instance honor = " permet de creer une liste de Telephone pour la marque honor "
///     - d'une instance huawei = " permet de creer une liste de Telephone pour la marque huawei "
///     - d'une instance lg = " permet de creer une liste de Telephone pour la marque lg "
///     - d'une instance microsoft = " permet de creer une liste de Telephone pour la marque microsoft "
///     - d'une instance nokia = " permet de creer une liste de Telephone pour la marque nokia "
///     - d'une instance oneplus = " permet de creer une liste de Telephone pour la marque oneplus "
///     - d'une instance sony = " permet de creer une liste de Telephone pour la marque sony "
///     - d'une instance wiko = " permet de creer une liste de Telephone pour la marque wiko "
///     - d'une instance compte = " permet de creer une liste de Compte"
///     - d'une instance compteAfficher = " permet de creer une liste de Compte qui prendra un seul Compte , celui connecter "
///     - d'une instance tab_marque = " permet de creer une liste de tous les telephone de toutes les marques "
///     - d'une instance prixTelephones = " permet de creer une liste de PrixTelephone regroupant tous les prix de tous les telphones "
///     - d'une instance prix = " permet de creer une liste de PrixTelephone qui prend seulement les prix du telephone selectionner "
///     - d'une instance telephone = " permet de creer une liste de Telephone qui prendra un seul Telephone , celui selectionner "
///     - d'une instance comparator = " permet de creer une liste de Telephone qui prendra au maximum 3 Telephone , ceux selectionner pour etre comparer "
///     - d'un constructeur qui prend une persistance et qui charge toutes les listes et toutes les données grace à la persistance choisis
///     - d'une méthode Manager_Sauvegarder qui permet de sauvegarder toutes les listes et donnée grace à la persistance choisis
///     - d'une méthode Manager_Ajouter_Marque qui permet ajouter une Marque dans la liste marque
///     - d'une méthode Manager_Ajouter_PrixTelephone qui permet ajouter un PrixTelephone dans la liste prix
///     - d'une méthode Manager_Ajouter_Prix2 qui permet ajouter un PrixTelephone dans la liste prix
///     - d'une méthode Manager_Ajouter_Prix qui permet ajouter un PrixTelephone dans la liste prixTelephone
///     - d'une méthode Manager_Ajouter_Telephone qui permet ajouter un Telephone dans la liste tab_marque
///     - d'une méthode Manager_Ajouter_NewTelephone qui permet ajouter un Telephone dans la liste telephone
///     - d'une méthode Connection qui permet de verifier la connexion d'un utilisateur et retoruner la validite
/// </summary>
namespace EasyPhone.Interface
{
    public class Manager
    {
        public int NB;
        public ViewModel viewModel = new ViewModel();
        public Persistance.InterfacePersistance p;
        public ListMarque marque = new ListMarque();
        public ListTelephone samsung = new ListTelephone();
        public ListTelephone apple = new ListTelephone();
        public ListTelephone asus = new ListTelephone();
        public ListTelephone honor = new ListTelephone();
        public ListTelephone huawei = new ListTelephone();
        public ListTelephone lg = new ListTelephone();
        public ListTelephone microsoft = new ListTelephone();
        public ListTelephone nokia = new ListTelephone();
        public ListTelephone oneplus = new ListTelephone();
        public ListTelephone sony = new ListTelephone();
        public ListTelephone wiko = new ListTelephone();
        public ListCompte compte = new ListCompte();
        public ListCompte compteAfficher = new ListCompte();
        public List<ListTelephone> tab_marque = new List<ListTelephone>();
        public ListPrixTelephone prixTelephones = new ListPrixTelephone();
        public ListPrixTelephone prix = new ListPrixTelephone();
        public ListTelephone telephone = new ListTelephone();
        public ListTelephone comparator = new ListTelephone();

        public Manager(Persistance.InterfacePersistance p)
        {
            this.p = p;
            marque = p.lireFichierMarque(marque);
            compte = p.lireFichierCompte(compte);
            prixTelephones = p.lireFichierPrixTelephone(prixTelephones);  
            tab_marque.Add(samsung);
            tab_marque.Add(apple);
            tab_marque.Add(asus);
            tab_marque.Add(honor);
            tab_marque.Add(huawei);
            tab_marque.Add(lg);
            tab_marque.Add(microsoft);
            tab_marque.Add(nokia);
            tab_marque.Add(oneplus);
            tab_marque.Add(sony);
            tab_marque.Add(wiko);
            for (int i = 0; i < tab_marque.Count; i++)
            {
                tab_marque[i] = p.lireFichierTelephone(marque[i].TitleMarque,tab_marque[i]);
            }
        }
        public void Manager_Sauvegarder()
        {
            for (int i = 0; i < tab_marque.Count; i++)
            {
                p.Sauvegarder(marque[i].TitleMarque, tab_marque[i], marque, compte, prixTelephones);
            }
        }

        public bool Manager_Ajouter_Marque(string a, string b)
        {
            Marque NewMarque = new Marque { TitleMarque = a, ImageMarque = b };
            return marque.Ajouter(NewMarque);
        }

        public bool Manager_Ajouter_PrixTelephone(PrixTelephone prixT)
        {
            return prix.Ajouter(prixT);
        }

        public bool Manager_Ajouter_Prix2(int i)
        {
            return prix.Ajouter(prixTelephones[i]);
        }

        public bool Manager_Ajouter_Prix(string a, string b, int c, string d)
        {
            PrixTelephone NewPrix = new PrixTelephone { TitleVendeur = a, ImageVendeur = b, Prix = c, Telephone = d };
            return prixTelephones.Ajouter(NewPrix);        
        }

        public bool Manager_Ajouter_Telephone(int id , string a, string b , string c , string d , string e, string f, string g, string h, string i, string j, string k , string l , string m)
        {
            Telephone NewTelephone = new Telephone { Title = a, Image = b, Note = c , TopPrix = d , Conclusion = e , PointFort1 = f , PointFort2 = g  , PointFort3 = h , PointFaible1 = i , PointFaible2 = j , PointFaible3 = k , Article1 = l , Article2 = m };
            return tab_marque[id].Ajouter(NewTelephone);
        }
        public bool Manager_Ajouter_NewTelephone(int a , int b)
        {
            return telephone.Ajouter((tab_marque[a])[b]);
        }

        public bool Connection(string ID, string MDP)
        {
            string IDadmin;
            string MDPadmin;
            bool connection = false;
            for (int i = 0; i < compte.Count ; i++)
            {
                IDadmin = compte[i].ID;
                MDPadmin = compte[i].MDP;
                if (IDadmin == ID && MDPadmin == MDP)
                {
                    NB = i;
                    connection = true;
                }
            }
            return connection;
        }
    }
}