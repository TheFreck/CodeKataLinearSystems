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

    public class When_Solving_Linear_Equations_With_2_Variables : With_A_Linear_System
    {
        Establish context = () =>
        {
            input = new double[,] { { 2, 3, 13 }, { 3, 2, 12 } };
            expected = new double[] { 2, 3 };
        };

        Because of = () => answer = linearSystem.Solve2Vars(input);

        It Should_Return_A_String = () => answer.ShouldBeOfExactType<double[]>();
        It Should_Return_Expected_Answer = () => answer.ShouldEqual(expected);

        private static double[,] input;
        private static double[] answer;
        private static double[] expected;
    }
    public class When_Solving_Linear_Equations_With_3_Variables : With_A_Linear_System
    {
        Establish context = () =>
        {
            input = "1 1 1 6\r\n2 1 3 13\r\n3 2 -1 4";
            expected = new double[] { 1, 2, 3 };
        };

        Because of = () => answer = linearSystem.Solve(input);

        It Should_Return_A_Double_Array = () => answer.ShouldBeOfExactType<double[]>();
        It Should_Return_Expected_Answer = () => answer.ShouldEqual(expected);

        private static string input;
        private static double[] answer;
        private static double[] expected;
    }


    public class When_Identifying_Variables_From_Input : With_A_Linear_System
    {
        Establish context = () =>
        {
            input = "1 2 0 7\r\n0 2 4 8\r\n0 5 6 9";
            expected = new double[,]
            {
                {1,2,0,7},{0,2,4,8},{0,5,6,9}
            };
        };

        Because of = () => variables = linearSystem.FindVariables(input);

        It Should_Return_A_Multi_Dimensional_Array = () => variables.ShouldBeOfExactType<double[,]>();
        It Should_Return_The_Correct_Values = () => variables.ShouldEqual(expected);


        private static string input;
        private static double[,] expected;
        private static double[,] variables;
    }

    public class When_Isolating_X_With_2_Variables : With_A_Linear_System
    {
        Establish context = () =>
        {
            input = new double[] { 1, 2, 7 };
            expected = new double[] { 1, -2, 7 };
            varToIsolate = 0;
        };

        Because of = () => isolatedX = linearSystem.Isolate(input, varToIsolate);

        It Should_Return_A_Double_Array = () => isolatedX.ShouldBeOfExactType<double[]>();
        It Should_Return_The_Correct_Values = () => isolatedX.ShouldEqual(expected);

        private static double[] input;
        private static double[] expected;
        private static int varToIsolate;
        private static double[] isolatedX;
    }

    public class When_Isolating_Y_With_2_Variables : With_A_Linear_System
    {
        Establish context = () =>
        {
            input = new double[] { 1, 2, 7 };
            expected = new double[] { 2, -1, 7 };
            varToIsolate = 1;
        };

        Because of = () => isolatedX = linearSystem.Isolate(input, varToIsolate);

        It Should_Return_A_Double_Array = () => isolatedX.ShouldBeOfExactType<double[]>();
        It Should_Return_The_Correct_Values = () => isolatedX.ShouldEqual(expected);

        private static double[] input;
        private static double[] expected;
        private static int varToIsolate;
        private static double[] isolatedX;
    }

    public class When_Isolating_X_With_3_Variables : With_A_Linear_System
    {
        Establish context = () =>
        {
            input = new double[] { 1, 2, 0, 7 };
            expected = new double[] { 1, -2, 0, 7 };
            varToIsolate = 0;
        };

        Because of = () => isolatedX = linearSystem.Isolate(input, varToIsolate);

        It Should_Return_A_Double_Array = () => isolatedX.ShouldBeOfExactType<double[]>();
        It Should_Return_The_Correct_Values = () => isolatedX.ShouldEqual(expected);

        private static double[] input;
        private static double[] expected;
        private static int varToIsolate;
        private static double[] isolatedX;
    }

    public class When_Isolating_Y_With_3_Variables : With_A_Linear_System
    {
        Establish context = () =>
        {
            input = new double[] { 1, 2, 0, 7 };
            expected = new double[] { 2, -1, 0, 7 };
            varToIsolate = 1;
        };

        Because of = () => isolatedX = linearSystem.Isolate(input, varToIsolate);

        It Should_Return_A_Double_Array = () => isolatedX.ShouldBeOfExactType<double[]>();
        It Should_Return_The_Correct_Values = () => isolatedX.ShouldEqual(expected);

        private static double[] input;
        private static double[] expected;
        private static int varToIsolate;
        private static double[] isolatedX;
    }

    public class When_Isolating_Z_With_3_Variables : With_A_Linear_System
    {
        Establish context = () =>
        {
            input = new double[] { 1, 2, 4, 7 };
            expected = new double[] { 4, -1, -2, 7 };
            varToIsolate = 2;
        };

        Because of = () => isolatedX = linearSystem.Isolate(input, varToIsolate);

        It Should_Return_A_Double_Array = () => isolatedX.ShouldBeOfExactType<double[]>();
        It Should_Return_The_Correct_Values = () => isolatedX.ShouldEqual(expected);

        private static double[] input;
        private static double[] expected;
        private static int varToIsolate;
        private static double[] isolatedX;
    }

    public class When_Reducing_Equations_Through_Eliminating_X_With_3_Variables : With_A_Linear_System
    {
        Establish context = () =>
        {
            input1 = new double[] { 3, 2, 2, 15 };
            input2 = new double[] {2, -1, 3, 18};
            expected = new double[] { 0, 7, -5, -24 };
            varToEliminate = 0;
        };

        Because of = () => output = linearSystem.EliminateVar(input1, input2, varToEliminate);

        It Should_Return_A_Multi_Dimensional_Array = () => output.ShouldBeOfExactType<double[]>();
        It Shouldt_Return_The_Correct_Values = () => output.ShouldEqual(expected);

        private static double[] input1;
        private static double[] input2;
        private static double[] expected;
        private static int varToEliminate;
        private static double[] output;
    }

    public class When_Reducing_Equations_Through_Eliminating_Y_With_3_Variables : With_A_Linear_System
    {
        Establish context = () =>
        {
            input1 = new double[] { 3, 2, 2, 15 };
            input2 = new double[] { 2, -1, 3, 18};
            expected = new double[] { -7, 0, -8, -51};
            varToEliminate = 1;
        };

        Because of = () => output = linearSystem.EliminateVar(input1, input2, varToEliminate);

        It Should_Return_A_Multi_Double_Array = () => output.ShouldBeOfExactType<double[]>();
        It Shouldt_Return_The_Correct_Values = () => output.ShouldEqual(expected);

        private static double[] expected;
        private static int varToEliminate;
        private static double[] output;
        private static double[] input1;
        private static double[] input2;
    }

    public class When_Reducing_Equations_Through_Eliminating_Z_With_3_Variables : With_A_Linear_System
    {
        Establish context = () =>
        {
            input1 = new double[] { 3, 2, 2, 15 };
            input2 = new double[] { 2, -1, 3, 18};
            expected = new double[] { 5, 8, 0, 9 };
            varToEliminate = 2;
        };

        Because of = () => output = linearSystem.EliminateVar(input1, input2, varToEliminate);

        It Should_Return_A_Multi_Dimensional_Array = () => output.ShouldBeOfExactType<double[]>();
        It Shouldt_Return_The_Correct_Values = () => output.ShouldEqual(expected);

        private static double[] expected;
        private static int varToEliminate;
        private static double[] output;
        private static double[] input1;
        private static double[] input2;
    }

    public class When_Reducing_By_X : With_A_Linear_System
    {
        Establish context = () =>
        {
            input = new double[] { 3.0, 5.0, 6.0 };
            expected = new double[] { 3.0 / 3.0, 5.0 / 3.0, 6.0 / 3.0 };
        };

        Because of = () => output = linearSystem.Reduce(input, 0);

        It Should_Return_A_Double_Array = () => output.ShouldBeOfExactType<double[]>();
        It Should_Return_The_Correct_Values = () => output.ShouldEqual(expected);

        private static double[] input;
        private static double[] expected;
        private static double[] output;
    }

    public class When_Reducing_By_Y : With_A_Linear_System
    {
        Establish context = () =>
        {
            input = new double[] { 3.0, 5.0, 6.0 };
            expected = new double[] { 3.0 / 5.0, 5.0 / 5.0, 6.0 / 5.0 };
        };

        Because of = () => output = linearSystem.Reduce(input, 1);

        It Should_Return_A_Double_Array = () => output.ShouldBeOfExactType<double[]>();
        It Should_Return_The_Correct_Values = () => output.ShouldEqual(expected);

        private static double[] input;
        private static double[] expected;
        private static double[] output;
    }


    public class When_Replacing_Variables : With_A_Linear_System
    {
        Establish context = () =>
        {
            inputEq = new double[] { 2, 3, 4 };
            replace = 1.5;
            replaceVar = 0;
            expected = new double[] { 3, 3, 4 };
        };

        Because of = () => output = linearSystem.Replace(inputEq, replace, replaceVar);

        It Should_Return_A_Double_Array = () => output.ShouldBeOfExactType<double[]>();
        It Should_Return_Correct_Values = () => output.ShouldEqual(expected);

        private static double[] inputEq;
        private static double replace;
        private static int replaceVar;
        private static double[] expected;
        private static double[] output;
    }
}