using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList.Core
{
    public class DoublyLinkedList<T>
    {
        private DoubleNode<T>? _head;
        private DoubleNode<T>? _tail;
        private IComparer<T> _comparer;

        public DoublyLinkedList(IComparer<T>? comparer = null)
        {
            _tail = null;
            _head = null;
            _comparer = comparer ?? Comparer<T>.Default!;
        }

        public void InsertAtBeginning(T data)
        {
            var newNode = new DoubleNode<T>(data);

            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                newNode.Next = _head;
                _head.Prev = newNode;
                _head = newNode;
            }
        }

        public void InsertAtEnd(T data)
        {
            var newNode = new DoubleNode<T>(data);

            if (_tail == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                newNode.Prev = _tail;
                _tail = newNode;
            }
        }

        public void Add(T data)
        {
            var newNode = new DoubleNode<T>(data);

            if (_head == null)
            {
                _head = _tail = newNode;
                return;
            }

            if (_comparer.Compare(data!, _head.Data!) <= 0)
            {
                newNode.Next = _head;
                _head.Prev = newNode;
                _head = newNode;
                return;
            }

            if (_comparer.Compare(data!, _tail.Data!) >= 0)
            {
                _tail!.Next = newNode;
                newNode.Prev = _tail;
                _tail = newNode;
                return;
            }

            var current = _head;
            while (current != null)
            {
                if (_comparer.Compare(data!, current.Data!) <= 0)
                {
                    var prev = current.Prev;

                    if (prev != null)
                    {
                        prev.Next = newNode;
                        newNode.Prev = prev;
                    }

                    newNode.Next = current;
                    current.Prev = newNode;

                    if (current == _head)
                        _head = newNode;

                    return;
                }

                current = current.Next;
            }
        }

        public void Reverse()
        {
            if (_head == null || _head == _tail) return;

            var current = _head;
            while (current != null)
            {
                var temp = current.Next;
                current.Next = current.Prev;
                current.Prev = temp;

                current = temp;
            }

            var tmp = _head;
            _head = _tail;
            _tail = tmp;
        }

        public string GetForward()
        {
            var output = string.Empty;
            var current = _head;
            if (current == null) return string.Empty;

            while (current != null)
            {
                output += $"{current.Data} <=> ";
                current = current.Next;
            }
            return output.Substring(0, output.Length - 5);
        }

        public string GetBackward()
        {
            var output = string.Empty;
            var current = _tail;
            if (current == null) return string.Empty;

            while (current != null)
            {
                output += $"{current.Data} <=> ";
                current = current.Prev;
            }
            return output.Substring(0, output.Length - 5);
        }

        public Dictionary<T, int> GetFrequencies()
        {
            var freq = new Dictionary<T, int>();
            var current = _head;
            while (current != null)
            {
                var key = current.Data!;
                if (freq.ContainsKey(key))
                    freq[key]++;
                else
                    freq[key] = 1;

                current = current.Next;
            }
            return freq;
        }

        public List<T> GetModes()
        {
            var freq = GetFrequencies();
            var modes = new List<T>();

            if (freq.Count == 0) return modes;

            int maxFreq = freq.Values.Max();

            if (maxFreq <= 1)
            {
                return modes;
            }

            foreach (var kv in freq)
            {
                if (kv.Value == maxFreq) modes.Add(kv.Key);
            }

            return modes;
        }

        public string GetModesString()
        {
            var modes = GetModes();
            if (modes.Count == 0) return "There are no repeated values";
            return "Moda(s): " + string.Join(", ", modes);
        }

        public string GetFrequencyGraph()
        {
            var freq = GetFrequencies();
            if (freq.Count == 0) return "empty list";

            var orderedKeys = freq.Keys.OrderBy(k => k, _comparer).ToList();

            var sb = new StringBuilder();
            foreach (var key in orderedKeys)
            {
                var keyStr = key?.ToString() ?? "null";
                sb.AppendLine($"{keyStr} {new string('*', freq[key])}");
            }

            return sb.ToString().TrimEnd();
        }

        public bool Exists(T value)
        {
            var current = _head;
            while (current != null)
            {
                if (_comparer.Compare(value!, current.Data!) == 0)
                    return true;
                current = current.Next;
            }
            return false;
        }

        public bool RemoveOne(T value)
        {
            if (_head == null) return false;

            var current = _head;
            while (current != null)
            {
                bool equal;
                if (current.Data == null && value == null)
                    equal = true;
                else if (current.Data == null || value == null)
                    equal = false;
                else
                    equal = _comparer.Compare(value!, current.Data!) == 0;

                if (equal)
                {
                    if (current == _head)
                    {
                        _head = _head.Next;
                        if (_head != null)
                            _head.Prev = null;
                        else
                            _tail = null;
                    }
                    else if (current == _tail)
                    {
                        _tail = _tail.Prev;
                        if (_tail != null)
                            _tail.Next = null;
                        else
                            _head = null;
                    }
                    else
                    {
                        current.Prev!.Next = current.Next;
                        current.Next!.Prev = current.Prev;
                    }

                    current.Next = null;
                    current.Prev = null;

                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
        }
    }
}