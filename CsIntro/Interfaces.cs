using System;

namespace CsIntro
{
    class Interfaces : IMyInterface, IMySecondInterface
    {
        private int randomNumber;

        public int RandomNumber
        {
            get => this.randomNumber;
        }

        public void InterfaceSample()
        {
            Console.WriteLine("This is a method declared in the interface this class implements");
        }

        public void PropertyFromInterface()
        {
            this.randomNumber = new Random().Next(0, 50);
        }

        public void MethodFromSecond()
        {
            Console.WriteLine("This is a method declared in a second interface that this class implements.");
        }
    }

    interface IMyInterface
    {
        int RandomNumber { get; }
        void InterfaceSample();
    }

    interface IMySecondInterface
    {
        void MethodFromSecond();
    }
}
