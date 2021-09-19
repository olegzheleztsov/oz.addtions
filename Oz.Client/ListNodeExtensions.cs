// Copyright (c) miDiagnostics. All Rights Reserved.

using System.Collections.Generic;

namespace Oz.Client
{
    public static class ListNodeExtensions
    {
        public static ListNode<T> RemoveLast<T>(this ListNode<T> list)
        {
            ListNode<T> last = null;
            if (list.Next == null)
            {
                return list;
            }

            if (list.Next.Next == null)
            {
                last = list.Next;
                list.Next = null;
                return last;
            }

            var current = list;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }

            last = current.Next;
            current.Next = null;
            return last;
        }

        public static IEnumerable<T> Enumerate<T>(this ListNode<T> list)
        {
            var current = list;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}