/// <summary>
/// La classe ListPrixTelephone de type Liste de PrixTelephone sert à rassembler tous les prix d'un telephone ou plusieur telephone
/// Elle est composé :
///     - d'un constructeur vide pour pouvoir instancier simplement
///     - d'un constructeur qui prend un attribues PrixTelephone pour pouvoir l'instancier avec un prix d'un telephone 
///     - d'un méthode Ajouter qui permet d'ajouter un prix d'un telephone à la liste si la liste ne le contiens pas déjà
///     - d'un méthode Supprimer qui permet de supprimer un prix d'un telephone de la liste si la liste possede ce prix de telephone
/// </summary>

using System.Collections.Generic;

namespace EasyPhone.Class
{
    public class ListPrixTelephone : List<PrixTelephone>
    {
        public ListPrixTelephone()
        {

        }
        public ListPrixTelephone(PrixTelephone prixtelephone)
        {
            this.Add(prixtelephone);
        }
        public bool Ajouter(PrixTelephone prix)
        {
            if (this.Contains(prix))
            {
                return false;
            }
            this.Add(prix);
            return true;
        }

        public bool Supprimer(PrixTelephone prix)
        {
            if (this.Contains(prix))
            {
                this.Remove(prix);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

