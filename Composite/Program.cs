using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    //Component
    abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public virtual void Add(Component c)
        {
            Console.WriteLine("Cannot add");
        }

        public virtual void Remove(Component c)
        {
            Console.WriteLine("Cannot remove");
        }

        public abstract void Display(int depth);
    }

    //Composite
    class Directory: Component
    {
        private List<Component> children = new List<Component>();

        public Directory(string name) : base(name) { }

        public override void Add(Component component)
        {
            children.Add(component);
        }

        public override void Remove(Component component)
        {
            children.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);

            foreach (Component component in children)
            {
                component.Display(depth + 2);
            }
        }
    }
    
    //Leaf
    class File : Component
    {
        public File(string name) : base(name) { }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Component root = new Directory("root");

            root.Add(new File("File A"));
            root.Add(new File("File B"));

            Component comp = new Directory("Folder X");

            comp.Add(new File("File XA"));
            comp.Add(new File("File XB"));
            root.Add(comp);

            Component comp2 = new Directory("Folder Y");

            comp2.Add(new File("File YA"));
            comp2.Add(new File("File YB"));

            Component comp3 = new Directory("Folder Z");
            comp3.Add(new File("File YZA"));
            comp3.Add(new File("File YZB"));
            comp2.Add(comp3);

            root.Add(comp2);

            root.Add(new File("File C"));

            File leaf = new File("File D");
            root.Add(leaf);
            root.Display(0);
        }
    }
}
