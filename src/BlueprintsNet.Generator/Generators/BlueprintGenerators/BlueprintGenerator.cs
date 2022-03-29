
namespace BlueprintsNet.Generator.Generators
{
    internal partial class BlueprintGenerator : BlueprintGeneratorBase
    {
        private readonly StringBuilder _builder;
        private readonly Dictionary<IBlueprint, string> _generatedBlueprints;

        public BlueprintGenerator()
        {
            _builder = new StringBuilder();
            _generatedBlueprints = new Dictionary<IBlueprint, string>();
        }

        public void Reset()
        {
            _builder.Clear();
            _generatedBlueprints.Clear();
        }

        private string AddOperator(string @operator,
                                   IEnumerable<IIn> inValues)
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

        private void AddGenerated(IBlueprint bp, string value)
        {
            _generatedBlueprints.Add(bp, value);
        }

        private bool IsGenerated(IBlueprint bp, out string? generatedValue)
        {
            return _generatedBlueprints.TryGetValue(bp, out generatedValue);
        }
    }
}
