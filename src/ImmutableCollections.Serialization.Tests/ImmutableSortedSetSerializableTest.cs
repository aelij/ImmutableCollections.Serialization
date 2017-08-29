using System.Collections.Immutable;
using System.Linq;
using Xunit;

namespace ImmutableCollections.Serialization.Tests
{
    public sealed class ImmutableSortedSetSerializableTest : TestBase
    {
        private ImmutableSortedSet<int> Data => ImmutableSortedSet.CreateRange(Enumerable.Range(0, 10));

        [Fact]
        public void DataContract()
        {
            AssertDataContractSerialization<ImmutableSortedSetSerializable<int>, ImmutableSortedSet<int>, int>(Data);
        }

        [Fact]
        public void Json()
        {
            AssertJsonSerialization<ImmutableSortedSetSerializable<int>, ImmutableSortedSet<int>, int>(Data);
        }
    }
}