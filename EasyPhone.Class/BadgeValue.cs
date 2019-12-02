using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EasyPhone.Class
{
    /// <summary>
    /// La classe ViewModel sert à afficher un badge de notification pour le bouton comparateur
    /// Lors de ajout d'un téléphone dans le comparateur , le badge s'incrémente automatiquement
    /// Elle est composé :
    ///     - d'un attribut BadgeValue = "la valeur du nombre de téléphone dans le comparateur"
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        private string _badgeValue;
        public string BadgeValue
        {
            get { return _badgeValue; }
            set { _badgeValue = value; NotifyPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
