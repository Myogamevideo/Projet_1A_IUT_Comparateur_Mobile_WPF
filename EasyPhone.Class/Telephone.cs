
/// <summary>
/// La classe Telephone sert à representer un telephone portable qu'un acheteur à besoin d'informations
/// Elle est composé :
///     - d'un constructeur vide pour pouvoir instancier simplement
///     - d'un constructeur qui prend plusieurs attribues pour pouvoir l'instancier avec plus de paramétre 
///     - d'un attribut Title = " le nom du telephone (ex: samsung s9) "
///     - d'un attribut Image = " la photo du telephone "
///     - d'un attribue Note = " une note representant les avis sur le telephone "
///     - d'un attribue TopPrix = " le meilleur prix actuel du telephone sur le marché "
///     - d'un attribue Conclusion = " une conclusion de test sur le telephone "
///     - d'un attribue PointFort1 = " la 1er qualité du telephone "
///     - d'un attribue PointFort2 = " la 2eme qualité du telephone "
///     - d'un attribue PointFort3 = " la 3eme qualité du telephone "
///     - d'un attribue PointFaible1 = " le 1er default du telephone "
///     - d'un attribue PointFaible2 = " le 2eme default du telephone "
///     - d'un attribue PointFaible3 = " le 3eme default du telephone "
///     - d'un attribue Article1 = " le 1er article qui parle du telephone sur internet "
///     - d'un attribue Article2 = " le 2eme article qui parle du telephone sur internet "
///     - d'une redifinition du ToString() qui permet l'affichage personnalisé d'un telephone
///     - d'une redifinition du GetHashCode() qui permet la generation d'une clé personnalisé pour un telephone
///     - d'une redifinition du Equals pour comparer deux telephone
/// </summary>

namespace EasyPhone.Class
{
    public class Telephone
    {
        private string title;
        private string image;
        private string note;
        private string topprix;
        private string conclusion;
        private string pointfort1;
        private string pointfort2;
        private string pointfort3;
        private string pointfaible1;
        private string pointfaible2;
        private string pointfaible3;
        private string article1;
        private string article2;
        public Telephone()
        {

        }
        public Telephone(string Title, string Image, string Note, string TopPrix, string Conclusion, string PointFort1, string PointFort2, string PointFort3, string PointFaible1, string PointFaible2, string PointFaible3, string Article1, string Article2)
        {
            this.Title = Title;
            this.Image = Image;
            this.Note = Note;
            this.TopPrix = TopPrix;
            this.Conclusion = Conclusion;
            this.PointFort1 = PointFort1;
            this.PointFort2 = PointFort2;
            this.PointFort3 = PointFort3;
            this.PointFaible1 = PointFaible1;
            this.PointFaible2 = PointFaible2;
            this.PointFaible3 = PointFaible3;
            this.Article1 = Article1;
            this.Article2 = Article2;
        }
        public string Title {
            get { return title; }
            set
            {
                title = value;
            }
        }
        public string Image {
            get { return image; }
            set
            {
                image = value;
            }
        }
        public string Note {
            get { return note; }
            set
            {
                note = value;
            }
        }
        public string TopPrix {
            get { return topprix; }
            set
            {
                topprix = value;
            }
        }
        public string Conclusion {
            get { return conclusion; }
            set
            {
                conclusion = value;
            }
        }
        public string PointFort1 {
            get { return pointfort1; }
            set
            {
                pointfort1 = value;
            }
        }
        public string PointFort2 {
            get { return pointfort2; }
            set
            {
                pointfort2 = value;
            }
        }
        public string PointFort3 {
            get { return pointfort3; }
            set
            {
                pointfort3 = value;
            }
        }
        public string PointFaible1 {
            get { return pointfaible1; }
            set
            {
                pointfaible1 = value;
            }
        }
        public string PointFaible2 {
            get { return pointfaible2; }
            set
            {
                pointfaible2 = value;
            }
        }
        public string PointFaible3 {
            get { return pointfaible3; }
            set
            {
                pointfaible3 = value;
            }
        }
        public string Article1 {
            get { return article1; }
            set
            {
                article1 = value;
            }
        }
        public string Article2 {
            get { return article2; }
            set
            {
                article2 = value;
            }
        }
        public override string ToString()
        {
            return Title + "avec" + Note + ":" + TopPrix;
        }
        public override int GetHashCode()
        {
            return Title.GetHashCode();
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

            return this.Equals(Object as Telephone);
        }
        public bool Equals(Telephone telephone)
        {
            return (this.Title.Equals(telephone.Title));
        }
        public static int CompareNomTelphone(Telephone x, Telephone y)
        {
            return x.Title.CompareTo(y.Title);
        }
        public static int ComparePrixTelphonePG(Telephone x, Telephone y)
        {
            return x.TopPrix.CompareTo(y.TopPrix);
        }
        public static int ComparePrixTelphoneGP(Telephone x, Telephone y)
        {
            return y.TopPrix.CompareTo(x.TopPrix);
        }
        public static int CompareNoteTelphone(Telephone x, Telephone y)
        {
            return y.Note.CompareTo(x.Note);
        }
    }
}
