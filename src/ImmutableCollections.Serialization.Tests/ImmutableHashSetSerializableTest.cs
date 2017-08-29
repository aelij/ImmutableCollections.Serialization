using System.Collections.Immutable;
using System.Linq;
using Xunit;

namespace ImmutableCollections.Serialization.Tests
{
    public sealed class ImmutableHashSetSerializableTest : TestBase
    {
        private ImmutableHashSet<int> Data => ImmutableHashSet.CreateRange(Enumerable.Range(0, 10));

        [Fact]
        public void DataContract()
        {
            AssertDataContractSerialization<ImmutableHashSetSerializable<int>, ImmutableHashSet<int>, int>(Data);
        }

        [Fact]
        public void Json()
        {
            AssertJsonSerialization<ImmutableHashSetSerializable<int>, ImmutableHashSet<int>, int>(Data);
        }
    }
}