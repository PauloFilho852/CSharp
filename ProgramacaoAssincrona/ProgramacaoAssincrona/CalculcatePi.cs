using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace CalculatePiNS;
internal class CalculatePi
{
    private readonly double calculusFraction;
    private readonly ulong incrementalFraction;
    private readonly byte numberOfTasks;
    private readonly int mod;
    private readonly ulong interactions;

    public CalculatePi(byte numberOfTasks, int powerOfTen)
    {
        if (numberOfTasks <= 0)
        {
            throw new ApplicationException("Número de tarefas deve ser maior quer zero");
        }

        if(powerOfTen <= 10)
        {
            interactions = (ulong)Math.Pow(10,powerOfTen);
        }
        else
        {
            throw new ApplicationException("O valor máximo para pontência é 10.");
        }

        if (interactions < numberOfTasks)
        {
            throw new ApplicationException("O número de interações deve ser maior ou igual ao número de tarefas.");
        }

        this.numberOfTasks = numberOfTasks;
        calculusFraction = (double)1 / numberOfTasks;
        incrementalFraction = (ulong)(interactions * calculusFraction);
        mod = (int)(interactions % numberOfTasks);
    }
    private static double CalculationTask(ulong start, ulong end)
    {
        double partialResult = 0;
               
        for (ulong i = start; i < end; i++)
        {
            partialResult += (Math.Pow(-1, i)) / ((2 * i) + 1);
        }

        return partialResult * 4;
    }

    public async Task<double> Calculate()
    {
        List<Task<double>> tasks = new();

        ulong temp = 0;

        for (byte i = 0; i < numberOfTasks; i++)
        {
            Task<double>? task = null;


            ulong start = temp;

            temp += incrementalFraction;

            if (i == numberOfTasks - 1)
            {
                temp += (ulong)mod;
            }

            ulong end = temp;

            task = new Task<double>(() => CalculationTask(start, end));
            task.Start();

            tasks.Add(task);
        }

        double[] values = await Task.WhenAll(tasks);

        double total = 0;


        foreach(var value in  values)
        {
            total += value;
        }
        
        return total;
    }
}
