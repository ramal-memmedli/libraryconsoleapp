using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp.Models
{
    public class Person
    {
        private static int _idCounter;
        private static Person[] _people;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }


        public static Person[] People { get { return _people; } }

        static Person()
        {
            _idCounter = 0;
            _people = new Person[0];
        }

        private Person()
        {
            Id = ++_idCounter;
            Array.Resize(ref _people, _people.Length + 1);
            _people[^1] = this;
        }

        public Person(string name, string surname) : this()
        {
            Name = name;
            Surname = surname;
        }
    }
}
