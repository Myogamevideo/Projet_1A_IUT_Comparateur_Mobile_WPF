
/// <summary>
/// La classe PrixTelephone sert à representer un prix pour un téléphone (ex : S9 à 500€ chez Darty)
/// Elle est composé :
///     - d'un constructeur vide pour pouvoir instancier simplement
///     - d'un constructeur qui prend plusieurs attribues pour pouvoir l'instancier avec plus de paramétre 
///     - d'un attribut TitleVendeur = " le titre du vendeur tier (ex: fnac) "
///     - d'un attribut ImageVendeur = " la photo du vendeur tier "
///     - d'un attribue Prix = " le prix d'un téléphone chez un vendeur tier "
///     - d'un attribue Telephone = " le téléphone vendue par le vendeur tier au prix indiqué "
///     - d'une redifinition du ToString() qui permet l'affichage personnalisé d'un prix d'un téléphone
///     - d'une redifinition du GetHashCode() qui permet la generation d'une clé personnalisé pour un prix d'un téléphone
///     - d'une redifinition du Equals pour comparer deux prix d'un téléphone
/// </summary>

namespace EasyPhone.Class
{
    public class PrixTelephone
    {
        private string titleVendeur;
        private string imageVendeur;
        private int prix;
        private string telephone;
        public PrixTelephone()
        {

        }
        public PrixTelephone(string title, string image, int prix, string telephone)
        {
            this.titleVendeur = title;
            this.imageVendeur = image;
            this.prix = prix;
            this.telephone = telephone;
        }
        public string TitleVendeur
        {
            get { return titleVendeur; }
            set { titleVendeur = value; }
        }
        public string ImageVendeur
        {
            get { return imageVendeur; }
            set { imageVendeur = value; }
        }
        public int Prix
        {
            get { return prix; }
            set { prix = value; }
        }
        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }
        public override string ToString()
        {
            return TitleVendeur + ":" + Telephone + "=" + Prix;
        }
        public override int GetHashCode()
        {
            return TitleVendeur.GetHashCode();
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

            return this.Equals(Object as PrixTelephone);
        }
        public bool Equals(PrixTelephone prix)
        {
            return (this.Prix.Equals(prix.Prix));
        }
        public static int ComparePrixTelephonePG(PrixTelephone x, PrixTelephone y)
        {
            return x.Prix.CompareTo(y.Prix);
        }
    }
}
