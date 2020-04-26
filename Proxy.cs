using System;
					
public class SubjectAccesor
{
    public interface ISubject
    {
        string Request();
    }

    private class Subject
    {
        public string Request()
        {
            return "Subject Request" + "Choose left door \n";
        }
    }

    public class Proxy : ISubject
    {
        Subject subject;

        public string Request()
        {
            if(subject == null)
            {
                subject = new Subject();
            }
            return "Proxy: Call to " + subject.Request();
        }
    }

    public class ProtectionProxy : ISubject
    {
        Subject subject;
        string password = "abc";

        public string Authenticate (string supplied)
        {
            if(supplied != password)
                return "Protection Proxy: No acess";
            else 
                subject = new Subject();
                return "Prot Proxy : Authenticated";
        }

        public string Request()
        {
            if(subject==null)
            {
                return "Protection Proxy: Auth first";
            } else
            {
                return "Protextion Proxy: Call to " +
                subject.Request();
            }
        }
    }


	public static void Main()
	{
		ISubject subject = new Proxy();
		Console.WriteLine(subject.Request());

		ProtectionProxy subject2 = new ProtectionProxy();
		Console.WriteLine(subject2.Request());

		Console.WriteLine((subject2 as ProtectionProxy).Authenticate("ac"));
		Console.WriteLine((subject2 as ProtectionProxy).Authenticate("abc"));
		Console.WriteLine(subject2.Request());
	}
    

}