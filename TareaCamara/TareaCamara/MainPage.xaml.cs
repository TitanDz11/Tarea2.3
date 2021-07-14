using Plugin.Media.Abstractions;
using System;
using Xamarin.Forms;

namespace TareaCamara
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            TakePhoto.Clicked += TakePhoto_Clicked;
        }
        private async void TakePhoto_Clicked(object sender, EventArgs e)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions());
            if (photo != null)
            {
                Photo.Source = ImageSource.FromStream(() =>
                {
                    return photo.GetStream();
                });
            }
        }
    }
}  
        