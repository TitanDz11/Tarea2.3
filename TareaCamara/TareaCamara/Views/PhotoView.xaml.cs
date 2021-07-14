using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaCamara.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotoView : ContentPage
    {
        public PhotoView()
        {
            InitializeComponent();
            }

       protected async override void OnAppearing()
        {
            base.OnAppearing();

            //Get All Persons
            var listado = await App.SQLiteDb.GetItemsAsync();
            if (listado != null)
            {
                lstfotos.ItemsSource = listado;
            }
        }
        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                imagenes imagenes = new imagenes()
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text
                  
            };


                await App.SQLiteDb.SaveItemAsync(imagenes);
                txtNombre.Text = string.Empty;
                await DisplayAlert("Correcto", "Agregado Satisfactoriamente", "OK");

                var imageneslist = await App.SQLiteDb.GetItemsAsync();
                if (imageneslist != null)
                {
                    lstfotos.ItemsSource = imageneslist;
                }
            }
            else
            {
                await DisplayAlert("Requerido", "Ingrese el nombre!", "OK");
            }
        }

        private async void BtnRead_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDescripcion.Text))
            {

                var imagenes = await App.SQLiteDb.GetItemAsync(Convert.ToInt32(txtDescripcion.Text));
                if (imagenes != null)
                {
                    txtNombre.Text = imagenes.Nombre;
                   

                }
            }
            else
            {
                await DisplayAlert("Required", "Porfavor Ingrese una Descripcion", "OK");
            }
        }




    }
}