using System;

namespace Library
{
    internal class SubsystemA
    {
        internal string A1()
        {
            return "Subsystem A, Method A1\n";
        }
        internal string A2()
        {
            return "Subsystem A, Method A2\n";
        }
    }

    internal class SubsystemB
    {
        internal string B1()
        {
            return "Subsystem B, Method B1\n";
        }
        internal string B2()
        {
            return "Subsystem B, Method B2\n";
        }
    }

    internal class SubsystemC
    {
        internal string C1()
        {
            return "Subsystem B, Method C1\n";
        }

    }
}

public static class Facade
{
    static SubsystemA a = new SubsystemA();
    static SubsystemB b = new SubsystemB();
    static SubsystemC c = new SubsystemC();

    public static void Operation1()
    {
        Console.WriteLine("Operation 1\n" +
            a.A1()+
            a.A2()+
            b.B1());
    }

    public static void Operation2()
    {
        Console.WriteLine("Operation 2\n"+
            b.B1()+
            c.C1());
    }
}

// =========================Different compilation
using System;
using FacadeLib;

class Client
{
    static void Main()
    {
        Facade.Operation1();
        Facade.Operation2();
    }
}
