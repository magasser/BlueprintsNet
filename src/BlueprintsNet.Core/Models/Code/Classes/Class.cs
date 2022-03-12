using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueprintsNet.Core.Models
{
    public class Class
    {
        public Class(string name, AccessModifier accessModifier)
        {
            Name = name.MustNotBeNullOrWhiteSpace();
            AccessModifier = accessModifier.MustBeValidEnumValue();

            Fields = new List<Field>();
            Constructors = new List<Constructor>();
            Properties = new List<Property>();
            Methods = new List<Method>();
        }

        public string Name { get; set; }

        public AccessModifier AccessModifier { get; set; }

        public List<Field> Fields { get; set; }

        public List<Constructor> Constructors { get; set; }

        public List<Property> Properties { get; set; }

        public List<Method> Methods { get; set; }
    }
}
