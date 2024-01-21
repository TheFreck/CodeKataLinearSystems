using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearSystems
{
    public class LinearSystem
    {
        public double[][] FindVariables(string input)
        {
            var lines = input.Split("\r\n");
            double[][] variables = new double[lines.Length][];
            for (var i = 0; i < lines.Length; i++)
            {
                var chars = lines[i].Split(" ");
                variables[i] = new double[chars.Length];
                for (var j = 0; j < chars.Length; j++)
                {
                    var parsed = double.Parse(chars[j]);
                    variables[i][j] = double.Parse(chars[j]);
                }
            }
            return variables;
        }

        public double[] EliminateVar(double[] eq1, double[] eq2, int varToEliminate)
        {
            var eliminated = new double[eq1.Length, eq2.Length];
            var combined = new double[eq1.Length];
            for (var i = 0; i < eq1.Length; i++)
            {
                combined[i] = eq1[i] * eq2[varToEliminate] - eq2[i] * eq1[varToEliminate];
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

        public double[][] Condense(double[][] coefficients, int varToEliminate)
        {
            var variables = new double[coefficients.Length - 1][];
            for (var i = 0; i < coefficients.Length - 1; i++)
            {
                var eliminated = EliminateVar(coefficients[i], coefficients[i + 1], varToEliminate);
                variables[i] = eliminated;
            }
            return variables;
        }

        public double[] Solve(string input)
        { 
            var coefficients = FindVariables(input);
            var varValues = new double[coefficients[0].Length-1];
            for(var i=coefficients[0].Length-1; i>0; i--)
            {
                var allCondensed = new List<double[][]>();
                allCondensed.Add(Condense(coefficients, i));

                for(var j = 0;j < coefficients.GetLength(0)-2; j++)
                {
                    allCondensed.Add(Condense(allCondensed[j],j+1));
                }
                var isolated = Isolate(allCondensed.LastOrDefault()[0], allCondensed.Count );
                var reduced = Reduce(isolated,0);
                varValues[i-1] = reduced.LastOrDefault();
            }

            return varValues;
        }
    }
}
