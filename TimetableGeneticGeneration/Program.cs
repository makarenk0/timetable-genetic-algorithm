using System;
using System.Collections.Generic;
using System.Linq;

namespace TimetableGeneticGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            GeneticMachine gen = new GeneticMachine(15);
            gen.FindAnswer();
            //Console.WriteLine(gen.ToString());
            //gen.NextGeneration();
            //Console.WriteLine(gen.ToString());

            //Chromosome first = new Chromosome("data.json");
            //Chromosome second = new Chromosome("data.json");

            //Console.WriteLine("First parent");
            //Console.WriteLine(first.ToString());
            //Console.WriteLine("Second parent");
            //Console.WriteLine(second.ToString());

            //Chromosome[] children = first.doubleDaysCrossover(second, 2, "CS");

            //Console.WriteLine("First child");
            //Console.WriteLine(children[0].ToString());
            //Console.WriteLine("Second child");
            //Console.WriteLine(children[1].ToString());

            //Console.WriteLine(gen.ToString());
        }
    }
}
