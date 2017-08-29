using System.Collections.Generic;

namespace ImmutableCollections.Serialization
{
    /// <summary>
    /// For tests
    /// </summary>
    /// <typeparam name="TCollection"></typeparam>
    internal interface ICollectionSerializable<TCollection, T>
        where TCollection : IEnumerable<T>
    {
        TCollection Value { get; set; }
    }
}