using S.MobNFe.ViewModel.Principal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace S.MobNFe.View.Principal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrincipalDetalhe : ContentPage
    {
        private PrincipalDetalheViewModel VM { get; set; }

        public PrincipalDetalhe()
        {
            InitializeComponent();

            this.BindingContext = VM = new PrincipalDetalheViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            LerMensagens();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            PararLerMensagens();
        }

        private void LerMensagens()
        {
            MessagingCenter.Subscribe<string>(this, "EscanearCodigoBarra", async (str) =>
            {
                await ScanearCodigoBarraAsync();
            });
        }

        private void PararLerMensagens()
        {
            MessagingCenter.Unsubscribe<string>(this, "EscanearCodigoBarra");
        }

        public async Task ScanearCodigoBarraAsync()
        {
            var ScannerPage = new ZXingScannerPage();

            ScannerPage.OnScanResult += (result) =>
            {
                ScannerPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(() =>
                {
                    Navigation.PopAsync();
                    VM.InformarCodigoBarra(result.Text);
                });
            };

            ScannerPage.Title = "S.NF-e";

            await Navigation.PushAsync(ScannerPage);
        }
    }
}