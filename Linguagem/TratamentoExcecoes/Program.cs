using System.Net.Http.Headers;

namespace TratamentoExcecoes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TryCatchFinally();

            Console.ReadKey();
        }

        static void TryCatchFinally()
        {
            try
            {
                //Existem as SystemException e as ApplicationException que herdam de Exception
                //Uma exceção personalizada, DomainException herda de ApplicationExcepion
                ExceptionMethod();
            }
            catch (DomainException ex)
            {
                //Caso seja lançada exceção no bloco try, o bloco catch é executado
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                Console.WriteLine($"InnerException: { ex?.InnerException?.Message}");
            }
            finally
            {
                //O bloco finally é sempre executado, caso exista exeção no bloco try ou não.
                //Adequadao para liberar recursos
                Console.WriteLine("Bloco finally executado");
            }
        }
        
        static void ExceptionMethod()
        {
            throw new DomainException("Erro de domínio.");
        }
    }
}
