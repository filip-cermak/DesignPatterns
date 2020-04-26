using System;
					
public class Program
{

	public interface IComponent
	{
    	string Operation();
	}

	public class Component : IComponent
	{
		public Component()
		{
		}
		
    	public string Operation()
    	{
        	return "this is a basic component";
    	}
	}

	public class Decorator : IComponent
	{
    	private IComponent comp;
    	public string AddedState = " and added state";

    	public Decorator(IComponent c)
    	{
        	comp = c;
    	}

    	public string Operation()
    	{
        	return comp.Operation() + " with decorator";
    	}

    	public string AddedBehaviour()
    	{
        	return " and added behaviour";
    	}
	}
	
	public static void Main()
	{
		Console.WriteLine("Hello World");
		IComponent comp = new Component();
		Console.WriteLine(comp.Operation());
		Decorator comp2 = new Decorator(comp);
		Console.WriteLine(comp2.Operation() + comp2.AddedBehaviour() + comp2.AddedState);
	}
}