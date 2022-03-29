
namespace BlueprintsNet.Generator.Generators
{
    internal partial class BlueprintGenerator : BlueprintGeneratorBase
    {
        private readonly Dictionary<IBlueprint, string> _generatedBlueprints;

        public BlueprintGenerator()
        {
            _generatedBlueprints = new Dictionary<IBlueprint, string>();
        }

        public override void Reset()
        {
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

            var builder = new StringBuilder();

            var in1 = values[0].Evaluate(this);

            builder.Append($"({in1} ");

            Array.ForEach(values[1..], input =>
            {
                var gen = input.Evaluate(this);

                builder.Append($"{@operator} {gen}");
            });

            builder.Append(')');

            return builder.ToString();
        }

        private void AddGenerated(IBlueprint bp, string value)
        {
            _generatedBlueprints.Add(bp, value);
        }

        private bool IsGenerated(IBlueprint bp, out string? generatedValue)
        {
            return _generatedBlueprints.TryGetValue(bp, out generatedValue);
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
