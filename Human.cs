using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    public class Human
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }
        public string Description { get; set; }

        public Human(int id, string name, string surename, string description = null)
        {
            Id = id;
            Name = name;
            Surname = surename;
            Description = description;
        }


    }
}
