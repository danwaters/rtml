﻿using Xamarin.Forms;

namespace RealtimeMoodLighting
{
    public partial class App : Application
    {
        public static Services.Log Log;
        public App()
        {
            Log = new Services.Log();
            InitializeComponent();

            MainPage = new RealtimeMoodLighting.Pages.CameraPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
