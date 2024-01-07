using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

namespace proiect2.Models
{
    public class MedicViewModel : BindableObject
    {
        ObservableCollection<Medic> medici;
        public ObservableCollection<Medic> Medici
        {
            get { return medici; }
            set
            {
                medici = value;
                OnPropertyChanged();
            }
        }

        Medic selectedMedic;
        public Medic SelectedMedic
        {
            get { return selectedMedic; }
            set
            {
                selectedMedic = value;
                OnPropertyChanged();
            }
        }

        public MedicViewModel()
        {
            Medici = new ObservableCollection<Medic>();
            // You might initialize with existing data from a database here
        }

        public void AdaugaMedic(string nume)
        {
            var medic = new Medic { Nume = nume };
            Medici.Add(medic);
            // Save to database or perform necessary operations
        }

        public void StergeMedic(Medic medic)
        {
            Medici.Remove(medic);
            // Remove from database or perform necessary operations
        }

        public void ModificaMedic(Medic medicToUpdate, string newNume)
        {
            if (medicToUpdate != null)
            {
                medicToUpdate.Nume = newNume;
                // Update the database or perform necessary operations to save changes
            }
        }
    }
}
