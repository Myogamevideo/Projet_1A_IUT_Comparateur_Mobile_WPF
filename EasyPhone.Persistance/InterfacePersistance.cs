/// <summary>
/// L'interface InterfacePersistance permet de reunir les méthodes :
///     - de Chargement de listes pour Marque , Compte , PrixTelephone et Telephone 
///     - de Sauvegarde de tous les listes 
/// Cela permet par la suite de choisir quel enfant de cette interface nous voulons choisir pour charger ou sauvegarder nos donnée ( 2 choix : TXT ou XML )
/// </summary>

using EasyPhone.Class;

namespace EasyPhone.Persistance
{
    public interface InterfacePersistance
    {
        ListMarque lireFichierMarque(ListMarque marque);
        ListCompte lireFichierCompte(ListCompte compte);
        ListPrixTelephone lireFichierPrixTelephone(ListPrixTelephone prixTelephones);
        ListTelephone lireFichierTelephone(string nom, ListTelephone liste);
        void Sauvegarder(string fichier, ListTelephone liste, ListMarque marque, ListCompte compte, ListPrixTelephone prixTelephones);
    }
}
