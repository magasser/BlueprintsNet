using System;
using System.Linq;

namespace BlueprintsNet.Core.Services;

public interface ISerializerService
{
    string Serialize<T>(T value);

    T Deserialize<T>(string value);
}
