using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIT_CS {
    /// <summary>
    /// Class that implements the interface Table
    /// and defines the Put, Get, Contains and GetEnumerator
    /// </summary>
    /// <typeparam name="Key">The types of the table`s key</typeparam>
    /// <typeparam name="Value">The types of the table`s value</typeparam>
    public class LinkedHashTable<Key, Value> : Table<Key, Value> {
        private int capacity;   ///The initial capacity of the table
        private double LoadFactor;      ///The fraction of the table's capacity that when
                                        /// reached will cause a rebuild of the table to a 50% larger size 

        List<Node<Key, Value>>[] table;      ///Declare an array of list 
        public static int count;        ///Count to keep a count of the number of entries in the table

        ///<summary>
        ///Constructor that takes the capacity and the load factor and consructs
        ///an array of empty lists. It also initialzes the count to 0 since there are no elements 
        ///in the empty table.
        ///</summary>
        ///<param name="capacity">The initial capacity of the table </param>
        ///<param name="Threshold">The fraction of the table's capacity that when reached will cause a rebuild of the table to a 50% larger size</param>>
        public LinkedHashTable(int capacity, double Threshold) {
            this.capacity = capacity;
            LoadFactor = Threshold;
            List<Node<Key, Value>>[] NewTable = new List<Node<Key, Value>>[capacity];
            table = NewTable;

            for (int i = 0; i < capacity; i++) {
                table[i] = new List<Node<Key, Value>>();
            }
            count = 0;
        }

        /// <summary>
        ///Function that calculates the hash code on the key and inserts the key and the value in the table
        ///if the Key is already present, the value is replaced. If two different keys maps to the same bucket,
        ///lists, a new node is created to hold the key and the value and this node is added to the list and the
        ///hash position in the array. If the number of elements being added to the hash table exceeds the threshold, the 
        ///table is rehashed i.e the size of the hash table is increased by 50%
        /// </summary>
        /// <param name="k"> key in the table</param>
        /// <param name="v">value in the table</param>
        public void Put(Key k, Value v) {

            ///Calculate the hash of the key
            int hash = ComputeHashCode(capacity, k);

            ///If the key is already present,replace the value else create a new node containing the 
            ///key and the value and add to the list at the particular hash position in the array
            ///Also, keep a count of the elements in the hash table.
            if (!Contains(k)) {
                Node<Key, Value> n = new Node<Key, Value>(k, v);
                table[hash].Add(n);
                count++;
            }

            else {
                for (int i = 0; i < table[hash].Count; i++) {
                    if ((table[hash])[i].k.Equals(k)) {
                        (table[hash])[i].v = v;
                        count++;
                    }
                }
            }

            ///If the table reaches its threshold, increase the capacity
            ///of the table by 50%
            if (count > LoadFactor * capacity) {
                Rehash(capacity);
            }
        }

        /// <summary>
        /// Function that checks if the key is already present in 
        /// the table. This function returns true iff the key is present
        /// </summary>
        /// <param name="k">Value of key in the table</param>
        /// <returns>Returns true iff the key is present else returns false</returns>


        public bool Contains(Key k) {
            bool ans = false;     ///Initialize the return value to false
            int hash = ComputeHashCode(capacity, k);     ///Compute the hash code on the key
            ///
            ///For each node in the list, check if the key 
            ///is already present. If the key is already present, return true
            ///else return false
            for (int i = 0; i < table[hash].Count; i++) {
                if ((table[hash])[i].k.Equals(k)) {
                    ans = true;
                }
            }
            return ans;
        }
        /// <summary>
        /// Function that returns the value associated with a given key.
        /// If the key is not present, exception is thrown
        /// </summary>
        /// <param name="k">Key in the table</param>
        /// <returns>returns the value associated with the key</returns>
        public Value Get(Key k) {
            Value v = default(Value);   ///Initialse the value to default value
            int hash = ComputeHashCode(capacity, k);    ///Compute the hash code 

            ///For each list, check if the key is present in the list
            ///if the key is found, return the assocaited value, else throw
            ///an exception
            for (int i = 0; i < table[hash].Count; i++) {
                if ((table[hash])[i].k.Equals(k)) {
                    return (table[hash])[i].v;
                }
            }
            if (v == null) {
                NonExistentKey<Key> Except = new NonExistentKey<Key>(k);
                throw Except;
            }
            return v;
        }

        /// <summary>
        /// Function that increases the size of the table by 
        /// 50% if the threshold is reached and rehashes the old values
        /// based on the new capacity of the table
        /// </summary>
        /// <param name="capacity">the old capacity of the table</param>
        public void Rehash(int capacity) {
            ///Create a new temporary table to contain the old hash table
            List<Node<Key, Value>>[] temp = new List<Node<Key, Value>>[capacity];
            temp = table;       ///Copy the old table in the temporary table

            int NewCapacity = (int)(capacity * 1.5);        ///Increase the capacity of the table by 50%

            ///Create an empty array of lists with the new size                                    
            LinkedHashTable<Key, Value> NewTable = new LinkedHashTable<Key, Value>(NewCapacity, LoadFactor);

            ///For each position in the old table, calculate the hash code of the keys
            ///in each node based on the new capacity and put them in the newly created table
            for (int i = 0; i < temp.Length; i++) {
                for (int j = 0; j < temp[i].Count; j++) {
                    NewTable.Put((temp[i])[j].k, (temp[i])[j].v);
                }
            }
        }

        /// <summary>
        /// Function that traverses the array of lists 
        /// </summary>
        /// <returns>This function returns the key</returns>
        public IEnumerator<Key> GetEnumerator() {
            foreach (List<Node<Key, Value>> l in table) {
                for (int i = 0; i < l.Count; i++) {
                    yield return l[i].k;
                }
            }
        }

        /// <summary>
        /// Function that returns the enumerator that iterates 
        /// through the collection
        /// </summary>
        /// <returns>returns the enumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Function that calculates the hash code on the key based on the 
        /// capacity
        /// </summary>
        /// <param name="capacity">capacity of the table</param>
        /// <param name="k">key in the table</param>
        /// <returns>Absolute value of the hash</returns>
        int ComputeHashCode(int capacity, Key k) {
            return Math.Abs((k.GetHashCode()) % capacity);
        }
    }
}
