using System.Collections.Immutable;
using System.Linq;
using Xunit;

namespace ImmutableCollections.Serialization.Tests
{
    public sealed class ImmutableStackSerializableTest : TestBase
    {
        private ImmutableStack<int> Data => ImmutableStack.CreateRange(Enumerable.Range(0, 10));

        [Fact]
        public void DataContract()
        {
            AssertDataContractSerialization<ImmutableStackSerializable<int>, ImmutableStack<int>, int>(Data);
        }

        [Fact]
        public void Json()
        {
            AssertJsonSerialization<ImmutableStackSerializable<int>, ImmutableStack<int>, int>(Data);
        }
    }
}
