using System;
using System.Linq;
using BlueprintsNet.Generator.Generators;

namespace BlueprintsNet.Generator.Tests.Generators;

[TestFixture(TestOf = typeof(ConstructorGenerator))]
public class ConstructorGeneratorTests
{
    private ConstructorGenerator _subject;

    [SetUp]
    public void SetUp()
    {
        _subject = new ConstructorGenerator();
    }
}
