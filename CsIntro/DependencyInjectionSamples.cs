namespace CsIntro
{
    class DependencyInjectionSamples
    {
        public void Sample()
        {
            var vEngine = new EngineInV();
            var inlineEngine = new EngineInLine();
            var myRocket = new Rocket(vEngine); // injection by constructor
            myRocket.Engine = inlineEngine; // injection by property
            myRocket.MountEngine(vEngine); // injection by method
        }
    }

    class Rocket
    {
        private IEngine engine;

        public IEngine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }

        public Rocket() {
            // Tightly coupled Code. Here we force the rocket to always create an Inline engine.
            // Consider that maybe it should use a different engine, and that it is not the rocket's responsibility
            // to decide it. In real-life, the engineer will decide which engine should have
            this.engine = new EngineInLine();
        }

        // the dependency (the engine) is injected with an interface, in that way
        // the rocket could receive the most appropiate engine for each moment
        public Rocket(IEngine engine) 
        {

        }

        public void MountEngine(IEngine engine)
        {
            this.engine = engine;
        }
    }

    interface IEngine { }
    class EngineInLine : IEngine { }
    class EngineInV : IEngine { }
}
