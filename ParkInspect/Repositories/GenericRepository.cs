using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.Repositories
{
    public class GenericRepository<T>
    {
        private class Node
        {
            public Node(T t)
            {
                next = null;
                data = t;
            }
            private Node next;
            public Node Next
            {
                get { return next; }
                set { next = value; }
            }
            
            private T data;
            
            public T Data
            {
                get { return data; }
                set { data = value; }
            }
        }
        private Node head;
        
        public GenericRepository()
        {
            head = null;
        }
        
        public void Create(T t)
        {
            Node n = new Node(t);
            n.Next = head;
            head = n;
        }

        public bool Update(T oldT, T newT)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(oldT))
                {
                    current.Data = newT;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public bool Delete(T t)
        {
            Node current = head;
            if (current.Data.Equals(t))
            {
                head = current.Next;
                return true;
            }
            while (current.Next != null)
            {
                if (current.Next.Data.Equals(t))
                {
                    current.Next = current.Next.Next;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetAll()
        {
            Node current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
