using System.Collections.Immutable;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ImmutableCollections.Serialization.Tests
{
    public sealed class ImmutableDictionarySerializableTest : TestBase
    {
        private ImmutableDictionary<string, int> Data => ImmutableDictionary.CreateRange(Enumerable.Range(0, 10).ToDictionary(x => x.ToString()));

        [Fact]
        public void DataContract()
        {
            AssertDataContractSerialization<ImmutableDictionarySerializable<string, int>, ImmutableDictionary<string, int>, KeyValuePair<string, int>>(Data);
        }

        [Fact]
        public void Json()
        {
            AssertJsonSerialization<ImmutableDictionarySerializable<string, int>, ImmutableDictionary<string, int>, KeyValuePair<string, int>>(Data);
        }
    }
}