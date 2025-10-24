﻿using System;
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

        public DoublyLinkedList()
        {
            _tail = null;
            _head = null;
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

        public string GetForward()
        {
            var output = string.Empty;
            var current = _head;
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
            while (current != null)
            {
                output += $"{current.Data} <=> ";
                current = current.Prev;
            }
            return output.Substring(0, output.Length - 5);
        }
    }
}