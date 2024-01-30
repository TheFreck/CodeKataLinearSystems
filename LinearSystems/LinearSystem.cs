
namespace LinearSystems
{
    public class LinearSystem
    {
        public string Solve(string input)
        {
            var lines = input.Split("\r\n");
            decimal[][] coefficients = new decimal[lines.Length][];
            for (var i = 0; i < lines.Length; i++)
            {
                var chars = lines[i].Split(" ");
                coefficients[i] = new decimal[chars.Length];
                for (var j = 0; j < chars.Length; j++)
                {
                    var parsed = decimal.Parse(chars[j]);
                    coefficients[i][j] = decimal.Parse(chars[j]);
                }
            }
            var unitMatrix = EchelonForm(coefficients);
            if (CheckAnswer(coefficients, unitMatrix.Select(x => x.LastOrDefault()).ToArray()))
            {
                var output = "SOLUTION=(";
                for (var i = 0; i < unitMatrix.Length; i++)
                {
                    var outputString = unitMatrix[i].LastOrDefault().ToString("####.######");
                    var outputStringOrZero = (outputString == "" || outputString.Length > 0 && outputString[0] == '.') ? "0" + outputString : outputString;
                    output += $"{outputStringOrZero}; ";
                }
                output = output.Trim(' ').Trim(';');
                output += ")";
                if (output[0] == '.') output = "0" + output;
                return output;
            }
            return "SOLUTION=None";
        }

        public decimal[] Reduce(decimal[] input, int place)
        {
            if (input[place] == 0) return input;
            var output = new decimal[input.Length];
            for (var i = 0; i < output.Length; i++)
            {
                output[i] = input[i] / input[place];
            }
            return output;
        }

        public decimal[][] EchelonForm(decimal[][] input)
        {
            for (var x = 0; x < input.Length; x++)
            {
                input[x] = Reduce(input[x], x);
                for (var i = x + 1; i < input.Length; i++)
                {
                    input[i] = Reduce(input[i], x);
                    if (input[i][x] != 0)
                    {
                        for (var j = x; j < input[0].Length; j++)
                        {
                            input[i][j] = input[x][j] - input[i][j];
                        }
                    }
                }
            }
            for (var y = input.Length - 1; y >= 1; y--)
            {
                var variable = input[y].LastOrDefault();
                for (var z = y - 1; z >= 0; z--)
                {
                    input[z][input[y].Length - 1] -= input[z][y] * variable;
                    input[z][y] = 0;
                }
            }

            return input;
        }

        public bool CheckAnswer(decimal[][] inputSystem, decimal[] inputTestAnswers)
        {
            for(var i=0; i<inputSystem.Length; i++)
            {
                decimal expected = 0;
                for(var j=0; j < inputTestAnswers.Length; j++)
                {
                    expected += inputSystem[i][j] * inputTestAnswers[j];
                }
                if (expected != inputSystem[i].LastOrDefault()) return false;
            }
            return true;
        }

        //public double[] EliminateVar(double[] eq1, double[] eq2, int varToEliminate)
        //{
        //    var combined = new double[eq1.Length];
        //    for (var i = 0; i < eq1.Length; i++)
        //    {
        //        combined[i] = eq1[i] * eq2[varToEliminate] - eq2[i] * eq1[varToEliminate];
        //    }
        //    return combined;
        //}

        //public double[] Isolate(double[] input, int varToIsolate)
        //{
        //    var output = new List<double> { input[varToIsolate] };
        //    var i = 0;
        //    for (i = 0; i < input.Length - 1; i++)
        //    {
        //        if (i == varToIsolate) continue;
        //        output.Add(-input[i]);
        //    }
        //    output.Add(input[i]);
        //    return output.ToArray();
        //}

        //public double[] Replace(double[] inputEq, double replace, int replaceVar)
        //{
        //    inputEq[replaceVar] *= replace;
        //    return inputEq;
        //}

        //public double[] Solve2Vars(double[,] input)
        //{
        //    double a = input[0, 0];
        //    double b = input[0, 1];
        //    double c = input[0, 2];
        //    double d = input[1, 0];
        //    double e = input[1, 1];
        //    double f = input[1, 2];

        //    double x = (c * e - b * f) / (a * e - b * d);
        //    double y = (c - a * x) / b;

        //    return new double[] { x, y };
        //}

        //public double[][] Condense(double[][] coefficients, int varToEliminate)
        //{
        //    var variables = new double[coefficients.Length - 1][];
        //    for (var i = 0; i < coefficients.Length - 1; i++)
        //    {
        //        var eliminated = EliminateVar(coefficients[i], coefficients[i + 1], varToEliminate);
        //        variables[i] = eliminated;
        //    }
        //    return variables;
        //}
    }
}
