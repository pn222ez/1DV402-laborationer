using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1B
{
    class SecretNumber
    {
        private int[] _guessedNumbers = new int[MaxNumberOfGuesses];
        private int _count;
        private int _number;
        private bool _CanMakeGuess;

        public const int MaxNumberOfGuesses = 7;

        public bool CanMakeGuess
        {
            get 
            {
                return _CanMakeGuess;
            }
            private set
            {
                _CanMakeGuess = value;
            }
        }

        public int Count
        {
            get
            {
                return _count;
            }
            private set
            {
                _count = value;
            }
        }

        public int GuessesLeft
        {
            get
            {
                return MaxNumberOfGuesses - _count;
            }
        }
        

        public SecretNumber()
        {
            this.Initialize();
        }
        //Kör igång en ny omgång gissningar. Tar fram ett nytt slumpat tal mellan 1 och 100 och nollställer tidigare gissningar.
        public void Initialize()
        {
            _count = 0;
            Random random = new Random();
            _number = random.Next(1, 101);
            CanMakeGuess = true;
            Array.Clear(_guessedNumbers, 0, _guessedNumbers.Length);
        }
        //Användaren gör en gissning. Metoden talar om om gissningen är rätt, för hög, för låg eller utanför gissningsområdet.
        public bool MakeGuess(int number)
        {
            if (_count >= MaxNumberOfGuesses)
            {
                throw new ApplicationException();
            } else if (number < 1 || number > 100)
            {
                    throw new ArgumentOutOfRangeException(String.Format("Talet är utanför intervallet 1 och 100"));
            }
            else
            {

                if (Array.IndexOf(_guessedNumbers, number) >= 0)
                {
                    Console.WriteLine("Du har redan gissat på {0}", number);
                    return false;
                } 
                else if (number == _number)
                {
                    _count++;
                    _guessedNumbers[_count-1]=number;
                    Console.WriteLine("RÄTT! Du klarade det på {0} försök", _count);
                    CanMakeGuess = false;
                    return true;
                }
                else if (number < _number)
                {
                    _count++;
                    Console.WriteLine("{0} är för lågt. du har {1} gissningar kvar", number, GuessesLeft);
                    _guessedNumbers[_count - 1] = number;
                    if (_count == MaxNumberOfGuesses)
                    {
                        Console.WriteLine("Det hemliga talet är {0}", _number);
                        CanMakeGuess = false;
                    }
                    return false;
                }
                else if (number > _number)
                {
                    _count++;
                    Console.WriteLine("{0} är för högt. du har {1} gissningar kvar", number, GuessesLeft);
                    _guessedNumbers[_count - 1] = number;
                    if (_count == MaxNumberOfGuesses)
                    {
                        Console.WriteLine("Det hemliga talet är {0}", _number);
                        CanMakeGuess = false;
                    }
                    return false;
                }
            }
            return false;
        }
    }
}

