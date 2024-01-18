using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearSystems
{
    public class LinearSystem
    {
        public double[,] FindVariables(string input)
        {
            var lines = input.Split("\r\n");
            double[,] variables = new double[lines.Length, lines.Length + 1];
            for (var i = 0; i < lines.Length; i++)
            {
                var chars = lines[i].Split(" ");
                for (var j = 0; j < chars.Length; j++)
                {
                    variables[i, j] = double.Parse(chars[j]);
                }
            }
            return variables;
        }

        public double[] EliminateVar(double[] eq1, double[] eq2, int varToEliminate)
        {
            var eliminated = new double[eq1.Length, eq2.Length];
            var factor1 = eq1[varToEliminate];
            var factor2 = eq2[varToEliminate];
            for (var i = 0; i < eq1.Length; i++)
            {
                eliminated[0, i] = eq1[i] * factor2;
            }
            for (var j = 0; j < eq2.Length; j++)
            {
                eliminated[1, j] = eq2[j] * factor1;
            }
            var combined = new double[eq1.Length];
            for (var k = 0; k < eliminated.GetLength(1); k++)
            {
                combined[k] = eliminated[0, k] - eliminated[1, k];
            }
            return combined;
        }

        public double[] Isolate(double[] input, int varToIsolate)
        {
            var output = new List<double> { input[varToIsolate] };
            var i = 0;
            for (i = 0; i < input.Length - 1; i++)
            {
                if (i == varToIsolate) continue;
                output.Add(-input[i]);
            }
            output.Add(input[i]);
            return output.ToArray();
        }

        public double[] Reduce(double[] input, int place)
        {
            var output = new double[input.Length];
            for (var i = 0; i < output.Length; i++)
            {
                output[i] = input[i] / input[place];
            }
            return output;
        }

        public double[] Replace(double[] inputEq, double replace, int replaceVar)
        {
            inputEq[replaceVar] *= replace;
            return inputEq;
        }

        public double[] Solve2Vars(double[,] input)
        {
            double a = input[0, 0];
            double b = input[0, 1];
            double c = input[0, 2];
            double d = input[1, 0];
            double e = input[1, 1];
            double f = input[1, 2];

            double x = (c * e - b * f) / (a * e - b * d);
            double y = (c - a * x) / b;

            return new double[] { x, y };
        }

        public double[] Solve(string input)
        {
            var coefficients = FindVariables(input);
            var jaggedCoefficients = new double[coefficients.GetLength(0)][];
            for (var i = 0; i < coefficients.GetLength(0); i++)
            {
                var jaggedLine = new double[coefficients.GetLength(1)];
                for (var j = 0; j < coefficients.GetLength(1); j++)
                {
                    jaggedLine[j] = coefficients[i, j];
                }
                jaggedCoefficients[i] = jaggedLine;
            }
            var variables = new double[coefficients.GetLength(0)][];
            for (var i = 0; i < variables.GetLength(0) - 1; i++)
            {
                var eliminated = EliminateVar(jaggedCoefficients[i], jaggedCoefficients[i + 1], i);
                variables[i] = eliminated;
            }


            return new double[] { 1 };
        }
    }
}
