using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.AspNet.SignalR.Client;

namespace SignalRMeuChatClient
{
    [Activity(Label = "SignalRMeuChatClient", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        private TextView text;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            text = FindViewById<TextView>(Resource.Id.text);
            input = FindViewById<EditText>(Resource.Id.edittext);
            button.Click += delegate { SendMessage(); };

            StartConnection();
        }

        private async void SendMessage()
        {
            // Invoke the 'UpdateNick' method on the server
            await chatHubProxy.Invoke("Send", "Xamarin", input.Text.ToString());
        }

        IHubProxy chatHubProxy;
        private EditText input;

        private async void StartConnection()
        {
            // Connect to the server
            try
            {
                var hubConnection = new HubConnection("http://192.168.0.43:61893/");

                // Create a proxy to the 'ChatHub' SignalR Hub
                chatHubProxy = hubConnection.CreateHubProxy("ChatHub");

                // Wire up a handler for the 'UpdateChatMessage' for the server
                // to be called on our client
                chatHubProxy.On<string,string>("broadcastMessage", (name, message) => {
                    var str = $"{name}:{message}\n";
                RunOnUiThread(()=>     text.Append( str ) );
                });


                // Start the connection
                await hubConnection.Start();


            }
            catch (Exception e)
            {
                text.Text = e.Message;
            }
        }
    }
}

