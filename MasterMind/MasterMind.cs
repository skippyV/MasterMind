namespace QuadaxMasterMindAssessment
{
    public class MasterMind : IMasterMind
    {
        private const int MinDigitInclusive = 2;
        private const int MaxDigitExclusive = 6;
        private const int NumberOfDigitsToMatch = 4;

        private const int NumAllowedAttempts = 10;

        private string ValidDigitCharsSet = string.Empty;
        private string ValidDigitCharsSetTrimmed = string.Empty;

        private string NumberSequenceToMatch = string.Empty;
        private bool UseInitialSequenceToMatch = false;

        public MasterMind()
        {
            ValidDigitCharsSet = BuildValidDigitCharsSet(MinDigitInclusive, MaxDigitExclusive);
            ValidDigitCharsSetTrimmed = RemoveWhitespace(ValidDigitCharsSet);
        }

        public MasterMind(string numberSequenceToMatch) : this()
        {
            if (ValidateInput(numberSequenceToMatch))
            {
                NumberSequenceToMatch = numberSequenceToMatch;
                UseInitialSequenceToMatch = true;
            }
        }

        public string HowToPlay()
        {
            return $@"MasterMind
This game has a secret sequence of {NumberOfDigitsToMatch} characters from the set [{ValidDigitCharsSet}].
The goal is to guess what the characters are and their order.
You have {NumAllowedAttempts} attempts to win the game.
";
        }

        public string PlayPrompt()
        {
            return $@"Enter {NumberOfDigitsToMatch} digits to guess the correct sequence.
Each digit can be of the set [{ValidDigitCharsSet}]
";
        }

        public void StartNewGame()
        {
            if (!UseInitialSequenceToMatch)
            {
                NumberSequenceToMatch = GenerateRandomSequence(MinDigitInclusive, MaxDigitExclusive, NumberOfDigitsToMatch);
            }

            GameInProgress = true;
            GameWon = false;
            PlayAttemptsLeft = NumAllowedAttempts;
        }

        public bool GameInProgress { get; private set; }
        public bool GameWon { get; private set; }
        public int PlayAttemptsLeft { get; private set; }
        public string SecretCode() => NumberSequenceToMatch;
        public string PlayInput(string input)
        {
            if (!ValidateInput(input) || !GameInProgress)
            {
                return string.Empty;
            }
            return EvaluatePlay(RemoveWhitespace(input));
        }

        private string GenerateRandomSequence(int minDigit, int maxDigit, int numChars)
        {
            string sequence = string.Empty;
            Random random = new Random();

            for (int i = 0; i < numChars; i++)
            {
                int randomVal = random.Next(minDigit, maxDigit);
                string chr = randomVal.ToString();
                sequence += chr;
            }

            return sequence;
        }

        private string BuildValidDigitCharsSet(int minDigit, int maxDigit)
        {
            string sequence = string.Empty;

            for (int i = minDigit; i < maxDigit; i++)
            {
                string chr = i.ToString();
                sequence += chr;
                if (i < maxDigit - 1)
                {
                    sequence += ' ';
                }
            }

            return sequence;
        }

        public bool ValidateInput(string? input)
        {
            if (input == null)
            {
                return false;
            }
            if (!InputStringLengthIsValid(input))
            {
                return false;
            }
            if (!InputStringCharsAreInSet(input))
            {
                return false;
            }
            return true;
        }

        private string RemoveWhitespace(string input) => new(input.Where(c => !char.IsWhiteSpace(c)).ToArray());

        private bool InputStringLengthIsValid(string input)
        {
            string inputTrimmed = RemoveWhitespace(input);

            return inputTrimmed.Length == NumberOfDigitsToMatch;
        }

        private bool InputStringCharsAreInSet(string input)
        {
            string inputTrimmed = RemoveWhitespace(input);

            foreach (char c in inputTrimmed)
            {
                if (ValidDigitCharsSetTrimmed.Contains(c))
                {
                    continue;
                }
                return false;
            }
            return true;
        }

        private string EvaluatePlay(string input)
        {
            string charsMatchAndInPosition = string.Empty; // uses '+' char to indicate a match for char and position
            string charsMatchNotPosition = string.Empty;   // uses '-' char to indicate a match for char out of position

            // first check for matches in correct sequence
            // the remaining non-position-matches are then checked to determine if they reside in the correct set
            string inputRemainingChars = string.Empty;
            string correctRemainingChars = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == NumberSequenceToMatch[i])
                {
                    charsMatchAndInPosition += '+';
                }
                else
                {
                    inputRemainingChars += input[i];
                    correctRemainingChars += NumberSequenceToMatch[i];
                }
            }
            charsMatchNotPosition = CheckForMatchingCharsOutOfOrder(correctRemainingChars, inputRemainingChars);

            if (charsMatchAndInPosition.Length == NumberOfDigitsToMatch)
            {
                GameInProgress = false;
                GameWon = true;
            }

            if (--PlayAttemptsLeft == 0)
            {
                GameInProgress = false;
            }

            return charsMatchAndInPosition + charsMatchNotPosition;
        }

        private string CheckForMatchingCharsOutOfOrder(string correctChars, string input)
        {
            List<char> correctCharsList = new();
            correctCharsList.AddRange(correctChars);
            string result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                int indx = correctCharsList.FindIndex(m => m == input[i]);
                if (indx > -1)
                {
                    result += '-';
                    correctCharsList.Remove(input[i]);
                }
            }

            return result;
        }        
    }
}
