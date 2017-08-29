using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ImmutableCollections.Serialization
{
    public sealed class ImmutableHashSetSerializable<T> : ICollection<T>, ICollectionSerializable<ImmutableHashSet<T>, T>
    {
        private readonly ImmutableHashSet<T>.Builder _builder = ImmutableHashSet.CreateBuilder<T>();

        private ImmutableHashSet<T> _value;

        public ImmutableHashSet<T> Value
        {
            get { return _value ?? (_value = _builder.ToImmutable()); }
            set { _value = value; }
        }

        public ImmutableHashSet<T>.Enumerator GetEnumerator() =>
            _value?.GetEnumerator() ?? _builder.GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public ImmutableHashSetSerializable<T> Clone() => new ImmutableHashSetSerializable<T> { Value = Value };

        void ICollection<T>.Add(T item)
        {
            if (_value != null) throw new NotSupportedException();

            _builder.Add(item);
        }

        int ICollection<T>.Count => _value?.Count ?? _builder.Count;

        bool ICollection<T>.IsReadOnly => false;

        #region Not supported

        void ICollection<T>.Clear() => throw new NotSupportedException();

        bool ICollection<T>.Contains(T item) => throw new NotSupportedException();

        void ICollection<T>.CopyTo(T[] array, int arrayIndex) => throw new NotSupportedException();

        bool ICollection<T>.Remove(T item) => throw new NotSupportedException();

        #endregion
    }
}