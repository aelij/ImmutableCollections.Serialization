using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ImmutableCollections.Serialization
{
    public sealed class ImmutableQueueSerializable<T> : ICollection<T>, ICollectionSerializable<ImmutableQueue<T>, T>
    {
        private ImmutableQueue<T> _value;

        private int _count;

        public ImmutableQueue<T> Value
        {
            get { return _value ?? (_value = ImmutableQueue<T>.Empty); }
            set { _value = value; }
        }

        public ImmutableQueue<T>.Enumerator GetEnumerator() =>
            (_value ?? ImmutableQueue<T>.Empty).GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() =>
            ((IEnumerable<T>)(_value ?? ImmutableQueue<T>.Empty)).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<T>)this).GetEnumerator();

        public ImmutableQueueSerializable<T> Clone() => new ImmutableQueueSerializable<T> { Value = _value };

        void ICollection<T>.Add(T item)
        {
            _value = Value.Enqueue(item);
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
