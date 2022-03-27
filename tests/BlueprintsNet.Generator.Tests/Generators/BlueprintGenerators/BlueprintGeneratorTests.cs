using System;
using System.Linq;
using BlueprintsNet.Core;
using BlueprintsNet.Generator.Generators;
using BlueprintsNet.Core.Models.Blueprints;

namespace BlueprintsNet.Generator.Tests.Generators
{
    [TestFixture(TestOf = typeof(BlueprintGenerator))]
    public class BlueprintGeneratorTests
    {
        private BlueprintGenerator _subject;

        [SetUp]
        public void SetUp()
        {
            _subject = new BlueprintGenerator();
        }

        #region Validation
        [Test]
        public void Given_invalid_arguments_When_Generate_Then_throw_exception()
        {
            // Act
            var nullBlueprintCalls = new List<Func<string>>
            {
                () => _subject.Generate((BPSet)null),
                () => _subject.Generate((BPIf)null),
                () => _subject.Generate((BPField)null),
                () => _subject.Generate((BPPlus)null),
                () => _subject.Generate((BPMethod)null),
                () => _subject.Generate((BPMethodIn)null),
                () => _subject.Generate((BPLogicalAnd)null),
                () => _subject.Generate((BPConstructorIn)null),
                () => _subject.Generate((BPConstructor)null),
                () => _subject.Generate((BPFor)null),
                () => _subject.Generate((BPReturn)null)
            };

            // Assert
            nullBlueprintCalls.ForEach(call => call.Should()
                                                   .ThrowExactly<ArgumentNullException>()
                                                   .WithParameterName("bp"));
        }
        #endregion Validation

        #region Operators
        [Ignore("Cannot fake extension method")]
        [TestCase("test1", "test2", new string[] { }, ExpectedResult = "(test1 && test2)")]
        [TestCase("test1", "test2", new string[] { "test3", "test4" }, ExpectedResult = "(test1 && test2 && test3 && test4)")]
        public string Given_BPLogicalAnd_When_Generate_Then_return_correct_value(string in1,
                                                                                 string in2,
                                                                                 string[] additional)
        {
            // Arrange
            var bp = new BPLogicalAnd();
            var fakeIn1 = A.Fake<IOutValue>(options => options.Strict());
            var fakeIn2 = A.Fake<IOutValue>(options => options.Strict());
            var fakeParent1 = A.Fake<IBlueprint>(options => options.Strict());
            var fakeParent2 = A.Fake<IBlueprint>(options => options.Strict());
            A.CallTo(() => fakeIn1.Parent).Returns(fakeParent1);
            A.CallTo(() => fakeIn1.Parent).Returns(fakeParent1);
            A.CallTo(() => fakeParent1.Generate(A<IBlueprintGenerator>._)).Returns(in1);
            A.CallTo(() => fakeParent2.Generate(A<IBlueprintGenerator>._)).Returns(in2);
            bp.In1.Previous = fakeIn1;
            bp.In2.Previous = fakeIn2;

            additional.ToList()
                .ForEach(value =>
                {
                    var fakeBlueprint = A.Fake<IBlueprint>(options => options.Strict());
                    var fakeBoolIn = new Bool.In(fakeBlueprint);
                    A.CallTo(() => fakeBlueprint.Generate(A<IBlueprintGenerator>._)).Returns(value);
                    bp.AdditionalInputs.Add(fakeBoolIn);
                });

            // Act - Assert
            return _subject.Generate(bp);
        }
        #endregion Operators
    }
}
