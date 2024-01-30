using Machine.Specifications;

namespace LinearSystems.Specs
{
    public class With_A_Linear_System
    {
        Establish context = () =>
        {
            linearSystem = new LinearSystem();
        };

        protected static LinearSystem linearSystem;
    }

    public class When_Solving_Linear_Equations_And_A_Solution_Exists : With_A_Linear_System
    {
        Establish context = () =>
        {
            input = new string[]
            {
                "2 3 2 14\r\n1 4 2 15\r\n2 -3 1 -1",
                "1 2 0 7\r\n0 2 4 8\r\n0 5 6 9",
                "3 1 4 14\r\n2 2 2 15\r\n1 -2 2 -1",
                "3 -2 -7 -9\r\n-1 3 4 4\r\n-4 1 5 5",
                "1 2 0 10\r\n-3 0 2 -12\r\n-2 2 0 4",
                "1 1 2\r\n2 1 2.5",
            };

            expected = new string[]
            {
                "SOLUTION=(1; 2; 3)",
                "SOLUTION=(10; -1.5; 2.75)",
                "SOLUTION=(16; 0; -8.5)",
                "SOLUTION=(1; -1; 2)",
                "SOLUTION=(2; 4; -3)",
                "SOLUTION=(0.5; 1.5)",
            };

            answer = new string[input.Length];
        };


        Because of = () =>
        {
            for (var i = 0; i < input.Length; i++)
            {
                answer[i] = linearSystem.Solve(input[i]);
            }
        };

        It Should_Return_Expected = () =>
        {
            for (var i = 0; i < answer.Length; i++)
            {
                answer[i].ShouldEqual(expected[i]);
            }
        };

        private static string[] input;
        private static string[] answer;
        private static string[] expected;
    }

    public class When_Solving_Linear_Equations_And_NO_Solution_Exists : With_A_Linear_System
    {
        Establish context = () =>
        {
            input = new string[]
            {
                "1 2 1\r\n1 2 0",
                "14 0 7 8\r\n2 0 3 12\r\n-20 11 2 8",
                "3 1 2 4\r\n3 1 2 5\r\n6 4 4 1",
                "1 1 1 6\r\n1 2 1 8\r\n2 2 2 7"
            };
            expected = "SOLUTION=None";
            expectedAll = new string[input.Length];
            for(var i = 0;i < input.Length; i++)
            {
                expectedAll[i] = expected;
            }
            answer = new string[input.Length];
        };

        Because of = () =>
        {
            for (var i = 0; i < input.Length; i++)
            {
                answer[i] = linearSystem.Solve(input[i]);
            }
        };

        It Should_Return_Expected = () =>
        {
            for (var i = 0; i < answer.Length; i++)
            {
                answer[i].ShouldEqual(expected);
            }
        };

        It Should_Return_All_Expected = () => answer.ShouldEqual(expectedAll);

        private static string[] input;
        private static string[] answer;
        private static string expected;
        private static string[] expectedAll;
    }

    public class When_Using_EchelonForm_It_Returns_Array_In_Variable_Order: With_A_Linear_System
    {
        Establish context = () =>
        {
            input = new decimal[][] { new decimal[] { 2, 1, 3, 14 }, new decimal[] { 1, -5, 2, 3 }, new decimal[] { -5, 1, 0, -9 } };
            expected = new decimal[][] { new decimal[] { 1, 0, 0, 2 }, new decimal[] { 0, 1, 0, 1 }, new decimal[] { 0, 0, 1, 3 } };
        };

        Because of = () => answer = linearSystem.EchelonForm(input);

        It Should_Return_A_Jagged_Decimal_Array = () => answer.ShouldBeOfExactType<decimal[][]>();
        It Should_Return_Expected_Answer = () =>
        {
            for(var i=0; i<answer.Length; i++)
            {
                for (var j = 0; j < answer[i].Length; j++)
                {
                    answer[i][j] = answer[i][j] == 0 ? 0 : Decimal.Parse(answer[i][j].ToString("######.######"));
                    answer[i][j].ShouldEqual(expected[i][j]);
                }
            }
        };

        private static decimal[][] input;
        private static decimal[][] answer;
        private static decimal[][] expected;
    }

    public class When_Rounding_A_Decimal_To_Significan_Digits
    {
        Establish context = () =>
        {
            input = new decimal[]
            {
                01.35700M,
                00.9999999M,
                0010.000M,
                0,
                1.112112113M
            };

            expect = new string[]
            {
                "1.357",
                "1",
                "10",
                "0",
                "1.112112"
            };

            answer = new string[input.Length];
        };

        Because of = () =>
        {
            for (var i = 0; i < input.Length; i++)
            {
                answer[i] = RoundDecimal(input[i]);
            }
        };

        private static string RoundDecimal(decimal input)
        {
            var inputString = input.ToString("####.######");
            //var trimmedInput = inputString.TrimEnd('0').TrimEnd('.');
            var outputStringOrZero = inputString != "" ? inputString : "0";
            return outputStringOrZero;
        }

        It Should_Return_Expected = () =>
        {
            for (var i = 0; i < expect.Length; i++)
            {
                answer[i].ShouldEqual(expect[i]);
            }
        };

        private static decimal[] input;
        private static string[] expect;
        private static string[] answer;
    }

    public class When_Checking_The_Answer: With_A_Linear_System
    {
        Establish context = () =>
        {
            inputSystem = new decimal[][][]
            {
                new decimal[][]{
                    new decimal[] {1,1,1,6},
                    new decimal[] {1,2,1,8},
                    new decimal[] {2,2,2,7}
                },
                new decimal[][]
                {
                    new decimal[]{ 2, 3, 2, 14},
                    new decimal[]{ 1, 4, 2, 15},
                    new decimal[]{ 2, - 3, 1, - 1 }
                }
            };
            inputTestAnswers = new decimal[][]
            {
                new decimal[]
                {
                    1.5M,2M,2.5M
                },
                new decimal[] 
                {
                    1, 2, 3
                }
            };
            expected = new bool[]
            {
                false,
                true
            };
            answer = new bool[inputSystem.Length];
        };

        Because of = () =>
        {
            for (var i = 0; i < inputSystem.Length; i++)
            {
                answer[i] = linearSystem.CheckAnswer(inputSystem[i], inputTestAnswers[i]);
            }

        };

        It Should_Return_True_If_Solution_Exists_Otherwise_False = () =>
        {
            for(var i = 0;i < inputSystem.Length; i++)
            {
                answer[i].ShouldEqual(expected[i]);
            }
        };

        private static decimal[][][] inputSystem;
        private static decimal[][] inputTestAnswers;
        private static bool[] expected;
        private static bool[] answer;
    }
}