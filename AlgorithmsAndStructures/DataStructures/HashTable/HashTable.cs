using System.Drawing;

namespace Algorithms.DataStructures.HashTable;

/*
 * My implementation of generic Hash Table Data Structure
 * Book: Grokking Algorithms (Chapter 5)
 *
 * A generic hash table using separate chaining for collision resolution.
 * Uses an array of linked lists where each bucket contains a chain of nodes.
 * Automatically resizes when load factor exceeds 0.7 to maintain performance.
 *
 * Time Complexity: O(1) average case for insert, lookup, and remove
 */

public class HashTable<TKey, TValue> where TKey : notnull
{
    private const int defaultCapacity = 10;
    private Node<TKey, TValue>[] buckets;
    private int capacity;
    private int count;
    private double loadFactor;
    

    public HashTable()
    {
        capacity = defaultCapacity;
        buckets = new Node<TKey, TValue>[capacity];
        count = 0;
        loadFactor = 0;
    }

    public HashTable(int initialCapacity)
    {
        capacity = initialCapacity;
        buckets = new Node<TKey, TValue>[capacity];
        count = 0;
        loadFactor = 0;
    }

    private int GetBucketIndex(TKey key)
    {
        return Math.Abs(key.GetHashCode()) % buckets.Length;
    }
    

    public bool Lookup(TKey key, out TValue value)
    {
        
        int index = GetBucketIndex(key);
        Node<TKey, TValue> node = buckets[index];

        while (node != null)
        {
            if (node.Key.Equals(key))
            {
                value = node.Value;
                return true;
            }

            node = node.Next;
        }

        value = default!;
        return false;
    }

    public bool ContainsKey(TKey key)
    {
        return Lookup(key, out _);
    }
    
    public void Insert(TKey key, TValue value)
    {
        int index = GetBucketIndex(key);
        Node<TKey, TValue> current = buckets[index];
        
        while (current != null)
        {
            if (current.Key.Equals(key))
            {
                current.Value = value;
                return;
            }
            current = current.Next;
        }
        
        Node<TKey, TValue> newNode = new Node<TKey, TValue>(key, value);
        newNode.Next = buckets[index]; 
        buckets[index] = newNode;

        count++;
        loadFactor = (double) count / capacity;

        if (loadFactor > 0.7)
        {
            Resize();
        }
    }

    private void Resize()
    {
        Node<TKey, TValue>[] oldBuckets = buckets;
        capacity *= 2;
        buckets = new Node<TKey, TValue>[capacity];
        count = 0;
        
        for (int i = 0; i < oldBuckets.Length; i++)
        {
            Node<TKey, TValue> current = oldBuckets[i];
            while (current != null)
            {
                Insert(current.Key, current.Value);
                current = current.Next;
            }
        }
    }

    public bool Remove(TKey key)
    {
        int index = GetBucketIndex(key);
        Node<TKey, TValue> current = buckets[index];

        if (current == null) return false;
        
        if (current.Key.Equals(key))
        {
            buckets[index] = current.Next;
            
            count--;
            loadFactor = (double) count / capacity;
            return true;
        }
        
        while (current.Next != null)
        {
            if (current.Next.Key.Equals(key))
            {
                current.Next = current.Next.Next;
                
                count--;
                loadFactor = (double) count / capacity;
                return true;
            }

            current = current.Next;
        }

        return false;
    }
    

    public void Clear()
    {
        for (int i = 0; i < buckets.Length; i++)
        {
            buckets[i] = null;
        }
        count = 0;
    }

}