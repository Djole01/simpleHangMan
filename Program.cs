using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanDjordjeObradovic
{
    class Program
    {
        static void Main(string[] args)
        {

            Random random = new Random((int)DateTime.Now.Ticks);

            string[] wordBank = { "Blue", "White", "Yellow", "Orange", "Pink" };

            string guessingWord = wordBank[random.Next(0, wordBank.Length)];
            string guessingWordUppercase = guessingWord.ToUpper();

            StringBuilder displayToPlayer = new StringBuilder(guessingWord.Length);
            for (int i = 0; i < guessingWord.Length; i++)
                displayToPlayer.Append('_');

            List<char> correctGuesses = new List<char>();
            List<char> incorrectGuesses = new List<char>();

            int lives = 5;
            bool won = false;
            int lettersRevealed = 0;

            string input;
            char guess;

            while (!won && lives > 0)
            {
                Console.WriteLine("Category: Colors, Guess a Letter: ");

                input = Console.ReadLine().ToUpper();
                guess = input[0];

                if (correctGuesses.Contains(guess))
                {
                    Console.WriteLine("You've already tried '{0}', and it was correct!", guess);
                    continue;
                }
                else if (incorrectGuesses.Contains(guess))
                {
                    Console.WriteLine("You've already tried '{0}', and it was wrong!", guess);
                    continue;
                }

                if (guessingWordUppercase.Contains(guess))
                {
                    correctGuesses.Add(guess);

                    for (int i = 0; i < guessingWord.Length; i++)
                    {
                        if (guessingWordUppercase[i] == guess)
                        {
                            displayToPlayer[i] = guessingWord[i];
                            lettersRevealed++;
                        }
                    }

                    if (lettersRevealed == guessingWord.Length)
                        won = true;
                }
                else
                {
                    incorrectGuesses.Add(guess);
                    Console.WriteLine("No, there's no '{0}' in the word!", guess);
                    lives--;
                }

                Console.WriteLine(displayToPlayer.ToString());
            }

            if (won)
                Console.WriteLine("You win!");
            else
                Console.WriteLine("You lose! It was '{0}'", guessingWord);

            Console.Write("Press enter to exit....");
            Console.ReadLine();


        }


    }
}
