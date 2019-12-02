/// <summary>
/// La classe ListCompte de type Liste de Compte sert à rassembler tous les comptes
/// Elle est composé :
///     - d'un constructeur vide pour pouvoir instancier simplement
///     - d'un constructeur qui prend un attribues Compte pour pouvoir l'instancier avec un Compte 
///     - d'un méthode Ajouter qui permet d'ajouter un compte à la liste si la liste ne le contiens pas déjà
///     - d'un méthode Supprimer qui permet de supprimer un compte de la liste si la liste possede ce Compte
/// </summary>

using System.Collections.Generic;

namespace EasyPhone.Class
{
    public class ListCompte : List<Compte>
    {
        public ListCompte()
        {
        }
        public ListCompte(Compte compte)
        {
            this.Add(compte);
        }
        public bool Ajouter(Compte compte)
        {
            if (this.Contains(compte))
            {
                return false;
            }
            this.Add(compte);
            return true;
        }
        public bool Supprimer(Compte compte)
        {
            if (this.Contains(compte))
            {
                this.Remove(compte);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
