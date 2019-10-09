// --------------------------------------------------------------------------------------------------------------------
// <copyright file=LinkedList.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace DataStructure
{
    using System;
    /// <summary>
    /// LinkedList is a genric type class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class LinkedList<T> where T : IComparable<T>
    {
        /// <summary>
        /// The head is strat node of the linked list chain
        /// </summary>
        Node<T> head = null;
        /// <summary>
        /// Adds the last.
        /// </summary>
        /// <param name="data">The data.</param>
        public void AddLast(T data)
        {
            Node<T> newItem = new Node<T>();
            newItem.data = data;
            if (head == null)
            {
                head = newItem;
                head.next = null;
            }
            else
            {
                Node<T> current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newItem;
                newItem.next = null;
            }
        }
        /// <summary>
        /// Reads all data in Node.
        /// </summary>
        public void ReadAll()
        {
            Node<T> start = head;
            while (start != null)
            {
                Console.Write(start.data +" ");
                start = start.next;
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Deletes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public bool Delete(T item)
        {
            if (head.data.Equals(item))
            {
                head = head.next;
                return true;
            }
            else
            {
                ////taking two nodes for traverse to deletethe node x is for the previous node adress
                ///and y is for next node 
                Node<T> x = head;
                Node<T> y = head.next;
                while (true)
                {
                    if (y == null || y.data.Equals(item))
                    {
                        break;
                    }
                    else
                    {
                        x = y;
                        y = y.next;
                    }
                }
                if (y != null)
                {
                    x.next = y.next;
                    return true;
                }
                else
                    return false;
            }
        }
        /// <summary>
        /// Searches the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public bool Search(T item)
        {
            Node<T> a = head;
            while (a != null)
            {
                if (a.data.Equals(item))
                {
                    return true;
                }
                a = a.next;
            }
            return false;
        }
        /// <summary>
        /// Gets the all data form link list.
        /// </summary>
        /// <returns></returns>
        public string GetLinkLis()
        {
            Node<T> last;
            string data = "";
            if (head == null)
                return null;
            else
            {
                last = head;
                while (last != null)
                {
                    data = data + last.data + " ";
                    last = last.next;
                }
                return data;
            }
        }
        /// <summary>
        /// insert in the sorted Nodes.
        /// </summary>
        /// <param name="item">The item.</param>
        public void SortedInsert(T item)
        {
            Node<T> new_node = new Node<T>();
            Node<T> current;
            /* Special case for head node */
            if (head == null || head.data.CompareTo(new_node.data) >= 0)
            {
                new_node.next = head;
                head = new_node;
            }
            else
            {
                /* Locate the node before  
                point of insertion. */
                current = head;
                while (current.next != null &&
                    current.next.data.CompareTo(new_node.data) < 0)
                    current = current.next;
                new_node.next = current.next;
                current.next = new_node;
            }
        }
    }
}