namespace Algorithms.DataStructures.HashTable;



public class HashTableDemo
{
    public static void Demo()
    {
        Console.WriteLine("=== Generic Hash Table Demo ===");
        var hashTable = new HashTable<string, int>();
        
        // Test 1: Insert and Lookup
        hashTable.Insert("Alice", 25);
        hashTable.Insert("Bob", 30);
        
        bool found = hashTable.Lookup("Alice", out int age);
        Console.WriteLine($"Found Alice: {found}, Age: {age}"); // True, 25
        
        // Test 2: Update existing key
        hashTable.Insert("Alice", 26);
        hashTable.Lookup("Alice", out age);
        Console.WriteLine($"Alice's new age: {age}"); // 26
        
        // Test 3: Remove
        bool removed = hashTable.Remove("Bob");
        Console.WriteLine($"Removed Bob: {removed}"); // True
        Console.WriteLine($"Bob exists: {hashTable.ContainsKey("Bob")}"); // False
        
        // Test 4: Trigger resize
        for (int i = 0; i < 15; i++)
        {
            hashTable.Insert($"User{i}", i);
        }
        Console.WriteLine($"User5 exists: {hashTable.ContainsKey("User5")}"); // True
    }
}
