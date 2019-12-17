using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;

namespace HireApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            //CameraButton.Clicked += CameraButton_Clicked;
        }
        //private string _imagepath { get; set; }
        

        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                return;
            }
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            if (photo == null)
                return;

            await DisplayAlert("File Location", photo.Path, "OK");
            //_imagepath = photo.Path;
            if (photo != null)
                Defaultimg.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            
        }

        private async void Btnregistration_Clicked(object sender, EventArgs e)
        {
            var list = new RegistrationDetails()
            {
                UserName = txtusername.Text,
                Address = txtaddress.Text,
                Mobile = txtmobileno.Text,
                EmailID = txtemail.Text,
                Dob = dtpickerdob.Date.ToString("MMM dd yyyy"),
                Reffreence = txtrefference.Text,
                Img = Defaultimg.Source
            };

            var redirect = new HomePage();
            redirect.BindingContext = list;
            await Navigation.PushAsync(redirect);
        }
    }

    public class RegistrationDetails
    {
        public string UserName { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string EmailID { get; set; }
        public string Dob { get; set; }
        public string Reffreence { get; set; }
        public ImageSource Img { get; set; }
    }
}
