using System;
using System.Collections.ObjectModel;
using proiect2.Models;
using proiect2.ViewModels;

namespace proiect2
{
    public partial class PaginaServicii : ContentPage
    {
        ServiciiViewModel viewModel;

        public PaginaServicii()
        {
            InitializeComponent();
            viewModel = (ServiciiViewModel)BindingContext;
        }

        private void AdaugaServiciu_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(serviciuEntry.Text))
            {
                viewModel.AdaugaServiciu(serviciuEntry.Text);
                serviciuEntry.Text = string.Empty;
            }
        }

        private void StergeServiciu_Clicked(object sender, EventArgs e)
        {
            var selectedServiciu = (ListServici)serviciiListView.SelectedItem;
            viewModel.StergeServiciu(selectedServiciu);
        }
    }
}
