using System;
using System.Threading.Tasks;
using static System.Console;
namespace Tasks
{
    internal class Program
    {
        public static void Main()
        {
            Tasks();

            WriteLine("Thread_Main!");

            return;
        }

        public static void Tasks()
        {

            //o método Start possui sobrecarga e pode-se, opcionamente, especificar-se um objeto TaskCreatinOptions (ver documentação).
            // When the method run by the task completes, the task finishes, and the thread used to run the task can be recycled to execute another task.			
            Task task1 = new(Thread_1);
            task1.Start();
            task1.Wait();//Aguarda a task1 finalizar (a task1 vai ser a primeria a finalizar).

            Task task2 = new(() => Thread_2("Thread_2!"));
            task2.Start();

            //Iniciando a com o método Run, que retorna um referência à tarefa.
            Task task3 = Task.Run(Thread_3);

            //Aguarda a task2 e a task3 terminar. //Task.WaitAny(task2, task3)-Aguarda a task2 ou a task3 terminar.
            Task.WaitAll(task2, task3);

            Action<object?> action = Thread_4;
            object text = "Thread_4!";
            Task task4 = new(action, text);
            task4.Start();

            Task task5 = new(DoWork);
            task5.Start();

            // O método especificado pela continuação espera um parâmetro Task
            // e o agendador passa para o método uma referência à tarefa concluída.
            // O valor retornado por ContinueWith é uma referência ao novo objeto Task.
            //O seguinte exemplo mostra a continuação de uma tarefa, se a tarefa inicial não lançou um exceção.
            Task task6 = task5.ContinueWith(DoMoreWork, TaskContinuationOptions.NotOnFaulted);

            ReadKey();

            return;
        }

        public static void Thread_1()
        {
            WriteLine("Thread_1!");
            return;
        }

        public static void Thread_2(string text)
        {
            WriteLine(text);
            return;
        }

        public static void Thread_3()
        {
            WriteLine("Thread_3!");
            return;
        }

        public static void Thread_4(object? text)
        {
            WriteLine((string?)text);
            return;
        }

        private static void DoWork()
        {
            WriteLine("Do work!");
            return;
        }

        private static void DoMoreWork(Task task)
        {
            WriteLine("Do more work!");

            return;
        }
    }
}