using HireApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Media;


namespace HireApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            // await DisplayAlert("Alert", "Login button clicked", "Ok");

            await Navigation.PushAsync(new NavigationPage(new HomePage()));
            //await Navigation.PushModalAsync(new NavigationPage(new HomePage()));  //not showing Back button
            //App.Current.MainPage = new NavigationPage(new HomePage());

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //DisplayAlert("Alert", "New registration tapped.", "Ok");
            App.Current.MainPage = new NavigationPage(new RegistrationPage());
        }

        
    }
}
