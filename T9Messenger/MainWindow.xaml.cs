///Class that acts as a controller and displays the 
///text in the non-predictive mode
///This class sends the list of buttons clicked to
///the model displays the word from the 
///predicted words in the predicitve mode
///@autohr Sameera S. Desai
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KeyPad {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private Timer Timer = new Timer();  ///Timer to distinguish between clicks
        int clickCount = 0;      ///Variable that keeps a count of clicks
        String text;         ///Variable to store text to be displayed
        Boolean predictive = false; //Variable to check if the checkbox is checked or not
        Model model = new Model();      ///Object of the class model
        List<String> buttonClicks = new List<string>();     ///List to store the buttons clicked in the predicitve mode
        List<String> predictedWords = new List<string>();        ///List of predicted words sent by the model
        String sentence;        ///Variable that stores the text from the text-box
        int index;              ///Variable that keeps a track of the current word in the word list
        public MainWindow() {
            InitializeComponent();
            Timer.Interval = 1000;      ///Interval between two clicks
            Timer.Tick += new EventHandler(Timer_Tick);         ///Event handler
        }

        /// <summary>
        /// Method that displays 1 the text when the first button is 
        /// clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, RoutedEventArgs e) {
            TextBox1.Text = TextBox1.Text + "1";
        }

        /// <summary>
        /// Method that displays a on first click, b on second click
        /// c on third click and 2 on fourth click in the non-predictive
        /// mode and adds 2 to the list of buttons and sends it to 
        /// the model to get a list of predicted words
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, RoutedEventArgs e) {
            ///Non-predictive mode
            if (predictive == false) {
                clickCount = clickCount + 1;

                if (clickCount == 1) {
                    text = "a";
                    TextBox1.AppendText(text);
                    Timer.Start();
                }
                else if (clickCount == 2) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                    text = "b";
                    TextBox1.AppendText(text);
                }
                else if (clickCount == 3) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                    text = "c";
                    TextBox1.AppendText(text);
                }
                else if (clickCount == 4) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                    text = "2";
                    TextBox1.AppendText(text);
                }
            }
            
            ///Predictive mode
            else if (predictive == true)  {
                buttonClicks.Add("2");
                predictedWords=model.Predict(buttonClicks);
                Display(predictedWords);                
            }
        }
         
        /// <summary>
        /// Method that displays d on first click, e on second click
        /// f on third click and 3 on fourth click in the non-predictive
        /// mode and adds 3 to the list of buttons and sends it to 
        /// the model to get a list of predicted words
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3_Click(object sender, RoutedEventArgs e) {
            ///Predictive mode
            if (predictive == false) {
                clickCount = clickCount + 1;

                if (clickCount == 1) {
                    text = "d";
                    TextBox1.AppendText(text);
                    Timer.Start();
                }
                else if (clickCount == 2) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                    text = "e";
                    TextBox1.AppendText(text);
                }
                else if (clickCount == 3) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                    text = "f";
                    TextBox1.AppendText(text);
                }
                else if (clickCount == 4) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                    text = "3";
                    TextBox1.AppendText(text);
                }
            }
            ///Predictive mode
            else if (predictive == true) {
                buttonClicks.Add("3");
                predictedWords = model.Predict(buttonClicks);
                Display(predictedWords);
            }
        }

        /// <summary>
        /// Method that displays g on first click,h on second click
        /// i on third click and 4 on fourth click in the non-predictive
        /// mode and adds 4 to the list of buttons and sends it to 
        /// the model to get a list of predicted words
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button4_Click(object sender, RoutedEventArgs e) {
            ///non-predictive mode
            if (predictive == false) {
                clickCount = clickCount + 1;

                if (clickCount == 1) {
                    text = "g";
                    TextBox1.AppendText(text);
                    Timer.Start();
                }
                else if (clickCount == 2) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                    text = "h";
                    TextBox1.AppendText(text);
                }
                else if (clickCount == 3) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                    text = "i";
                    TextBox1.AppendText(text);
                }
                else if (clickCount == 4) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                    text = "4";
                    TextBox1.AppendText(text);
                }
            }

            ///Predictive mode
            else if (predictive == true) {
                buttonClicks.Add("4");
                predictedWords = model.Predict(buttonClicks);
                Display(predictedWords);
            }
        }

        /// <summary>
        /// Method that displays j on first click, k on second click
        /// l on third click and 5 on fourth click in the non-predictive
        /// mode and adds 5 to the list of buttons and sends it to 
        /// the model to get a list of predicted words
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button5_Click(object sender, RoutedEventArgs e) {
            ///Non-predictive mode
            if (predictive == false) {
                clickCount = clickCount + 1;

                if (clickCount == 1) {
                    text = "j";
                    TextBox1.AppendText(text);
                    Timer.Start();
                }
                else if (clickCount == 2) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                    text = "k";
                    TextBox1.AppendText(text);
                }
                else if (clickCount == 3) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                    text = "l";
                    TextBox1.AppendText(text);
                }
                else if (clickCount == 4) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                    text = "5";
                    TextBox1.AppendText(text);
                }
            }
            ///Predictive mode
            else if (predictive == true) {
                buttonClicks.Add("5");
                predictedWords = model.Predict(buttonClicks);
                Display(predictedWords);
            }
        }
        /// <summary>
        /// Method that displays m on first click, n on second click
        /// o on third click and 6 on fourth click in the non-predictive
        /// mode and adds 6 to the list of buttons and sends it to 
        /// the model to get a list of predicted words
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button6_Click(object sender, RoutedEventArgs e) {
            ///Non-predictive mode
            if (predictive == false) {
                clickCount = clickCount + 1;

                if (clickCount == 1) {
                    text = "m";
                    TextBox1.AppendText(text);
                    Timer.Start();
                }
                else if (clickCount == 2) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                    text = "n";
                    TextBox1.AppendText(text);
                }
                else if (clickCount == 3) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                    text = "o";
                    TextBox1.AppendText(text);
                }
                else if (clickCount == 4) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                    text = "6";
                    TextBox1.AppendText(text);
                }
            }
            ///Predicitve mode
            else if (predictive == true) {
                buttonClicks.Add("6");
                predictedWords = model.Predict(buttonClicks);
                Display(predictedWords);
            }
        }

        /// <summary>
        /// Method that displays p on first click, q on second click
        /// r on third click,s on fourth click and 7 on the fifth
        /// click in the non-predictive
        /// mode and adds 2 to the list of buttons and sends it to 
        /// the model to get a list of predicted words
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button7_Click(object sender, RoutedEventArgs e) {
            ///non-Predictive mode
            if (predictive == false) {
                clickCount = clickCount + 1;

                if (clickCount == 1) {
                    text = "p";
                    TextBox1.AppendText(text);
                    Timer.Start();
                }
                else if (clickCount == 2) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                    text = "q";
                    TextBox1.AppendText(text);
                }
                else if (clickCount == 3) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                    text = "r";
                    TextBox1.AppendText(text);
                }
                else if (clickCount == 4) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                    text = "s";
                    TextBox1.AppendText(text);
                }

                else if (clickCount == 5) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                    text = "7";
                    TextBox1.AppendText(text);
                }
            }
            ///predicitve mode
            else if (predictive == true) {
                buttonClicks.Add("7");
                predictedWords = model.Predict(buttonClicks);
                Display(predictedWords);
            }
        }

        /// <summary>
        /// Method that displays t on first click, u on second click
        /// v on third click and 8 on fourth click in the non-predictive
        /// mode and adds 8 to the list of buttons and sends it to 
        /// the model to get a list of predicted words
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button8_Click(object sender, RoutedEventArgs e) {
            ///non-predictive mode
            if (predictive == false) {
                clickCount = clickCount + 1;

                if (clickCount == 1) {
                    text = "t";
                    TextBox1.AppendText(text);
                    Timer.Start();
                }
                else if (clickCount == 2) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                    text = "u";
                    TextBox1.AppendText(text);
                }
                else if (clickCount == 3) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                    text = "v";
                    TextBox1.AppendText(text);
                }
                else if (clickCount == 4) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                    text = "8";
                    TextBox1.AppendText(text);
                }
            }
            ///predictive mode
            else if (predictive == true) {
                buttonClicks.Add("8");
                predictedWords = model.Predict(buttonClicks);
                Display(predictedWords);
            }
        }

        /// <summary>
        /// Method that displays w on first click, x on second click
        /// y on third click, z on fourth click and 9 on the 
        /// fifth click in the non-predictive
        /// mode and adds 9 to the list of buttons and sends it to 
        /// the model to get a list of predicted words
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button9_Click(object sender, RoutedEventArgs e) {
            ///non-predictive mode
            if (predictive == false) {
                clickCount = clickCount + 1;

                if (clickCount == 1) {
                    text = "w";
                    TextBox1.AppendText(text);
                    Timer.Start();
                }
                else if (clickCount == 2) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                    text = "x";
                    TextBox1.AppendText(text);
                }
                else if (clickCount == 3) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                    text = "y";
                    TextBox1.AppendText(text);
                }
                else if (clickCount == 4) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                    text = "z";
                    TextBox1.AppendText(text);
                }

                else if (clickCount == 4) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                    text = "9";
                    TextBox1.AppendText(text);
                }
            }
            ///predicitive mode
            else if (predictive == true) {
                buttonClicks.Add("9");
                predictedWords = model.Predict(buttonClicks);
                Display(predictedWords);
            }
        }

        /// <summary>
        /// Method that deletes one character at a time
        /// in the non-predicitve mode and a word in the
        /// predicitve mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button10_Click(object sender, RoutedEventArgs e) {
            ///non-predicitve mode
            if (predictive == false) {
                if (TextBox1.Text.Length != 0) {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                }
            }

            ///predictive mode
            else if (predictive == true) {
                int spacePosition = 0;
                string textInTextBox = TextBox1.Text;
                spacePosition = textInTextBox.LastIndexOf(' ', textInTextBox.Length - 1); 
                if (spacePosition < 1) {

                    textInTextBox = "";
                }
                else {
                    textInTextBox = textInTextBox.Remove(spacePosition);
                }
                TextBox1.Text = textInTextBox;
            }
            buttonClicks.Clear();
        }

        /// <summary>
        /// Method that displays 0 in the non-predicitve mode
        /// and toggles the list of words in the predicitve mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button11_Click(object sender, RoutedEventArgs e) {
            ///non-predictive mode
            if (predictive == false) {
                text = "0";
                TextBox1.AppendText(text);
            }
            ///Predictive mode
            else if (predictive == true) {
                index = index + 1;
                int spacePosition = TextBox1.Text.LastIndexOf(' '); 
                if (spacePosition < 1) {
                    TextBox1.Text = predictedWords[index];
                }

                else {
                    string textInTextBox = TextBox1.Text;
                    textInTextBox = textInTextBox.Remove(spacePosition);
                    if (index >= predictedWords.Count()) {
                        index = index % predictedWords.Count();
                    }
                    textInTextBox = textInTextBox +" "+predictedWords[index];
                    TextBox1.Text = textInTextBox;
                }
            }
        }

        /// <summary>
        /// Method that displays space when the 12th button in pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button12_Click(object sender, RoutedEventArgs e) {
            if (predictive == false) {
                text = " ";
                TextBox1.AppendText(text);
            }
            else if(predictive==true) {
                buttonClicks.Clear();
                sentence = TextBox1.Text+" ";
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e) {
            predictive = true;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e) {
            predictive = false;
        }

        void Timer_Tick(object sender, EventArgs e) {
            Timer.Stop();
            clickCount = 0;
            TextBox1.Text = TextBox1.Text;
        }

        /// <summary>
        /// Method that displays the text in the
        /// text-box in the predictive mode
        /// 
        /// </summary>
        /// <param name="words"></param>
        public void Display(List<String>words) {
            if (words.Count != 0) {
                index = 0;
                text = words[0];
                TextBox1.Text =sentence+text;
            }
            else {
                text = null;
                for (int i = 0; i < buttonClicks.Count(); i++) {
                   text = text+"-";
                }
                TextBox1.Text = sentence+text;                 
            }
        }
    }
}
