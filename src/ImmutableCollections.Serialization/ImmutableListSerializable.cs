using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ImmutableCollections.Serialization
{
    public sealed class ImmutableListSerializable<T> : ICollection<T>, ICollectionSerializable<ImmutableList<T>, T>
    {
        private readonly ImmutableList<T>.Builder _builder = ImmutableList.CreateBuilder<T>();

        private ImmutableList<T> _value;

        public ImmutableList<T> Value
        {
            get { return _value ?? (_value = _builder.ToImmutable()); }
            set { _value = value; }
        }

        public ImmutableList<T>.Enumerator GetEnumerator()
        {
            return _value?.GetEnumerator() ?? _builder.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        public ImmutableListSerializable<T> Clone() => new ImmutableListSerializable<T> { Value = Value };

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