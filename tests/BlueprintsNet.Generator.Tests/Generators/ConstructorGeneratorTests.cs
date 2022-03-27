using System;
using System.Linq;
using BlueprintsNet.Core;
using BlueprintsNet.Generator.Generators;

namespace BlueprintsNet.Generator.Tests.Generators;

[TestFixture(TestOf = typeof(ConstructorGenerator))]
public class ConstructorGeneratorTests
{
    private IBlueprintGenerator _bpGenerator;
    private ConstructorGenerator _subject;

    [SetUp]
    public void SetUp()
    {
        _bpGenerator = A.Fake<IBlueprintGenerator>(options => options.Strict());

        // _subject = new ConstructorGenerator(_bpGenerator);
    }
}
