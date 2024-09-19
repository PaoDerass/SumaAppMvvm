using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Windows.Input;

namespace SumaAppMvvm.ViewModel
{
    public partial class SumaViewModel : ObservableObject
    {
        [ObservableProperty]
        private string numero1;

        [ObservableProperty]
        private string numero2;

        [ObservableProperty]
        private string resultado;

        public SumaViewModel()
        {
            LimpiarCommand = new RelayCommand(Limpiar);
            SumarCommand = new RelayCommand(Sumar);
        }

        public ICommand SumarCommand { get; }
        public ICommand LimpiarCommand { get; }

        private void Sumar()
        {
            if (string.IsNullOrWhiteSpace(Numero1) || string.IsNullOrWhiteSpace(Numero2))
            {
                Resultado = "Los campos son obligatorios";
                return;
            }

            if (double.TryParse(Numero1, out double num1) && double.TryParse(Numero2, out double num2))
            {
                Resultado = $"Resultado: {num1 + num2}";
            }
            else
            {
                Resultado = "ingrese solo numeros validos";
            }
        }

        private void Limpiar()
        {
            Numero1 = string.Empty;
            Numero2 = string.Empty;
            Resultado = string.Empty;
        }
    }
}
