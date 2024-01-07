using System;
using System.Collections.ObjectModel;
using proiect2.Models;
using proiect2.ViewModels;

namespace proiect2
{
    public partial class PaginaMedici : ContentPage
    {
        MedicViewModel viewModel;

        public PaginaMedici()
        {
            InitializeComponent();
            viewModel = (MedicViewModel)BindingContext;
        }

        private void AdaugaMedic_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(medicEntry.Text))
            {
                viewModel.AdaugaMedic(medicEntry.Text);
                medicEntry.Text = string.Empty;
            }
        }

        private void StergeMedic_Clicked(object sender, EventArgs e)
        {
            var selectedMedic = (Medic)mediciListView.SelectedItem; // obțineți medicul selectat din ListView
            viewModel.StergeMedic(selectedMedic); // apelați metoda de ștergere din ViewModel
        }

    }
}
