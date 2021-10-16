using S.MobNFe.View.Principal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace S.MobNFe
{
    public partial class PrincipalPage : MasterDetailPage
    {
        public PrincipalPage()
        {
            InitializeComponent();

            CarregaPaginaDetalhe();
        }

        private void CarregaPaginaDetalhe()
        {
            try
            {
                Detail = new NavigationPage(new PrincipalDetalhe());
            }
            catch (Exception er)
            {
                var msg = er.Message;

                return;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

    }
}
