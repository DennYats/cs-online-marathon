using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint04.Task_3
{
    enum ColourEnum
    {
        Red,
        Green,
        Blue
    }
    interface IColoured
    {
        ColourEnum Colour => ColourEnum.Red;
    }

    interface IDocument
    {
        static string defaultText = "Lorem ipsum";
        public int Pages { get => 0; set => Pages = value; }
        public string Name { get; set; }
        void AddPages(int increment) => Pages += increment;
        void Rename(string name) => Name = name;
    }

    class ColouredDocument : IColoured, IDocument
    {
        string name;
        public string Name { get { return this.name; } set { this.name = value; } }

        int pages;
        public int Pages { get { return this.pages; } set { this.pages = value; } }

        ColourEnum color;
        public ColourEnum Colour { get { return this.color; } set { this.color = value; } }

        public ColouredDocument() { }
        public ColouredDocument(ColourEnum colour)
        {
            color = colour;
        }
    }

    class Example
    {
        public static void Do()
        {
            IDocument doc1 = new ColouredDocument { Name = "Document1" };
            Console.WriteLine(doc1.Name);
            doc1.Rename("Document2");
            Console.WriteLine(doc1.Name);
        }
    }
}