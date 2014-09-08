using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIT_CS {
    /// <summary>
    /// An exception used to indicate a problem with how
    /// a HashTable instance is being accessed
    /// </summary>
    public class NonExistentKey<Key> : Exception {
        /// <summary>
        /// The key that caused this exception to be raised
        /// </summary>
        public Key BadKey { get; private set; }

        /// <summary>
        /// Create a new instance and save the key that
        /// caused the problem.
        /// </summary>
        /// <param name="k">
        /// The key that was not found in the hash table
        /// </param>
        public NonExistentKey(Key k) :
            base("Non existent key in HashTable: " + k) {
            BadKey = k;
        }
    }
}

