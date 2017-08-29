using System.Collections.Immutable;
using System.Linq;
using Xunit;

namespace ImmutableCollections.Serialization.Tests
{
    public sealed class ImmutableQueueSerializableTest : TestBase
    {
        private ImmutableQueue<int> Data => ImmutableQueue.CreateRange(Enumerable.Range(0, 10));

        [Fact]
        public void DataContract()
        {
            AssertDataContractSerialization<ImmutableQueueSerializable<int>, ImmutableQueue<int>, int>(Data);
        }

        [Fact]
        public void Json()
        {
            AssertJsonSerialization<ImmutableQueueSerializable<int>, ImmutableQueue<int>, int>(Data);
        }
    }
}
