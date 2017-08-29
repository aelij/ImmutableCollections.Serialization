using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ImmutableCollections.Serialization
{
    public sealed class ImmutableStackSerializable<T> : ICollection<T>, ICollectionSerializable<ImmutableStack<T>, T>
    {
        private ImmutableStack<T> _value;

        private int _count;

        public ImmutableStack<T> Value
        {
            get { return _value ?? (_value = ImmutableStack<T>.Empty); }
            set { _value = value; }
        }

        public IEnumerator<T> GetEnumerator() =>
            (_value ?? Enumerable.Empty<T>()).Reverse().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public ImmutableStackSerializable<T> Clone() => new ImmutableStackSerializable<T> { Value = _value };

        void ICollection<T>.Add(T item)
        {
            _value = Value.Push(item);
            ++_count;
        }

        int ICollection<T>.Count => _count;

        bool ICollection<T>.IsReadOnly => false;

        #region Not supported

        void ICollection<T>.Clear() => throw new NotSupportedException();

        bool ICollection<T>.Contains(T item) => throw new NotSupportedException();

        void ICollection<T>.CopyTo(T[] array, int arrayIndex) => throw new NotSupportedException();

        bool ICollection<T>.Remove(T item) => throw new NotSupportedException();

        #endregion
    }
}
