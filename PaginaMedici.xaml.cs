using System;
using System.Collections.ObjectModel;
using proiect2.Models;
using proiect2.Data;

namespace proiect2
{
    public partial class PaginaMedici : ContentPage
    {
        private readonly MedicDatabase _medicDatabase;
        public ObservableCollection<Medic> Medici { get; set; }
        public Medic MedicSelectat { get; set; }

        public PaginaMedici(string dbPath)
        {
            InitializeComponent();
            _medicDatabase = new MedicDatabase(dbPath);
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Medici = new ObservableCollection<Medic>(await _medicDatabase.GetMediciAsync());
            MediciListView.ItemsSource = Medici;
        }

        private async void AdaugaMedic_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NumeMedicEntry.Text))
            {
                var medic = new Medic { Nume = NumeMedicEntry.Text };
                await _medicDatabase.SaveMedicAsync(medic);
                Medici.Add(medic);
            }
        }

        private async void StergeMedic_Clicked(object sender, EventArgs e)
        {
            if (MedicSelectat != null)
            {
                await _medicDatabase.DeleteMedicAsync(MedicSelectat);
                Medici.Remove(MedicSelectat);
            }
        }

        private async void ModificaMedic_Clicked(object sender, EventArgs e)
        {
            if (MedicSelectat != null && !string.IsNullOrWhiteSpace(NumeMedicEntry.Text))
            {
                MedicSelectat.Nume = NumeMedicEntry.Text;
                await _medicDatabase.SaveMedicAsync(MedicSelectat);
                Medici[Medici.IndexOf(MedicSelectat)] = MedicSelectat;
            }
        }
    }
}
