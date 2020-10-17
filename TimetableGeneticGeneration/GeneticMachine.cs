using System;
using System.Collections.Generic;
using System.Text;

namespace TimetableGeneticGeneration
{
    class GeneticMachine
    {
        private List<Chromosome> _generation;
        private int _generationNum = 0;

        private int _startPopulation;

        public GeneticMachine(int startPopulation = 4)
        {
            _startPopulation = startPopulation;
            _generation = new List<Chromosome>();

            float inversedCoeffsSum = 0;
            for (int i = 0; i< _startPopulation; i++)
            {
                Chromosome start = new Chromosome("data.json");
                _generation.Add(start);
                float devi = start.ComputeDeviation();
                inversedCoeffsSum += devi == 0 ? 0 : 1 / start.ComputeDeviation();
            }
            for(int i = 0; i< _generation.Count; i++)
            {
                _generation[i].Likelihood = _generation[i].Deviation == 0 ? 100 : ((1 / _generation[i].Deviation) / inversedCoeffsSum) * 100;
            }
        }

        public void NextGeneration()
        {

        }

        public override string ToString()
        {
            String result = String.Concat("Generation number = ", _generationNum, "\n");
            int i = 1;
            foreach (var chromo in _generation)
            {
                result += String.Concat("Chromosome ", i, " , Likelihood: ", chromo.Likelihood, " % , Deviation: ", chromo.Deviation, chromo.Deviation == 0 ? " ANSWER FOUND!!!" : "", "\n");
                ++i;
            }
            return result;
        }
    }
}
