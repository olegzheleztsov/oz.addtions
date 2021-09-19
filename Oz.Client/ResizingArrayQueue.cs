using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Oz.Client
{
    public class ResizingArrayQueue<T> : IEnumerable<T>
    {
        private int _headIndex = -1;
        private T[] _items = new T[1];
        private int _tailIndex;

        private int _shiftCalls = 0;
        private int _resizeCalls = 0;
        
        private int Size
        {
            get
            {
                if (_headIndex == -1)
                {
                    return 0;
                }

                return _tailIndex - _headIndex;
            }
        }

        public bool IsEmpty => Size == 0;

        public IEnumerator<T> GetEnumerator()
        {
            if (!IsEmpty)
            {
                for (var i = _headIndex; i < _tailIndex; i++)
                {
                    yield return _items[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();

        public string GetStructureString(bool includeContents = true)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Size: {Size}, Capacity: {_items.Length}, Head: {_headIndex}, Tail: {_tailIndex}, Shifts: {_shiftCalls}, Resizes: {_resizeCalls}");
            if (includeContents)
            {
                sb.AppendLine($"Contents: [{string.Join(' ', this)}]");
            }

            return sb.ToString();
        }

        private void ShiftToStart()
        {
            _shiftCalls++;
            
            if (_headIndex == 0)
            {
                if (IsEmpty)
                {
                    _headIndex = -1;
                    _tailIndex = 0;
                }

                return;
            }
            
            var shiftedCount = 0;
            for (int i = _headIndex, insertIndex = 0; i < _tailIndex; i++, insertIndex++)
            {
                _items[insertIndex] = _items[i];
                shiftedCount++;
            }

            if (shiftedCount > 0)
            {
                _headIndex = 0;
                _tailIndex = shiftedCount;
            }
            else
            {
                _headIndex = -1;
                _tailIndex = 0;
            }
        }

        private void Resize(int newSize)
        {
            _resizeCalls++;
            if (IsEmpty)
            {
                if (_items.Length > 1)
                {
                    _items = new T[1];
                }

                _headIndex = -1;
                _tailIndex = 0;
                return;
            }

            var newArray = new T[newSize];
            var insertCount = 0;
            for (int i = _headIndex, insertIndex = 0; i < _tailIndex; i++, insertIndex++)
            {
                newArray[insertIndex] = _items[i];
                insertCount++;
            }

            _items = newArray;
            _headIndex = 0;
            _tailIndex = insertCount;
        }

        public void Enqueue(T item)
        {
            if (IsEmpty)
            {
                _headIndex = 0;
                _items[_headIndex] = item;
                _tailIndex = 1;
                return;
            }

            if (_tailIndex == _items.Length)
            {
                if (Size < _items.Length)
                {
                    ShiftToStart();
                }
                else
                {
                    Resize(_items.Length * 2);
                }
            }

            _items[_tailIndex++] = item;
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            var item = _items[_headIndex++];
            if (Size < _items.Length / 4)
            {
                Resize(_items.Length / 2);
            }

            return item;
        }
    }
}