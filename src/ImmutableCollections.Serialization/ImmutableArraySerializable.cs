using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ImmutableCollections.Serialization
{
    public sealed class ImmutableArraySerializable<T> : ICollection<T>, ICollectionSerializable<ImmutableArray<T>, T>
    {
        private readonly ImmutableArray<T>.Builder _builder = ImmutableArray.CreateBuilder<T>();

        private ImmutableArray<T> _value;

        public ImmutableArray<T> Value
        {
            get { return _value.IsDefault ? (_value = _builder.ToImmutable()) : _value; }
            set { _value = value; }
        }

        public IEnumerator<T> GetEnumerator() =>
            (_value.IsDefault ? (IEnumerable<T>)_builder : _value).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public ImmutableArraySerializable<T> Clone() => new ImmutableArraySerializable<T> { Value = Value };

        void ICollection<T>.Add(T item)
        {
            if (_value != null) throw new NotSupportedException();

            _builder.Add(item);
        }

        int ICollection<T>.Count => _value.IsDefault ? _builder.Count : _value.Length;

        bool ICollection<T>.IsReadOnly => false;

        #region Not supported

        void ICollection<T>.Clear() => throw new NotSupportedException();

        bool ICollection<T>.Contains(T item) => throw new NotSupportedException();

        void ICollection<T>.CopyTo(T[] array, int arrayIndex) => throw new NotSupportedException();

        bool ICollection<T>.Remove(T item) => throw new NotSupportedException();

        #endregion
    }
}