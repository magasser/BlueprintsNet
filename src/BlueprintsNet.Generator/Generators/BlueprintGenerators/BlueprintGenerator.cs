
namespace BlueprintsNet.Generator.Generators
{
    internal partial class BlueprintGenerator : BlueprintGeneratorBase
    {
        private readonly StringBuilder _builder;

        public BlueprintGenerator()
        {
            _builder = new StringBuilder();
        }

        private string AddOperator(string @operator,
                                   IEnumerable<IInValue> inValues)
        {
            @operator.MustNotBeNullOrWhiteSpace();
            inValues.MustNotBeNullOrEmpty();

            var values = inValues.ToArray();

            values.Length
                  .MustBeGreaterThanOrEqualTo(2);

            _builder.Clear();

            var in1 = values[0].Previous?.Parent.Generate(this) ?? values[0].ConstantValue;

            _builder.OpenBracket()
                    .Append(in1);

            Array.ForEach(values[1..], input =>
            {
                var gen = input.Previous?.Parent.Generate(this) ?? input.ConstantValue;

                _builder.Append(@operator)
                        .Append(gen);
            });

            _builder.CloseBracket();

            return _builder.ToString();
        }
    }
}
