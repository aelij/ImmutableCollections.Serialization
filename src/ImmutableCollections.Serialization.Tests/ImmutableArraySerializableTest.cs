using System.Collections.Immutable;
using System.Linq;
using Xunit;

namespace ImmutableCollections.Serialization.Tests
{
    public sealed class ImmutableArraySerializableTest : TestBase
    {
        private ImmutableArray<int> Data => ImmutableArray.CreateRange(Enumerable.Range(0, 10));

        [Fact]
        public void DataContract()
        {
            AssertDataContractSerialization<ImmutableArraySerializable<int>, ImmutableArray<int>, int>(Data);
        }

        [Fact]
        public void Json()
        {
            AssertJsonSerialization<ImmutableArraySerializable<int>, ImmutableArray<int>, int>(Data);
        }
    }
}