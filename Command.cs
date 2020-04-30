using System;

namespace DesignPatterns.Command
{
    public interface ICommand
    {
        void Execute(); 
    }
    class SimpleComand : ICommand
    {
        private string _payload = string.Empty;
        public SimpleComand(string payload)
        {
            this._payload = payload;
        }
        public void Execute()
        {
            Console.WriteLine($"SimpleCommand: I can do simple things like printing ({this._payload})");
        }
    }

    class ComplexCommand : ICommand
    {
        private Receiver _receiver;

        private string _a;
        private string _b;

        public ComplexCommand(Receiver receiver, string a, string b)
        {
            this._receiver = receiver;
            this._a=a;
            this._b=b;
        }

        public void Execute()
        {
            Console.WriteLine("ComplexCommand: Complex stuff should be done by a receiver object");
            this._receiver.DoSomething(this._a);
            this._receiver.DoSomethingElse(this._b);
        }
    }

    class Receiver
    {
        public void DoSomething(string a)
        {
            Console.WriteLine($"Receiver: working on ({a}.)");
        }

        public void DoSomethingElse(string b)
        {
            Console.WriteLine($"Receiver: Also working on ({b}.)");
        }
    }

    class Invoker
    {
        private ICommand _onStart;
        private ICommand _onFinish;

        public void SetOnFinish(ICommand command)
        {
            this._onFinish = command;
        }

        public void SetOnStart(ICommand command)
        {
            this._onStart = command;
        }

        public void DoSomethingImportant()
        {
            Console.WriteLine("Invoker: Does anybody want something done before I begin?");
            if(this._onStart is ICommand)
            {
                this._onStart.Execute();
            }

            Console.WriteLine("Invoker: ... doing something really important");
            Console.WriteLine("Invoker: Does anybody want something done after I finish?");

            if(this._onFinish is ICommand)
            {
                this._onFinish.Execute();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Invoker invoker1= new Invoker();
            invoker.SetOnStart(new SimpleComand("Say Hi!"));
            Receiver receiver = new Receiver();
            invoker1.SetOnFinish(new ComplexCommand(receviver, "Send email", "Save report"));

            invoker1.DoSomethingImportant();
        }
    }
}