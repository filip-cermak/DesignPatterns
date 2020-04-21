//Singleton
// - single private, paramaterless constructor - this prevents other classes from instantiating it 
// - prevents subclassing
// - class is sealed (cannot be inherited)
// - a static variable which holds a reference to the single created instance, if any
// - (static method - belongs to class, not object)

//1. Not Thread safe! 2 different threads could both evaluate the test (instance==null) and create new instances

public sealed class Singleton
{
	private static Singleton instance=null;
	
	private Singleton()
	{
	}
	
	public static Singleton Instance
	{
		get
		{
			if(instance==null)
			{
				instance = new Singleton()
			}
			return instance;
		}
	}
}

//2. simple thread safety, implementation locks the shared object, could also lock on
//typeof(Singleton), but this could be dangerous - deadlocks + performance issues
//it is better to lock on objects specifically created for this purpose, or which document
//that they are to be locked on for specific purposes (e.g. for waiting/pulsing a queue)
//such  objects should be private to the class in which are used 

public sealed class Singleton
{
	private static Singleton instance = null;
	private static readonly object padlock = new object();
	
	Singleton(){}
	
	public static Instance
	{
		get
		{
			lock(padlock)
			{
				if(instance==null)
				{
					instance = new Singleton();
				}
				return instance;
			}
		}
	}
}

//3. thread-safety using double-check locking (lazy) - downsides:
// - problems in JAVA
// - easy to get wrong
// - 
public sealed class Singleton
{
	private static Singleton instance = null;
	private static readonly object padlock = new object();
	
	Singleton()
	{
	}
	
	public static Singleton Instance
	{
		get
		{
			if(instance == null)
			{
				lock(padlock)
				{
					if(instance == null)
					{
						instance = new Singleton();
					}
				}
			}
			return instance;
		}
	}
}
	
//4. not quite as lazy, but thread safe without using locks
//

public sealed class Singleton
{
	private static readonly Singleton instance = new Singleton();
	
	//Explicit static constructor to tell C# compiler
	//not to mark type as beforefieldinit
	static Singleton()
	{
	}
	
	private Singleton()
	{
	}
	
	public static Singleton Instance
	{
		get
		{
			return instance;
		}
	}
}

//5. fully lazy instantiating
public sealed class Singleton
{
	private Singleton()
	{
	}
	
	public static Singleton Instance { get { return Nested.instance; }}
	
	private class Nested
	{
		//Explicit static constructor to tell C# compiler
		//not to mark type as beforefieldinit
		static Nested()
		{
		}
		
		internal static readonly Singleton instance = new Singleton();
		{
		}
	
	}
}

//6. fully lazy implementation using .NET4
public sealed class Singleton
{
	private static readonly Lazy<Singleton>
		lazy = 
		new Lazy<Singleton>
			(() => new Singleton());
			
			public static Singleton Instance { get { return lazy.Value} }
			
			private Singleton()
			{
			}
			
}

