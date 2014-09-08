using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIT_CS {

    /// <summary>
    /// Class that forms the node in a list
    /// to store the key along with the value together
    /// </summary>
    /// <typeparam name="Key">The types of the table`s key </typeparam>
    /// <typeparam name="Value">The types of the table`s value</typeparam>
    class Node<Key, Value> {
        public Key k;
        public Value v;

        /// <summary>
        /// Default constructor for creating a node
        /// </summary>
        public Node() {}

        /// <summary>
        /// Constructor that creates a node with the given key
        /// and value.
        /// </summary>
        /// <param name="k">The key in the table</param>
        /// <param name="v">The value in the table</param>

        public Node(Key k, Value v) {
            this.k = k;
            this.v = v;
        }
    }
}

