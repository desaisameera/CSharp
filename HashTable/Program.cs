///Program that implements a chained hash table
///@author Sameera Desai
using System;
using System.Collections.Generic;


namespace RIT_CS {
      
    class MainClass {
        public static void Main(string[] args) {
            Table<String, String> ht = TableFactory.Make<String, String>(4, 0.5);
            ht.Put("Joe", "Doe");
            ht.Put("Jane", "Brain");
            ht.Put("Chris", "Swiss");
            try {
                foreach (String first in ht) {
                    Console.WriteLine(first + " -> " + ht.Get(first));
                }
                Console.WriteLine("=========================");

                ht.Put("Wavy", "Gravy");
                ht.Put("Chris", "Bliss");
                foreach (String first in ht) {
                    Console.WriteLine(first + " -> " + ht.Get(first));
                }
                Console.WriteLine("=========================");
                Console.Write("Jane -> ");
                Console.WriteLine(ht.Get("Jane"));
                Console.Write("John -> ");
                Console.WriteLine(ht.Get("John"));
            }
            catch (NonExistentKey<String> nek) {
                Console.WriteLine(nek.Message);
                Console.WriteLine(nek.StackTrace);
            }

            TestTable.Test();   ///Method for testing various cases
            Console.ReadLine();
        }
    }
}
