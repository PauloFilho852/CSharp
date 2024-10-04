using CalculatePiNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;

namespace ProgramacaoAssincrona
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BotaoExecutar_Click(object sender, RoutedEventArgs e)
        {
            OutBox.Text = "";

            int power;
            byte numberOfTasks;

            try
            {
                power = int.Parse(PotenciaInteracoes.Text);
                numberOfTasks = byte.Parse(NumeroDeTarefas.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato de entrada inválido.");
                return;
            }
          
            CalculatePi? calcutalePi;

            try
            {
                calcutalePi = new(numberOfTasks, power);
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message);
                return;

            }

            OutBox.Text = $"Calculando Pi com {numberOfTasks} tarefas e {Math.Pow(10, power):f0} interacões. Aguarde...";

            DateTime dateTime0 = DateTime.Now;

            if (calcutalePi == null)
            {
                MessageBox.Show("Instancia não inicializada");
                return;
            }

            BotaoExecutar.IsEnabled = false;

            double result = await calcutalePi.Calculate();

            DateTime dateTime1 = DateTime.Now;
            TimeSpan timeSpan = dateTime1 - dateTime0;

            OutBox.Text = "Pronto.";

            OutBox.Text += $"\nReferência: {Math.PI}";

            string strRes = result.ToString($"f{power}");

            OutBox.Text += $"\nResultado : {strRes}";

            OutBox.Text += $"\nTempo decorrido: {timeSpan.TotalSeconds} segundos";

            BotaoExecutar.IsEnabled = true;
        }

    }
}

