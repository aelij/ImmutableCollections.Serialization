using System.Collections.Immutable;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ImmutableCollections.Serialization.Tests
{
    public sealed class ImmutableSortedDictionarySerializableTest : TestBase
    {
        private ImmutableSortedDictionary<string, int> Data => ImmutableSortedDictionary.CreateRange(Enumerable.Range(0, 10).ToDictionary(x => x.ToString()));

        [Fact]
        public void DataContract()
        {
            AssertDataContractSerialization<ImmutableSortedDictionarySerializable<string, int>, ImmutableSortedDictionary<string, int>, KeyValuePair<string, int>>(Data);
        }

        [Fact]
        public void Json()
        {
            AssertJsonSerialization<ImmutableSortedDictionarySerializable<string, int>, ImmutableSortedDictionary<string, int>, KeyValuePair<string, int>>(Data);
        }
    }
}