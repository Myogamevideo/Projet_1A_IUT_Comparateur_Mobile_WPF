
/// <summary>
/// La classe Compte sert à representer un compte pour des utilisateur particulier telle que admin/rédactrice
/// Elle est composé :
///     - d'un constructeur vide pour pouvoir instancier simplement
///     - d'un constructeur qui prend plusieurs attribues pour pouvoir l'instancier avec plus de paramétre 
///     - d'un attribut Titre = " le titre de utilisateur (ex: admin) "
///     - d'un attribut Image = " la photo de l'utlisateur "
///     - d'un attribue Id = " l'identifiant de utilisateur utilisé lors de la connexion "
///     - d'un attribue Nom = " le nom de utilisateur "
///     - d'un attribue Prenom = " le prenom de utilisateur "
///     - d'un attribue Email = " l'email personnel de utilisateur "
///     - d'une redifinition du ToString() qui permet l'affichage personnalisé d'un compte
///     - d'une redifinition du GetHashCode() qui permet la generation d'une clé personnalisé pour un compte
///     - d'une redifinition du Equals pour comparer deux compte
/// </summary>

namespace EasyPhone.Class
{
    public class Compte
    {
        private string titre;
        private string image;
        private string id;
        private string mdp;
        private string nom;
        private string prenom;
        private string email;
        public Compte()
        {

        }
        public Compte(string Id, string Mdp, string Nom, string Prenom, string Email, string Titre, string Image)
        {
            this.titre = Titre;
            this.image = Image;
            this.id = Id;
            this.mdp = Mdp;
            this.nom = Nom;
            this.prenom = Prenom;
            this.email = Email;
        }
        public string Titre
        {
            get { return titre; }
            set
            {
                titre = value;
            }
        }
        public string Image
        {
            get { return image; }
            set
            {
                image = value;
            }
        }
        public string ID {
            get { return id; }
            set
            {
                id = value;
            }
        }
        public string MDP
        {
            get { return mdp; }
            set
            {
                mdp = value;
            }
        }
        public string Nom
        {
            get { return nom; }
            set
            {
                nom = value;
            }
        }
        public string Prenom
        {
            get { return prenom; }
            set
            {
                prenom = value;
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
            }
        }
        
        public override string ToString()
        {
            return Titre + ":" + Nom + " " + Prenom;
        }
        /*
        public override int GetHashCode()
        {
            return Nom.GetHashCode();
        }
        
        public override bool Equals(object Object)
        {
            if (object.ReferenceEquals(Object, null))
            {
                return false;
            }

            if (object.ReferenceEquals(this, Object))
            {
                return true;
            }

            if (this.GetType() != Object.GetType())
            {
                return false;
            }

            return this.Equals(Object as Compte);
        }
        public bool Equals(Compte compte)
        {
            return (this.ID.Equals(compte.ID) && this.MDP == compte.MDP);
        }
        */
    }
}
