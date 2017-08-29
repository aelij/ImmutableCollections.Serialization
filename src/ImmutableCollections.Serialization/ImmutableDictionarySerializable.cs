using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ImmutableCollections.Serialization
{
    public sealed class ImmutableDictionarySerializable<TKey, TValue> : IDictionary<TKey, TValue>, ICollectionSerializable<ImmutableDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>>
    {
        private readonly ImmutableDictionary<TKey, TValue>.Builder _builder = ImmutableDictionary.CreateBuilder<TKey, TValue>();

        private ImmutableDictionary<TKey, TValue> _value;

        public ImmutableDictionary<TKey, TValue> Value
        {
            get { return _value ?? (_value = _builder.ToImmutable()); }
            set { _value = value; }
        }

        public ImmutableDictionary<TKey, TValue>.Enumerator GetEnumerator() =>
            _value?.GetEnumerator() ?? _builder.GetEnumerator();

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> pair)
        {
            if (_value != null) throw new NotSupportedException();

            _builder.Add(pair);
        }

        void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
        {
            if (_value != null) throw new NotSupportedException();

            _builder.Add(key, value);
        }

        TValue IDictionary<TKey, TValue>.this[TKey key]
        {
            get => throw new NotSupportedException();
            set
            {
                if (_value != null) throw new NotSupportedException();

                _builder[key] = value;
            }
        }

        int ICollection<KeyValuePair<TKey, TValue>>.Count => _value?.Count ?? _builder.Count;

        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

        #region Not supported

        void ICollection<KeyValuePair<TKey, TValue>>.Clear() => throw new NotSupportedException();

        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item) => throw new NotSupportedException();

        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => throw new NotSupportedException();

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item) => throw new NotSupportedException();

        bool IDictionary<TKey, TValue>.ContainsKey(TKey key) => throw new NotSupportedException();

        bool IDictionary<TKey, TValue>.Remove(TKey key) => throw new NotSupportedException();

        bool IDictionary<TKey, TValue>.TryGetValue(TKey key, out TValue value) => throw new NotSupportedException();

        ICollection<TKey> IDictionary<TKey, TValue>.Keys => throw new NotSupportedException();

        ICollection<TValue> IDictionary<TKey, TValue>.Values => throw new NotSupportedException();

        #endregion
    }
}