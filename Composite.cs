using System;
using System.Collections.Generic;
using System.Text; //for StringBuilder

namespace CompositePattern
{
    //the Interface
    public interface IComponent <T>
    {
        void Add(IComponent <T> c);
        IComponent <T> Remove(T s);
        string Display(int depth);
        IComponent <T> Find(T s);
        T Name {get; set;}
    }

    //The Component
    public class Component <T> : IComponent <T> 
    {
        public T Name {get;set;}

        public Component (T name) 
        {
            Name = name;
        }

        public void Add(IComponent <T> c)
        {
            Console.Writeline("Cannot add to and item");
        }

        public IComponent <T> Remove(T s)
        {
            Console.Writeline("Cannot remove directly")
            return this;
        }

        public string Display(int depth)
        {
            return new String('-', depth) + Name+"\n";
        }

        public IComponent <T> Find (T s)
        {
            if (s.Equals(Name))
            {
                return this;
            }
            else
            {
                return null;
            }
        }
    }

    //The Composite
    public class Composite <T> : IComponent <T>
    {
        List <IComponent <T>> list;
        public T Name {get; set;}

        public Composite (T name)
        {
            Name = name;
            list = new list <IComponent <T>> ();
        }

        public void Add(IComponent <T> c)
        {
            list.Add(c);
        }

        IComponent <T> holder = null;

        //Finds the item from a particular point in hte structure
        //and returns the composite from which it was removed
        //If not found, return the point as given

        public IComponent <T> Remove(T s)
        {
            holder = this;
            IComponent <T> p = holder.Find(s);
            if(holder != null)
            {
                (holder as Composite<T>).list.Remove(p);
                return holder;
            }
            else
            {
                return this;
            }
        }

        //Recursively looks for an item
        //Returns its reference or else null
        public IComponent <T> Find (T s)
        {
            holder = this;
            if(Name.Equals(s)) return this;
            IComponent <T> found = null;
            foreach (IComponent <T> c in list) 
            {
                found = c.Find(s);
                if(found!=null)
                    break;
            }
            return found;
        }

        //Displays items in a format indicating their level
        // in the composite structure
        public string Display(int depth)
        {
            StringBuilder s = new StringBuilder(new String('-', depth));
            s.Append("Set " + Name + " length :" + list.Count + "\n");
            foreach (IComponent <T> component in list)
            {
                s.Append(component.Dksplay(depth + 2));
            }
            return s.ToString();
        }
    }
}