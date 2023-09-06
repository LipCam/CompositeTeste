using System;
using System.Collections.Generic;

namespace CompositeTeste
{
    // Component
    interface IEmployee
    {
        void DisplayInformation(int ident);
    }

    // Leaf
    class Employee : IEmployee
    {
        private string _name;
        private string _position;

        public Employee(string name, string position)
        {
            _name = name;
            _position = position;
        }

        public void DisplayInformation(int ident)
        {
            string identStr = new string(' ', 4 * ident);
            Console.WriteLine($"{identStr}({(ident)})Employee: {_name}, Position: {_position}");
        }
    }

    class Tools : IEmployee
    {
        private string _description;
        private string _category;

        public Tools(string name, string position)
        {
            _description = name;
            _category = position;
        }

        public void DisplayInformation(int ident)
        {
            string identStr = new string(' ', 4 * ident);
            Console.WriteLine($"{identStr}({(ident)})Description: {_description}, Category: {_category}");
        }
    }

    // Composite
    class Group : IEmployee
    {
        private string _groupName;
        private List<IEmployee> _members = new List<IEmployee>();

        public Group(string groupName)
        {
            _groupName = groupName;
        }

        public void AddMember(IEmployee member)
        {
            _members.Add(member);
        }

        public void DisplayInformation(int ident)
        {
            string identStr = new string(' ', 4 * ident);
            //Console.WriteLine();
            Console.WriteLine($"{identStr}({ident})Group: {_groupName}");
            //Console.WriteLine($"{identStr}({ident})Members:");
            foreach (var member in _members)
            {
                member.DisplayInformation(ident + 1);
            }
        }
    }

    class EmployeeComposite
    {
        public void Execute()
        {
            // Creating individual employees
            Employee john = new Employee("John", "Developer");
            Employee jane = new Employee("Jane", "Designer");
            Employee mike = new Employee("Mike", "Manager");
            Employee filipe = new Employee("Filipe", "Tester");

            // Creating groups of employees
            Group organizationGroup = new Group("Organization");

            Group developersGroup = new Group("Developers");
            developersGroup.AddMember(john);
            developersGroup.AddMember(jane);

            organizationGroup.AddMember(developersGroup);
            organizationGroup.AddMember(mike);


            Group testGroup = new Group("Testers");
            testGroup.AddMember(filipe);
            testGroup.AddMember(mike);
            testGroup.AddMember(developersGroup);

            Group tools = new Group("Tools");
            tools.AddMember(new Tools("Furadeira", "Eletrica"));
            tools.AddMember(new Tools("Martelo", "Manual"));
            developersGroup.AddMember(tools);

            //organizationGroup.AddMember(new Employee("Fulano", "doido"));


            organizationGroup.AddMember(testGroup);

            // Displaying information
            //Console.WriteLine("Individual Employees:");
            //john.DisplayInformation(0);
            //jane.DisplayInformation(0);
            //mike.DisplayInformation(0);

            Console.WriteLine("Organization Hierarchy:");
            organizationGroup.DisplayInformation(0);
            Console.ReadKey();
        }
    }
}
