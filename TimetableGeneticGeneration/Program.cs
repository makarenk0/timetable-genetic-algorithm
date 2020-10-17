using System;

namespace TimetableGeneticGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            GeneticMachine gen = new GeneticMachine();
            Console.WriteLine(gen.ToString());
        }
    }
}
