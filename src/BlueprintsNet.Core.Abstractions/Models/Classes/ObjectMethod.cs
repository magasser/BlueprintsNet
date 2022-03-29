using System;
using System.Linq;

namespace BlueprintsNet.Core.Models.Classes
{
    public class ObjectMethod : Method
    {
        public ObjectMethod(string name,
                            AccessModifier accessModifier,
                            string objectType)
            : base(name, accessModifier, NodeType.Object)
        {
            ObjectType = objectType.MustNotBeNullOrWhiteSpace();
        }

        public string ObjectType { get; set; }
    }
}
