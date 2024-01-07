using proiect2.Models;

namespace proiect2;

public partial class ListPage : ContentPage
{
    private List<Programare> reservations = new List<Programare>();
    public ListPage()
    {
        InitializeComponent();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (ServList)BindingContext;
        await App.Database.DeleteShopListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ServiciiPage((ServList)
       this.BindingContext)
        {
            BindingContext = new Servicii()
        });

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (ServList)BindingContext;

        listView.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
    }
    async void OnDeleteButtonClicked1(object sender, EventArgs e)
    {
        var slist = (ServList)BindingContext;

        if (listView.SelectedItem != null && listView.SelectedItem is Servicii selectedProduct)
        {
            var confirmation = await DisplayAlert("Sterge serviciul", $"Doriti sa stergeti {selectedProduct.Description}?", "Da", "Nu");

            if (confirmation)
            {

                await App.Database.DeleteProductAsync(selectedProduct);
                listView.ItemsSource = await App.Database.GetListProductsAsync(slist.ID);
            }
        }
        else
        {
            await DisplayAlert("Niciun serviciu selectat", "Selectati un serviciu.", "OK");
        }
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        if (int.TryParse(numarPersoaneEntry.Text, out int numarPersoane))
        {
            DateTime selectedDate = datePicker.Date;
            TimeSpan selectedTime = timePicker.Time;

            // Crearea obiectului de rezervare
            Programare reservation = new Programare
            {
                Data = selectedDate,
                Ora = selectedTime,
                NumarPersoane = numarPersoane
                // Alte atribute ale obiectului de rezervare pot fi setate aici
            };

            // Programarea notificării de confirmare a rezervării
            await ScheduleNotificationAsync("Reservation Confirmation", $"Your reservation for {numarPersoane} persons on {selectedDate.ToLocalTime()} is confirmed.");

            // Programarea notificării de avertizare cu o zi înainte de rezervare
            DateTime reminderDate = selectedDate.AddDays(-1);
            await ScheduleNotificationAsync("Reservation Reminder", $"Don't forget your reservation for {numarPersoane} persons tomorrow at {reminderDate.ToLocalTime()}.");

            reservations.Add(reservation); // Adăugarea rezervării în listă

            // Salvare lista de cumpărături
            var slist = (ServList)BindingContext;
            slist.Date = selectedDate;
            await App.Database.SaveShopListAsync(slist);

            // Navigați înapoi la pagina anterioară sau efectuați alte acțiuni
            await Navigation.PopAsync();
        }
        else
        {
            DisplayAlert("Error", "Please enter a valid number of persons.", "OK");
        }
    }


    private async Task ScheduleNotificationAsync(string title, string message)
    {
        var notification = new NotificationContent
        {
            Title = title,
            Body = message
        };

        
    }

    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null && e.SelectedItem is Programare selectedListItem)
        {
            // Obțineți data selectată din elementul selectat din ListView
            DateTime selectedDate = selectedListItem.Data;

            // Navigați către ListEntryPage și transmiteți data ca BindingContext
            await Navigation.PushAsync(new ListEntryPage { BindingContext = selectedDate });
        }
    }
}