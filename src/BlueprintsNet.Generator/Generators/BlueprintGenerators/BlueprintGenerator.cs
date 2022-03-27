
namespace BlueprintsNet.Generator.Generators
{
    internal partial class BlueprintGenerator : BlueprintGeneratorBase
    {
        private string AddOperator(string @operator,
                                   IEnumerable<IInValue> inValues)
        {
            @operator.MustNotBeNullOrWhiteSpace();
            inValues.MustNotBeNullOrEmpty();

            var values = inValues.ToArray();

            values.Length
                  .MustBeGreaterThanOrEqualTo(2);

            var builder = new StringBuilder();

            var in1 = values[0].Previous?.Parent.Generate(this) ?? values[0].ConstantValue;

            builder.Append('(')
                   .Append(in1);

            Array.ForEach(values[1..], input =>
            {
                var gen = input.Previous?.Parent.Generate(this) ?? input.ConstantValue;

                builder.Append(@operator)
                       .Append(gen);
            });

            builder.Append(')');

            return builder.ToString();
        }
    }
}
