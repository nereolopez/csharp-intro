using System;
using System.Collections.Generic;

namespace CsIntro
{
    class Polymorphism
    {
        public void PolymorphismSample()
        {
            // We will use the classes below in this file to demonstrate Polymorphism
            var lineTypes = new List<MyLine>();
            lineTypes.Add(new DottedLine()); // Note that we add DottedLine to a List<MyLine>
            lineTypes.Add(new DashedLine()); // which shows that classes can be used interchangeably

            foreach (var line in lineTypes)
            {
                line.Draw();
            }
        }
    }

    class MyLine
    {
        public virtual void Draw()
        {
            Console.WriteLine("There is no generic line defined");
        }
    }

    class DottedLine : MyLine
    {
        public override void Draw()
        {
            Console.WriteLine("......................................");
        }
    }

    class DashedLine : MyLine
    {
        public override void Draw()
        {
            Console.WriteLine("--------------------------------------");
        }
    }
}
