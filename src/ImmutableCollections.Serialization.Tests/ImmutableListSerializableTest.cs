using System.Collections.Immutable;
using System.Linq;
using Xunit;

namespace ImmutableCollections.Serialization.Tests
{
    public sealed class ImmutableListSerializableTest : TestBase
    {
        private ImmutableList<int> Data => ImmutableList.CreateRange(Enumerable.Range(0, 10));

        [Fact]
        public void DataContract()
        {
            AssertDataContractSerialization<ImmutableListSerializable<int>, ImmutableList<int>, int>(Data);
        }

        [Fact]
        public void Json()
        {
            AssertJsonSerialization<ImmutableListSerializable<int>, ImmutableList<int>, int>(Data);
        }
    }
}