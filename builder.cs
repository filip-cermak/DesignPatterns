interface IBuilder
{
    void BuildPartA();
    void BuildPartB();
    Product GetResult();
}

public class Director
{
    public Construct(IBuilder builder)
    {
        builder.BuildPartA();
        builder.BuildPartB();
        builder.BuildPartB();
    }
}

class Builder : IBuilder
{
    private Product product = new Product();
    public void BuildPartA()
    {
        product.Add("PartA");
    }

    public void BuildPartB()
    {
        product.Add("PartB");
    }

    public Product GetResult()
    {
        return product;
    }
}

class Builder2 : IBuilder
{
    private Product product = new Product();
    pubic void BuildPartA()
    {
        product.Add("PartX");
    }
    public void BuildPartB()
    {
        product.Add("PartY");
    }
    public Product GetResult()
    {
        return product;
    }
}

class Product
{   
    List <string> parts = new List <string> ();

    public void Add(string part)
    {
        parts.Add(part);
    }

    public void Display()
    {
        Console.WriteLine("\n Product Parts -------");
        foreach (string part in parts)
        {
            Console.Write(part);
        }
    }

    public class Client()
    {
    IBuilder b1 = new Builder();
    Director dir = Director();
    dir.Construct(b1);

    Product p1 = b1.GetResult();
    p1.Display();
    }

}