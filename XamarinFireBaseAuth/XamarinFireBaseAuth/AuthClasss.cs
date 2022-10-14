using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase;
using Firebase.Auth;

namespace XamarinFireBaseAuth
{
    public class AuthClasss
    {
        string WebApiKey = "AIzaSyDJdnb5_iwcwj0JZffJaEAPQO5QExDYReQ";
        FirebaseAuthProvider AuthProvider;

        public AuthClasss()
        {
            AuthProvider = new FirebaseAuthProvider(new FirebaseConfig(WebApiKey));
        }
        public async Task<bool> SignUp(string name, string email, string password)
        {
            var token = await AuthProvider.CreateUserWithEmailAndPasswordAsync(email, password, name);
            if(string.IsNullOrEmpty(token.FirebaseToken))
            {
                return false;
            }
            return true;

        }
        public async Task<string> SignIn( string email, string password)
        {
            var token = await AuthProvider.SignInWithEmailAndPasswordAsync(email, password);
            if(string.IsNullOrEmpty(token.FirebaseToken))
            {
                return "";
            }
            return token.FirebaseToken; 
        }
        public async Task<bool> resetPass(string email)
        {
            await AuthProvider.SendPasswordResetEmailAsync(email);
            return true;
            
        }


    }
}
