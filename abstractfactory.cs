using System;

namespace AbstractFactoryPattern
{
    //Abstract Factory
    //use generics to simplify creation of factories

    interface IFactory<Brand>
        where Brand : IBrand
    {
        IBag CreateBag();
        IShoes CreateShoes();
    }

    //concrete factories (both in the same one)

    class Factory<Brand> : IFactory<Brand>
    where Factory<Brand> : IFactory<Brand>
    {
        public IBag CreateBag()
        {
            return new Bag<Brand>();
        }

        public IShoes CreateShoes()
        {
            return new Shoes<Brand>();
        }
    }

    //Interface IProductA
    interface IBag
    {
        string Material { get; }
    }

    interface IShoes
    {
        int Price { get; }
    }

    //All concrete ProductsA's
    class Bag<Brand> : IBag
    where Brand : IBrand, new()
    {
        private Brand myBrand;
        public Bag()
        {y
            myBrand = new Brand();
        }

        public string Material { get {return myBrand.Material;}}
    }

    //All concrete ProductsB's
    class Shoes<Brand> : IShoes
    where Shoes : IShoes, new()
    {
        private Brand mybrand;
        public Shoes()
        {
            myBrand = new Brand();
        }

        public string Price { get {return myBrand.Price;}}
    }

    //All interface for all Brands
    interface IBrand
    {
        int Price { get; }
        string Material {get;}
    }

    class Gucci : IBrand
    {
        public int Price {get {return 1000;}}
        public string Material {get {return "Crocodile skin";}}
    }

    class Poochy : IBrand
    {
        public int Price {get { return new Gucci().Price/3;}}
        public string Material {get {return "Plastic";}}
    }

    class Groundcover : IBrand 
    {
        public int Price { get {return 2000};}
        public string Material { get {return "South africa Leather";}}
    }

    class Client<Brand>
        where Brand: IBrand, new()
        {
            public void ClientMain() //IFactory<Brand> factory
            {
                IFactory<Brand> factory = new Factory<Brand>();

                IBag bag = factory.CreateBag();
                IShoes shoes factory.CreateShoes();

                Console.Writeline("I bought a Bag which is made from" + bag.Material);
                Console.Writeline("I bought some shoes which cost" + shoes.Price);
            }
        }
    }

    static class Program
    {
        static void Main()
        {
            //Call Client Twice
            new Client<Poochy>().ClientMain();
            new Client<Gucci>().ClientMain();
            new Clien<Groundcover>().ClientMain();
        }
    }
}



