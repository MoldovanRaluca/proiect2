using proiect2.Models;

namespace proiect2;

public partial class ServiciiPage : ContentPage
{
    ServList sl;
    public ServiciiPage(ServList slist)
    {
        InitializeComponent();
        sl = slist;
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var product = (Servicii)BindingContext;
        await App.Database.SaveProductAsync(product);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var product = (Servicii)BindingContext;
        await App.Database.DeleteProductAsync(product);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Servicii p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Servicii;
            var lp = new ListServicii()
            {
                ServListID = sl.ID,
                ServiciiID = p.ID
            };
            await App.Database.SaveListProductAsync(lp);
            p.ListServiciu = new List<ListServicii> { lp };
            await Navigation.PopAsync();
        }
    }
}
