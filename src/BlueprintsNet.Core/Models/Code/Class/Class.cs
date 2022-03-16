using System;
using System.Linq;

namespace BlueprintsNet.Core.Models.Code;

public class Class
{
    public Class(string name, AccessModifier accessModifier)
    {
        Name = name.MustNotBeNullOrWhiteSpace();
        AccessModifier = accessModifier.MustBeValidEnumValue();

        Constructors = new List<Constructor>();
        Fields = new List<Field>();
        Methods = new List<Method>();
    }

    public string Name { get; set; }

    public AccessModifier AccessModifier { get; set; }

    public List<Constructor> Constructors { get; }

    public List<Field> Fields { get; }

    public List<Method> Methods { get; }
}
