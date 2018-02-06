using System;

namespace CsIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            // About Types
            //TypesSamples();

            // About Control Flow
            ControlFlowSamples();

            // About ARRAYS
            ArraySamples();

            Console.ReadKey();
        }

        static void TypesSamples()
        {
            // CLASS SAMPLES
            var types = new Types();

            types.BoolVariables();
            types.CharVariables();
            types.IntVariables();
            types.StringVariables();
            types.UsingStringBuilder();
            types.DateTimeVariables();

            // CLASS EXERCISES
            var exercises = new TypesExercises();
            exercises.BuildUserProfile();
        }

        static void ControlFlowSamples()
        {
            // CLASS SAMPLES
            var flow = new ControlFlow();

            flow.IfStatement();
            flow.IfElseStatement();
            flow.NestedIf();
            flow.IfElseIf();
            flow.LogicalOperators();
            flow.Ternary();
            flow.Switch();
            flow.ForLoop();
            flow.WhileLoop();

            Console.WriteLine("Please press a key to continue...");
            Console.ReadKey();

            // CLASS EXERCISES
            var flowExercises = new ControlFlowExercises();

            flowExercises.BuildUserProfile();
            flowExercises.ForLoop();
            flowExercises.WhileLoop();
        }

        static void ArraySamples()
        {
            // CLASS SAMPLES
            var arrays = new Arrays();
            arrays.ArrayDeclaration();
            arrays.ArrayInitialization();
            arrays.ImplicitlyTyped();
            arrays.DelayedInitialization();
            arrays.SettingGettingValues();
            arrays.Properties();
            arrays.Methods();
            arrays.Loop();
            arrays.Multidimensional();
            arrays.JaggedArrays();

            // CLASS EXERCISES
            var exercises = new ArraysExercises();
            exercises.Months();
            exercises.Students();
        }
    }
}
