using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIT_CS {
    /// <summary>
    /// Class that tests the various functionalities
    /// of the program
    /// </summary>
    /// 
    public class TestTable {
        /// <summary>
        /// Function that takes various kinds of inputs and tests
        /// if the output is as expected.
        /// </summary>
        public static void Test() {
            ///Initialize the table with the capacity of 10 and LoadFactor of .75
            Table<int, String> TT = TableFactory.Make<int, String>(10, 0.75);
            ///Initially add only 7 entries,the table should not rehash as 
            ///less than 8 (.75*10) entries are being added
            TT.Put(94706, "Albany");
            TT.Put(94930, "Fairfax");
            TT.Put(90813, "Long Beach");
            TT.Put(90013, "Los Angeles");
            TT.Put(92122, "San Diego");
            TT.Put(95052, "Santa Clara");
            TT.Put(94087, "Sunnyvale");

            ///Get the values associated with the key 94930. 
            ///The expected output should be Fairfax which is the 
            ///expected output

            Console.Write("94930 -> ");
            Console.WriteLine(TT.Get(94930));

            ///Now add more values. The table will increase in size and 
            ///rehash.
            TT.Put(78701, "Austin");
            TT.Put(77429, "Cypress");
            TT.Put(77002, "Houston");

            ///Check if after rehashing the same value is obtained for
            ///the previous key.
            Console.Write("94930 -> ");
            Console.WriteLine(TT.Get(94930));

            ///Also, check the values for other keys
            Console.Write("78701 -> ");
            Console.WriteLine(TT.Get(78701));

            ///Now add a new value with the same key and check if the key is being
            ///replaced. At the same time, add the same values with different keys
            TT.Put(94930, "Rochester");
            TT.Put(77041, "Houston");
            TT.Put(90011, "Los Angeles");

            try {
                ///The key returns the value Rochester instead of FairFax
                ///Thus, the value is replaced if the same key is present
                Console.Write("94930 -> ");
                Console.WriteLine(TT.Get(94930));

                ///This key returns the value Houston even if its already present
                Console.Write("77041 -> ");
                Console.WriteLine(TT.Get(77041));

                ///This key also returns the value Houston
                Console.Write("77002 -> ");
                Console.WriteLine(TT.Get(77002));

                ///This key is not present in the table, thus it throws 
                ///an exception
                Console.Write("14623 -> ");
                Console.WriteLine(TT.Get(14623));
            }

            catch (NonExistentKey<int> nek) {
                Console.WriteLine(nek.Message);
                Console.WriteLine(nek.StackTrace);
            }
        }
    }   
}

