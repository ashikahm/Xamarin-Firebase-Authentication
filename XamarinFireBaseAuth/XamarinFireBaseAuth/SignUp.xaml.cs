using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFireBaseAuth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class SignUp : ContentPage
    {
        AuthClasss userRepo = new AuthClasss();
        public SignUp()
        {
            InitializeComponent();
        }
        public async void signUp_Clicked(object sender, EventArgs e)
        {
            try
            {
                string name = Name.Text;
                string email = Email.Text;
                string password = password1.Text;
                string ConPassword = Confirmpassword.Text;

                if (String.IsNullOrEmpty(name))
                {
                    await DisplayAlert("Warning", "Please enter name", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(email))
                {
                    await DisplayAlert("Warning", "Please enter email", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(password))
                {
                    await DisplayAlert("Warning", "Please enter password", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(ConPassword))
                {
                    await DisplayAlert("Warning", "Please enter Confirmation password", "OK");
                    return;
                }
                if (password != ConPassword)
                {
                    await DisplayAlert("Warning", "Password dont match", "OK");
                }
                var isDone = await userRepo.SignUp(name,email,password);

                if (isDone)
                {
                    await DisplayAlert("Success", "Sign Up sucessful", "YAY");
                    await Navigation.PushAsync(new AfterLogin());
                }
                else
                {
                    await DisplayAlert("Failed", "Sign Up failed", "Nah");

                }
            }

            catch (Exception ex)
            {
                if (ex.Message.Contains("EMAIL_EXISTS"))
                {
                    await DisplayAlert("Warning", "Email Already Exists", "Oh !!");
                }
                else
                {
                    await DisplayAlert("Error", ex.Message, "Oops");
                }
            }
        }
    }
}
