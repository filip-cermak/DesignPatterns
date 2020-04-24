//Simplest Adapter
interface ITarget
{
    void Request();
}

class Adaptee 
{
    void SpecificRequest()
    {
        //do something
    }
}

class Adapter: Adaptee, ITarget
{
    void Request()
    {
        SpecificRequest()
        //do something with the specific request
    }
}

//Pluggable adapter

//Existing way requests are implemented
class Adaptee 
{
    public double Precise (double a, double b)
    {
        return a/b;
    }
}

class Target
{
    public string Estimate (int i)
    {
        return "Estimate is " + (int) Math.Round(i/3.0);
    }
}

//Implementing new requests via old
class Adapter : Adaptee
{
    public Func <int, string> Request;

    //Different constructors for the expected targets/adaptees

    //Adapter - Adaptee
    public Adapter (Adaptee adaptee)
    {
        //Set the delegate to the new standart
        Request = delegate(int i)
        {
            return "Estimate based on precision is " +
            (int) Math.Round(Precise(i,3));
        };
    }

    //Adapter - Target
    public Adapter (Target target)
    {
        //Set the delegate to the existing standard
        Request = target.Estimate;
    }
}

class Client 
{
    static void Main ()
    {
        Adapter adapter1 = new Adapter (new Adaptee());
        Console.WriteLine(adapter1.Request(5));

        Adapter adapter2 = new Adapter (new Target());
        Consnole.WriteLine(adapter2.Request(5));
    }
}

