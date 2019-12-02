/// <summary>
/// La classe ListMarque de type Liste de Marque sert à rassembler toutes les marques
/// Elle est composé :
///     - d'un constructeur vide pour pouvoir instancier simplement
///     - d'un constructeur qui prend un attribues Marque pour pouvoir l'instancier avec une Marque 
///     - d'un méthode Ajouter qui permet d'ajouter une Marque à la liste si la liste ne le contiens pas déjà
///     - d'un méthode Supprimer qui permet de supprimer une Marque de la liste si la liste possede cette Marque
/// </summary>

using System.Collections.Generic;

namespace EasyPhone.Class
{
    public class ListMarque : List<Marque>
    {
        public ListMarque()
        {
        }
        public ListMarque(Marque marque)
        {
            this.Add(marque);
        }
        public bool Ajouter(Marque marque)
        {
            if(this.Contains(marque))
            {
                return false;
            }
            this.Add(marque);
            return true;
        }
        public bool Supprimer(Marque marque)
        {
            if (this.Contains(marque))
            {
                this.Remove(marque);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
