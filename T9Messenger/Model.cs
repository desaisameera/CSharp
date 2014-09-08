///class that acts as a model.
///It reads the text file english-words.txt
///and stores the words in a distionary.
///It then sends the list of words to the 
///controller

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPad {
    class Model {
        Dictionary<String, List<String>> wordDictionary = new Dictionary<String, List<String>>();   ///Dictioary to store the words
                                                                                                    ///at particluar key locations
        String key;     ///variable that stores the key
        public Model() {
            ///Read the file and generate the key
            try {
                StreamReader sr = new StreamReader("english-words.txt");
                do {
                    String line = sr.ReadLine();
                    key = generateKey(line);    ///Generate the key

                    List<string> temp;      ///List to store the words at each key value

                    wordDictionary.TryGetValue(key, out temp);
                    if (temp == null) {
                        temp = new List<String>();
                        temp.Add(line);
                        wordDictionary.Add(key, temp);
                    }
                    else {
                        temp.Add(line);
                    }
                } while (sr.Peek() != -1);
            }

            catch (Exception e) {
                Console.WriteLine(e.Message);                
            }
        }

        /// <summary>
        /// Method that sends the list of predicted words to the 
        /// controller
        /// </summary>
        /// <param name="buttonClicks">Buttons clicked so far</param>
        /// <returns>List of predicted words</returns>
        public List<String> Predict(List<string>buttonClicks) {
            List<String> temp = new List<String>();
            string clicks=null;
            
            for (int i = 0; i < buttonClicks.Count();i++) {
                clicks = clicks + buttonClicks[i];
            }

            if(wordDictionary.ContainsKey(clicks)) {
                temp = wordDictionary[clicks];
            }
            return temp;   
        }

        /// <summary>
        /// Method that generates key
        /// </summary>
        /// <param name="line">words in the dictionary</param>
        /// <returns>key</returns>
        String generateKey(String line) {
            char[] _key = new char[line.Length];
            for (int i = 0; i < line.Length; i++) {
                if (line[i] == 'a' || line[i] == 'b' || line[i] == 'c') {
                    _key[i] = '2';
                }
                else if (line[i] == 'd' || line[i] == 'e' || line[i] == 'f') {
                    _key[i] = '3';
                }

                else if (line[i] == 'g' || line[i] == 'h' || line[i] == 'i') {
                    _key[i] = '4';
                }
                else if (line[i] == 'j' || line[i] == 'k' || line[i] == 'l') {
                    _key[i] = '5';
                }
                else if (line[i] == 'm' || line[i] == 'n' || line[i] == 'o') {
                    _key[i] = '6';
                }
                else if (line[i] == 'p' || line[i] == 'q' || line[i] == 'r' || line[i] == 's') {
                    _key[i] = '7';
                }
                else if (line[i] == 't' || line[i] == 'u' || line[i] == 'v') {
                    _key[i] = '8';
                }
                else if (line[i] == 'w' || line[i] == 'x' || line[i] == 'y' || line[i] == 'z') {
                    _key[i] = '9';
                }

            }
            return new String(_key);        
        }
    }
}

