using System.Collections.ObjectModel;
using proiect2.Models;

namespace proiect2.ViewModels
{
    public class ServiciiViewModel
    {
        public ObservableCollection<ListServici> ListaServicii { get; set; }
        public ListServici SelectedServiciu { get; set; }

        public ServiciiViewModel()
        {
            ListaServicii = new ObservableCollection<ListServici>();
            LoadServicii();
        }

        public void LoadServicii()
        {
            // Aici puteți încărca serviciile dintr-o bază de date sau altă sursă de date
            // Pentru demonstrație, adăugăm câteva date de test
            ListaServicii.Add(new ListServici { ID = 1, ServiciuName = "Chirurgie Plastică și Reparatorie" });
            ListaServicii.Add(new ListServici { ID = 2, ServiciuName = "Dermatologie și Estetică Medicală" });
            ListaServicii.Add(new ListServici { ID = 3, ServiciuName = "Remodelare Corporală" });
            ListaServicii.Add(new ListServici { ID = 4, ServiciuName = "Transplant de Păr" });
            ListaServicii.Add(new ListServici { ID = 5, ServiciuName = "Epilare Definitivă" });
        }

        public void AdaugaServiciu(string serviciuName)
        {
            var serviciu = new ListServici { ServiciuName = serviciuName };
            ListaServicii.Add(serviciu);
            // Salvați serviciul în baza de date sau sursa de date aici
        }

        public void StergeServiciu(ListServici serviciu)
        {
            ListaServicii.Remove(serviciu);
            // Adăugați logica pentru ștergerea din baza de date sau sursa de date aici
        }
    }
}
