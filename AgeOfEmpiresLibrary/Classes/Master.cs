using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;

namespace AgeOfEmpiresLibrary
{
    public class Master
    {
        private string appSecret;

        private FirebaseClient firebaseClient;

        public Master()
        {
            
        }

        public void SetUpFirebase(string appSecret)
        {
            this.appSecret = appSecret;

            firebaseClient = new FirebaseClient(
                "https://aoe-analyst.firebaseio.com/",
                new FirebaseOptions
                {
                AuthTokenAsyncFactory = () => Task.FromResult(appSecret)
                }
            );

        }

        public async Task<bool> uploadGameInfo()
        {
            await firebaseClient.Child("Test").OnceAsync<string>();
            return true;
        }

        public async Task<bool> uploadGameFile()
        {
            await firebaseClient.Child("Test").OnceAsync<string>();
            return true;
        }
    }

}