// Copyright (c) miDiagnostics. All Rights Reserved.

using System.Linq;

namespace Oz.Client
{
    public class ListNode<T>
    {
        public ListNode(T data) => Data = data;
        public T Data { get; }
        
        public ListNode<T> Next { get; set; }

        public override string ToString() =>
            string.Join(' ', this.Enumerate());
    }
}