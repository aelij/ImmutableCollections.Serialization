using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using Xunit;

namespace ImmutableCollections.Serialization.Tests
{
    public class TestBase
    {
        internal void AssertDataContractSerialization<TCollection, TInnerCollection, T>(TInnerCollection collection)
            where TCollection : IEnumerable<T>, ICollectionSerializable<TInnerCollection, T>, new()
            where TInnerCollection : IEnumerable<T>
        {
            var holder = new CollectionHolder<TCollection, TInnerCollection, T>(collection);

            var serializer = new DataContractSerializer(typeof(CollectionHolder<TCollection, TInnerCollection, T>));

            using (var stream = new MemoryStream())
            {
                using (var writer = XmlDictionaryWriter.CreateBinaryWriter(stream, null, null, ownsStream: false))
                {
                    serializer.WriteObject(writer, holder);
                }

                stream.Position = 0;

                using (var reader = XmlDictionaryReader.CreateBinaryReader(stream, XmlDictionaryReaderQuotas.Max))
                {
                    var deserializedHolder = (CollectionHolder<TCollection, TInnerCollection, T>)serializer.ReadObject(reader);

                    Assert.Equal(collection.AsEnumerable(), deserializedHolder.Collection);
                }
            }
        }

        internal void AssertJsonSerialization<TCollection, TInnerCollection, T>(TInnerCollection collection)
            where TCollection : IEnumerable<T>, ICollectionSerializable<TInnerCollection, T>, new()
            where TInnerCollection : IEnumerable<T>
        {
            var holder = new CollectionHolder<TCollection, TInnerCollection, T>(collection);

            var json = JsonConvert.SerializeObject(holder);

            var deserializedHolder = JsonConvert.DeserializeObject<CollectionHolder<TCollection, TInnerCollection, T>>(json);

            Assert.Equal(collection.AsEnumerable(), deserializedHolder.Collection);
        }

        [DataContract(Name = "C", Namespace = "N")]
        internal class CollectionHolder<TCollection, TInnerCollection, T>
            where TCollection : IEnumerable<T>, ICollectionSerializable<TInnerCollection, T>, new()
            where TInnerCollection : IEnumerable<T>
        {
            [DataMember]
            private readonly TCollection _collection = new TCollection();

            public TInnerCollection Collection
            {
                get => _collection.Value;
                private set => _collection.Value = value;
            }

            public CollectionHolder(TInnerCollection inner)
            {
                Collection = inner;
            }
        }
    }
}