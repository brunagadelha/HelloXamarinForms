using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using HelloXamarin.Models;
using System.Collections.ObjectModel;

namespace HelloXamarin
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<ProductItem> Items { get; set; } = new ObservableCollection<ProductItem>();

        public MainPage()
        {
            InitializeComponent();

            ItemsList.ItemsSource = Items;
            ItemsList.ItemSelected += OnItemSelected; 
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (ProductItem)e.SelectedItem;

            bool answer = await DisplayAlert("Alerta", $"Deseja excluir o item {item.Name}?", "Sim", "Não");

            if (answer)
            {
                Items.Remove(item);
                RedefinirTotal(); 
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Quantity.Text) ||
                string.IsNullOrEmpty(Value.Text) ||
                string.IsNullOrEmpty(ProductName.Text))
            {
                DisplayAlert("Alerta", "Preencha todos os campos", "OK");
                return;
            }

            var item = new ProductItem()
            {
                Name = ProductName.Text,
                Quantity = Convert.ToInt32(Quantity.Text),
                Value = Convert.ToDecimal(Value.Text),
            };

            Items.Add(item);

            ResetForm();



            RedefinirTotal(); 



        }

        private void ResetForm()
        {
            ProductName.Text = "";
            Quantity.Text = "";
            Value.Text = "";
        }

        private void RedefinirTotal()
        {
            Total.Text = string.Format("{0:C}", Items.Sum(x => x.Total));
        }
    }
}
