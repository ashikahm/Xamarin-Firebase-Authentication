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
    public partial class ForgotPasswordPage : ContentPage
    {
        AuthClasss setPassword = new AuthClasss();
        public ForgotPasswordPage()
        {
            InitializeComponent();
        }
        public async void Reset_Password_Clicked(object sender, EventArgs e)
        {
            
          bool result= await setPassword.resetPass(Forgot_Password_Entry.Text);
            if(result)
            {
                await DisplayAlert("Password Reset", "Link sent Succefully", "ok");
            }

        }
    }
}