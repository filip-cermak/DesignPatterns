using System;
					
public class BridgePattern
{
    public class Abstraction
    {
        IBridge bridge;

        public Abstraction(IBridge implementation)
        {
            bridge = implementation;
        }

        public string Operation()
        {
            return "Abstraction" + "  <<<BRIDGE>>>  " + bridge.OperationImp();
        }
    }

    interface IBridge
    {
        string OperationImp();
    }

    class ImplementationA : IBridge
    {
        public string OperationImp()
        {
            return "ImplementationA";
        }
    }

    class ImplementationB : IBridge
    {
        public string OperationImp()
        {
            return "ImplementationB";
        }
    }

    static void Main()
    {
        Console.WriteLine("Bridge Pattern\n");
        Console.WriteLine(new Abstraction(new ImplementationA()).Operation());
        Console.WriteLine(new Abstraction(new ImplementationB()).Operation());
    }
}
        