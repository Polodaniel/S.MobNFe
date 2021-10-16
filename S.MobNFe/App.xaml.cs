using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S.MobNFe
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PrincipalPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
