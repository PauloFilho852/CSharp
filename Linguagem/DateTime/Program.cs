using System.IO.Pipes;

namespace NSDateTime
{
    internal class Program
    {
        static void Main()
        {
            //Data e hora atual
            DateTime hoje = DateTime.Now;
            //Imprime no formato brasileiro
            Console.WriteLine($"Hoje: {hoje}");
            
            //Cria data (aaaa, mm, dd). Hora, minuto e segundo são valores 0 quando não atribuidos.
            DateTime dateTime1 = new(2022, 09, 06);
            //Imprime no formato brasileiro
            Console.WriteLine($"Data sem hora: {dateTime1}");
            
            //Cria data (aaaa, mm, dd, hh, MM, ss)
            DateTime dateTime2 = new(2022, 09, 06, 21, 30, 22);
            //Imprime no formato brasileiro
            Console.WriteLine($"Data com hora: {dateTime2}");

            //Adicionad 1 dia
            DateTime amanha = hoje.AddDays(1);
            //Imprime no formato brasileiro
            Console.WriteLine($"Data de amanhã: {amanha}");

            //Diad do ano (inteiro)
            int ano = hoje.Year;
            Console.WriteLine($"Ano de hoje: {ano}");
            
            //Dia da semana (enumeração)
            DayOfWeek diaDaSemanaHoje = hoje.DayOfWeek;
            Console.WriteLine($"Dia da semana: {diaDaSemanaHoje}");

            //Dia do ano (inteiro)
            int diaDoAnoHoje = hoje.DayOfYear;
            Console.WriteLine($"Dia do ano: {diaDoAnoHoje}");

            //Data no formato longo e curto no formato brasileiro
            Console.WriteLine($"Data longa: {hoje.ToLongDateString()}");
            Console.WriteLine($"Data curtar: {hoje.ToShortDateString()}");

            Console.WriteLine($"Hora longa: {hoje.ToLongTimeString()}");
            Console.WriteLine($"Hora curta: {hoje.ToShortTimeString()}");

            Console.ReadKey();
        }
    }
}
