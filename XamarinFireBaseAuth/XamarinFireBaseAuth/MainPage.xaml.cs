using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinFireBaseAuth;

namespace XamarinFireBaseAuth
{
    public partial class MainPage : ContentPage
    {
        AuthClasss authClasss=new AuthClasss();
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Login_Button(object sender, EventArgs e)
        {
            try
            {
                string EmailID = Email.Text;
                string passwordStr =  passwords.Text;
                if (String.IsNullOrEmpty(EmailID))
                {
                    await DisplayAlert("Warning", "Please enter name", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(passwordStr))
                {
                    await DisplayAlert("Warning", "Please enter email", "OK");
                    return;
                }
                var isDone=await authClasss.SignIn(EmailID, passwordStr);
                if(string.IsNullOrEmpty(isDone))
                {
                    await DisplayAlert("Warning", "User is not Exist", "OK");
                    return;
                }
                else
                {
                    await Navigation.PushAsync(new AfterLogin());
                }
            }
            catch( Exception ex)
            {
                await DisplayAlert("Warning", ex.Message, "OK");
                

            }

        }
        private void Signup_Button(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUp());


        }
        private void Forgot_Password(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgotPasswordPage());


        }
    }
}
