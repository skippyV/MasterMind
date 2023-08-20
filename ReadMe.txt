This project is a console application that provides the user with a simplified version of the Mastermind game.

Mastermind involves deducing a secret sequence of numbers using clues provided from previous guesses of the secret set.
This game randomly generates the secret sequence and the user is allowed 10 attempts to try and deduce what the secret sequence is.

Program Play:
The user is prompted to enter 4 digits from the set [2 3 4 5] for their first guess of the secret set.
The program then returns a clue as to how close the user's guess was.

If a number in the user's guess is included in the secret sequence, but in the wrong position, the dash (-) character is displayed.
If a number in the user's guess is included in the secret sequence AND it is in the correct position, then the plus (+) character is displayed.

Therefore, since the user enters 4 digits per guess, the resulting clue will be a sequence of dash and plus characters up to 4 characters in length.
If a digit of the user's guess is not within the secret sequence, no character is displayed for that respective input digit.
Note - the order of the clue characters is not relevant to the order of the characters provided in the guess. 
The user has to deduce which characters they entered represent the clues given.

This projects target the .NET 6.0 framework.

The test project depends on:
  - NUnit
  - CvsHelper
  - Microsoft.NET.Test.Sdk



