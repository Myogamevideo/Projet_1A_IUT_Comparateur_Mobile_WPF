/// <summary>
/// La classe ListTelephone de type Liste de Telephone sert à rassembler tous les telephones d'une marque ou tous les telephone
/// Elle est composé :
///     - d'un constructeur vide pour pouvoir instancier simplement
///     - d'un constructeur qui prend un attribues Telephone pour pouvoir l'instancier avec un Telephone 
///     - d'un méthode Ajouter qui permet d'ajouter un Telephone à la liste si la liste ne le contiens pas déjà
///     - d'un méthode Supprimer qui permet de supprimer un Telephone de la liste si la liste possede ce Telephone
/// </summary>

using System.Collections.Generic;

namespace EasyPhone.Class
{
    public class ListTelephone : List<Telephone>
    {
        public ListTelephone()
        {

        }
        public ListTelephone(Telephone telephone)
        {
            this.Add(telephone);
        }
        public bool Ajouter(Telephone telephone)
        {
            if (this.Contains(telephone))
            {
                return false;
            }
            this.Add(telephone);
            return true;
        }

        public bool Supprimer(Telephone telephone)
        {
            if (this.Contains(telephone))
            {
                this.Remove(telephone);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
