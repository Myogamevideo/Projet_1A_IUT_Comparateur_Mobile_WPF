/// <summary>
/// La Classe PersistanceXML est une enfant de l'InterfacePersistance
/// Elle est composé :
///     - d'une methode Sauvegarder qui permet de Sauvegarder , dans un fichier .xml pour toutes les listes
///     - d'une méthode lireFichierTelephone qui permet de Charger une liste de Telephone d'un fichier .xml
///     - d'une méthode lireFichierPrixTelephone qui permet de Charger une liste de PrixTelephone d'un fichier .xml
///     - d'une méthode lireFichierMarque qui permet de Charger une liste de Marque d'un fichier .xml
///     - d'une méthode lireFichierCompte qui permet de Charger une liste de Compte d'un fichier .xml
/// </summary>

using EasyPhone.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace EasyPhone.Persistance
{
    public class PersistanceXML : InterfacePersistance
    {
        public void Sauvegarder(string fichier, ListTelephone liste, ListMarque marque, ListCompte compte, ListPrixTelephone prixTelephones)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Telephone>));
            foreach (Telephone nom in liste)
            {
                using (Stream wr = File.Create("DocText/"+ fichier + ".xml"))
                {
                    xml.Serialize(wr, liste);
                }
            }

            XmlSerializer xmlmarque = new XmlSerializer(typeof(List<Marque>));
            using (Stream wr = File.Create("DocText/marque.xml"))
            {
                xmlmarque.Serialize(wr, marque);
            }

            XmlSerializer xmlcompte = new XmlSerializer(typeof(List<Compte>));
            using (Stream wr = File.Create("DocText/compte.xml"))
            {
                xmlcompte.Serialize(wr, compte);
            }

            XmlSerializer xmlprix = new XmlSerializer(typeof(List<PrixTelephone>));
            using (Stream wr = File.Create("DocText/prix.xml"))
            {
                xmlprix.Serialize(wr, prixTelephones);
            }
        }
        public ListMarque lireFichierMarque(ListMarque marque)
        {        
            ListMarque a;
            XmlSerializer xmlmarque = new XmlSerializer(typeof(ListMarque));
            using (Stream wr = File.OpenRead("DocText/marque.xml"))
            {
                a = xmlmarque.Deserialize(wr) as ListMarque;
            }
            return a;
        }

        public ListCompte lireFichierCompte(ListCompte comptes)
        {
            ListCompte a;
            XmlSerializer xmlmarque = new XmlSerializer(typeof(ListCompte));
            using (Stream wr = File.OpenRead("DocText/compte.xml"))
            {
                a = xmlmarque.Deserialize(wr) as ListCompte;
            }
            return a;
        }
        public ListPrixTelephone lireFichierPrixTelephone(ListPrixTelephone prixTelephones)
        {
            ListPrixTelephone a;
            XmlSerializer xmlmarque = new XmlSerializer(typeof(ListPrixTelephone));
            using (Stream wr = File.OpenRead("DocText/prix.xml"))
            {
                a = xmlmarque.Deserialize(wr) as ListPrixTelephone;
            }
            return a;
        }        
        public ListTelephone lireFichierTelephone(string nom, ListTelephone liste)
        {
            ListTelephone a;
            XmlSerializer xmlmarque = new XmlSerializer(typeof(ListTelephone));
            using (Stream wr = File.OpenRead("DocText/"+ nom + ".xml"))
            {
                a = xmlmarque.Deserialize(wr) as ListTelephone;
            }
            return a;
        }
    }
}
