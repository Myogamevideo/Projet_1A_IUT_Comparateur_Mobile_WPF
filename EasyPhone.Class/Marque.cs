
/// <summary>
/// La classe Marque sert à representer une marque de téléphone telle que samsung ...
/// Elle est composé :
///     - d'un constructeur vide pour pouvoir instancier simplement
///     - d'un constructeur qui prend plusieurs attribues pour pouvoir l'instancier avec plus de paramétre 
///     - d'un attribut TitleMarque = " le nom de la marque "
///     - d'un attribut ImageMarque = " la photo de de la marque "
///     - d'une redifinition du ToString() qui permet l'affichage personnalisé d'une marque
///     - d'une redifinition du GetHashCode() qui permet la generation d'une clé personnalisé pour une marque
///     - d'une redifinition du Equals pour comparer deux marque
/// </summary>

using System;

namespace EasyPhone.Class
{
    public partial class Marque
    { 
        private string titleMarque;
        private string imageMarque;
        public Marque()
        {

        }
        public Marque(string title, string image)
        {
            this.titleMarque = title;
            this.imageMarque = image;
        }
        public string TitleMarque
        {
            get { return titleMarque; }
            set
            {
                titleMarque = value;
            }
        }
        public string ImageMarque
        {
            get { return imageMarque; }
            set
            {
                imageMarque = value;
            }
        }
        public override string ToString()
        {
            return TitleMarque + ":" + ImageMarque;
        }
        public override int GetHashCode()
        {
            return TitleMarque.GetHashCode();
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

            return this.Equals(Object as Marque);
        }
        public bool Equals(Marque marque)
        {
            return (this.TitleMarque.Equals(marque.TitleMarque));
        }
    }
}
