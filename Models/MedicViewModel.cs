using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using proiect2.Models;


namespace proiect2.ViewModels
{
    public class MedicViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Medic> Medici { get; set; }
        public Medic SelectedMedic { get; set; }

        public MedicViewModel()
        {
            Medici = new ObservableCollection<Medic>();
            LoadMedici();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void LoadMedici()
        {
            // Here you can load Medici from a database or any data source
            // For demonstration, I'm adding some dummy data
            Medici.Add(new Medic { ID = 1, Nume = "Pop Sorin" });
            Medici.Add(new Medic { ID = 2, Nume = "Pastiu Radu" });
            Medici.Add(new Medic { ID = 3, Nume = "Anton Maria" });
            Medici.Add(new Medic { ID = 4, Nume = "Danciu Eric" });
            Medici.Add(new Medic { ID = 5, Nume = "Pavel Larisa" });
            Medici.Add(new Medic { ID = 6, Nume = "Crisan Carmen" });
            // Add your database logic or data retrieval mechanism here
        }

        public void AdaugaMedic(string nume)
        {
            var medic = new Medic { Nume = nume };
            Medici.Add(medic);
            // Save the medic to the database or your data source here
        }

        public void StergeMedic(Medic medic)
        {
            if (medic != null)
            {
                Medici.Remove(medic); // ștergeți medicul din lista ObservableCollection
                                      // Adăugați logica pentru ștergerea din baza de date sau sursa de date aici
            }
        }

    }
}
