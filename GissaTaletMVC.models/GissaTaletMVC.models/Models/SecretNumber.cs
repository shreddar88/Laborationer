﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GissaTaletMVC.Models
{
    public enum Outcome
    {
        Undefined,
        Low,
        High,
        Right,
        NoMoreGuesses,
        OldGuess
    }

    public struct GuessedNumber
    {
        public int? Number;
        public Outcome Outcome;
    }

    public class SecretNumber
    {
        private List<GuessedNumber> _guessedNumbers;
        private GuessedNumber _lastGuessedNumber;
        private int? _number;
        public const int MaxNumberOfGuesses = 7;

        public bool CanMakeGuess { get { return Count < MaxNumberOfGuesses ? true : false; } }

        public int? Count { get { return _guessedNumbers.Count; } }


        public IReadOnlyList<GuessedNumber> GuessedNumbers { get { return _guessedNumbers.AsReadOnly(); } }

        public GuessedNumber LastGuessedNumber { get { return _lastGuessedNumber; } }

        public int? Number
        {
            get { return CanMakeGuess ? null : _number; }
            private set { _number = value; }
        }



        public void Initialize()
        {
            _guessedNumbers.Clear();
            _lastGuessedNumber.Outcome = Outcome.Undefined;
            Random random = new Random();
            Number = random.Next(1, 101);
        }

        public Outcome MakeGuess(int guess)
        {
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }

            _lastGuessedNumber.Number = guess;

            if (CanMakeGuess)
            {
                if (_guessedNumbers.Any(n => n.Number == guess))
                {
                    _lastGuessedNumber.Outcome = Outcome.OldGuess;
                }
                else
                {
                    if (guess == _number)
                    {
                        _lastGuessedNumber.Outcome = Outcome.Right;
                    }
                    else if (guess > _number)
                    {
                        _lastGuessedNumber.Outcome = Outcome.High;
                    }
                    else
                    {
                        _lastGuessedNumber.Outcome = Outcome.Low;
                    }
                    _guessedNumbers.Add(_lastGuessedNumber);
                }
            }
            return _lastGuessedNumber.Outcome;
        }

        public SecretNumber()
        {
            _guessedNumbers = new List<GuessedNumber>();
            Initialize();
        }

        public string GuessTrack
        {
            get
            {
                string _guessNr = " ";
                switch (Count)
                {
                    case 1:
                        _guessNr = "Första gissningen";
                        break;
                    case 2:
                        _guessNr = "Andra gissningen";
                        break;
                    case 3:
                        _guessNr = "Tredje gissningen";
                        break;
                    case 4:
                        _guessNr = "Fjärde gissningen";
                        break;
                    case 5:
                        _guessNr = "Femte gissningen";
                        break;
                    case 6:
                        _guessNr = "Sjätte gissningen";
                        break;
                    case 7:
                        _guessNr = "Sjunde gissningen";
                        break;
                }
                return String.Format("{0}", _guessNr);
            }
        }

        public string Message(Outcome outcome)
        {
            string message = "";
            switch (outcome)
            {
                case Outcome.Right:
                    return String.Format("Grattis, du klarade det på {0}", GuessTrack);
                case Outcome.OldGuess:
                    return String.Format("Du har redan gissat på {0}, välj ett annat tal.", LastGuessedNumber.Number);
                case Outcome.High:
                    message = String.Format("{0} är för Högt.", LastGuessedNumber.Number);
                    break;
                case Outcome.Low:
                    message = String.Format("{0} är för lågt.", LastGuessedNumber.Number);
                    break;
            }
            if (!CanMakeGuess)
            {
                message = String.Format("{0} Inga fler gissningar, det hemliga talet var {1}", message, Number);
            }
            return message;
        }

    }
}