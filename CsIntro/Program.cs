﻿using System;

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

            // About EXCEPTIONS
            ExceptionSamples();

            // About FUNCTIONS
            FunctionSamples();

            // About COLLECTIONS
            CollectionSamples();

            // About LINQ
            LinqSamples();

            // About CLASSES
            ClassesSamples();

            // About ENCAPSULATION
            EncapsulationSamples();

            // About INHERITANCE
            InheritanceSamples();

            // About POLYMORPHISM
            PolymorphismSamples();

            // About INTERFACES
            InterfacesSamples();

            // About FILE SYSTEM
            FileSystemSamples();

            // About ASYNC
            AsyncSamples();

            // About DEPENDENCY INJECTION
            DISamples();

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

        static void ExceptionSamples()
        {
            // CLASS SAMPLES
            var exceptions = new Exceptions();

            // exceptions.WithoutTry(); // Comment this line once shown the example to make sure the app runs.
            exceptions.TryCatch();
            exceptions.TryCatchCatch();
            exceptions.Finally();
            exceptions.ThrowException();
        }

        static void FunctionSamples()
        {
            // CLASS SAMPLES
            var functions = new Functions();

            functions.Greet("Nereo");

            int sum = functions.Add(5, 4);
            Console.WriteLine("This is the sum the method returned: " + sum);
            Console.WriteLine("This is the sum the Expression Body Definition returns: " + functions.ShortcutAdd(5, 4));

            functions.CallFunctionWithOptionalParameters();
            functions.NamedParameters();
            functions.MethodOverloading();
            functions.LocalFunction();

            // CLASS EXERCISES
            var exercises = new FunctionsExercises();
            exercises.Functions();
            exercises.UserProfile();
            exercises.CarSearchBuilder();
        }

        static void CollectionSamples()
        {
            // CLASS SAMPLES
            var collections = new Collections();

            collections.AddingElements();
            collections.IteratingCollections();
            collections.RemoveElement();
            collections.ListInsert();
            collections.ListCapacity();
            collections.Dictionary();
            collections.Queue();
            collections.Stack();

            // CLASS EXERCISES
            var exercises = new CollectionsExercises();
            exercises.ListExercise();
            exercises.FavouriteSites();
        }

        static void LinqSamples()
        {
            // CLASS SAMPLES
            var samples = new LinqSamples();
            samples.FirstLinqSample();
            samples.ForcingQueryExecution();
            samples.Ordering();
            samples.Grouping();
            samples.Joining();
            samples.OperatorMethods();

            // CLASS EXERCISES
            var exercises = new LinqExercises();
            exercises.MonthsWithO();
            exercises.MonthsBySeason();
            exercises.SkipMonthsWithOddDays();
            exercises.StudentsAverage();
        }

        static void ClassesSamples()
        {
            // CLASS SAMPLES
            var samples = new Classes();
            samples.UseClasses();

            // CLASS EXERCISES
            var exercises = new ClassesExercises();
            exercises.BuildUserProfile();
        }

        static void EncapsulationSamples()
        {
            // CLASS SAMPLES
            var samples = new Encapsulation();
        }

        static void InheritanceSamples()
        {
            // CLASS SAMPLES
            var samples = new Inheritance();
            samples.InheritanceSamples();

            // CLASS EXERCISES
            var exercises = new InheritanceExercises();
            exercises.InheritanceExercise();
        }

        static void PolymorphismSamples()
        {
            // CLASS SAMPLES
            var samples = new Polymorphism();
            samples.PolymorphismSample();
        }

        static void InterfacesSamples()
        {
            // CLASS SAMPLES
            var samples = new Interfaces();
            samples.InterfaceSample();
            samples.PropertyFromInterface();
            Console.WriteLine("Property randomly filled implemented from the interface: {0}", samples.RandomNumber);
            samples.MethodFromSecond();

            // CLASS EXERCISES
            var exercises = new InterfaceExercises();
            exercises.PetProgram();
        }

        static void FileSystemSamples()
        {
            // CLASS SAMPLES
            var samples = new FileSystemSamples();
            samples.CreateDirectory();
            samples.CreateFile();
            samples.WriteIntoFile();
            samples.ReadLinesFromFile();
        }

        static void AsyncSamples()
        {
            var samples = new AsyncSamples();
            samples.InputOutputBoundCode();
            samples.CpuBoundCode();
        }

        static void DISamples()
        {
            var samples = new DependencyInjectionSamples();
            samples.Sample();
        }
    }
}
