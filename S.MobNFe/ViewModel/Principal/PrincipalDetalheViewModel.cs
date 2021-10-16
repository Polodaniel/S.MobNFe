using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace S.MobNFe.ViewModel.Principal
{
    public class PrincipalDetalheViewModel : BaseViewModel
    {
        private bool isEnabledGerarNota;

        public bool IsEnabledGerarNota
        {
            get => isEnabledGerarNota;
            set => SetProperty(ref isEnabledGerarNota, value);
        }

        private string chaveAcesso;

        public string ChaveAcesso
        {
            get => chaveAcesso;
            set => SetProperty(ref chaveAcesso, value);
        }

        public ICommand Escanear { get; set; }
        public ICommand GerarNota { get; set; }

        public PrincipalDetalheViewModel()
        {
            CarregaComponentes();
            CarregaCommands();
        }

        public void CarregaComponentes()
        {
            IsEnabledGerarNota = false;
        }

        public void CarregaCommands()
        {
            Escanear = new Command(() =>
            {
                MessagingCenter.Send(string.Empty, "EscanearCodigoBarra");
            });

            GerarNota = new Command(() =>
            {
                Application.Current.UserAppTheme = OSAppTheme.Dark;
            });

        }

        public void InformarCodigoBarra(string chave)
        {
            if (!string.IsNullOrEmpty(chave))
            {
                ChaveAcesso = chave;
                IsEnabledGerarNota = true;
            }
            else 
            {
                ChaveAcesso = string.Empty;
                IsEnabledGerarNota = false;
            }
        }
    }
}
