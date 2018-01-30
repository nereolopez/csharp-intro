using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            // About Types
            TypesSamples();

            // About Control Flow
            ControlFlowSamples();

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
    }
}
