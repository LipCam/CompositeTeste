using System;
using System.Collections.Generic;

namespace CompositeTeste
{
    // Component
    interface IFileSystemItem
    {
        void Print(string indent);
    }

    // Leaf
    class File : IFileSystemItem
    {
        private string _name;

        public File(string name)
        {
            _name = name;
        }

        public void Print(string indent)
        {
            Console.WriteLine($"{indent}File: {_name}");
        }
    }

    // Composite
    class Folder : IFileSystemItem
    {
        private string _name;
        private List<IFileSystemItem> _items = new List<IFileSystemItem>();

        public Folder(string name)
        {
            _name = name;
        }

        public void AddItem(IFileSystemItem item)
        {
            _items.Add(item);
        }

        public void Print(string indent)
        {
            Console.WriteLine($"{indent}Folder: {_name}");
            foreach (var item in _items)
            {
                item.Print(indent + "  ");
            }
        }
    }

    class FileComposite
    {
        public void Execute()
        {
            // Creating files
            File file1 = new File("Document.txt");
            File file2 = new File("Image.jpg");
            File file3 = new File("Spreadsheet.xlsx");

            // Creating folders
            Folder rootFolder = new Folder("Root");
            Folder documentsFolder = new Folder("Documents");
            Folder picturesFolder = new Folder("Pictures");

            // Building the hierarchy
            documentsFolder.AddItem(file1);
            picturesFolder.AddItem(file2);

            picturesFolder.AddItem(file2);
            Folder fotosFolder = new Folder("Fotos");
            Folder niverFolder = new Folder("Fotos Aniverario");
            niverFolder.AddItem(new File("Niver 01.png"));
            niverFolder.AddItem(new File("Niver 02.png"));
            fotosFolder.AddItem(niverFolder);
            picturesFolder.AddItem(fotosFolder);

            rootFolder.AddItem(documentsFolder);
            rootFolder.AddItem(picturesFolder);
            rootFolder.AddItem(file3); // Adding a file directly to the root

            // Displaying the hierarchy
            Console.WriteLine("File System Hierarchy:");
            rootFolder.Print("");
            Console.ReadKey();
        }
    }
}
