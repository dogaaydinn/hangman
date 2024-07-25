# Hangman Game

This project is a console-based Hangman game. Players can choose to guess words from a list of countries or animals.

## Setup

1. Clone or download this project to your computer.
2. Open the project in Visual Studio or any C# IDE.
3. Run the project.

## How to Play

When you start the game, you can choose from the following options:

1. Guess countries
2. Guess animals
3. Exit

### Guessing Words

1. Select either "Guess countries" or "Guess animals".
2. You have 6 lives to guess the word correctly.
3. Enter letters one at a time to guess the word.
4. If you guess a letter correctly, it will be revealed in the word.
5. If you guess a letter incorrectly, you lose a life.
6. The game continues until you either guess the word correctly or run out of lives.
7. You can exit the game at any time by entering the number 3 when prompted to guess a letter.

### Exiting the Game

1. Select "Exit" to close the game.

## Code Overview

The main logic of the game is implemented in the following methods:

- `GuessWord`: Handles the game logic for guessing words based on the selected category (animals or countries).
- `UpdateGuessedWord`: Updates the guessed word with the correct letters guessed by the player.

### Categories

The game uses a static class `Category` to represent the possible categories (Animal, Country).

### Constants

The following constants are defined at the beginning of the code:

- `animalList`: List of animals to be guessed.
- `countryList`: List of countries to be guessed.
- `allWords`: Combination of `animalList` and `countryList`.
- `initialAlphabet`: The alphabet used for displaying available letters.
- `initialPlayerMaxGuess`: The maximum number of incorrect guesses allowed (initially set to 6).

Enjoy the game!
