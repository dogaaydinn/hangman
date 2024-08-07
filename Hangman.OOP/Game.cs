namespace Hangman.OOP;
public class Game
{
    private readonly WordProvider _wordProvider;

    public Game()
    {
        _wordProvider = new WordProvider();
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("You are playing Hangman. Choose one of options for playing..");

            var options = new List<string> { "1. countries", "2. animals", "3. exit" };
            Console.WriteLine("Options:");
            foreach (var option in options)
                Console.WriteLine(option);

            Console.Write("Your Choice (1-3): ");
            var playMode = Console.ReadLine();

            try
            {
                var gameOptionNumber = Convert.ToInt32(playMode);

                switch (gameOptionNumber)
                {
                    case 1:
                        Console.WriteLine("Your Choice: try guessing countries");
                        GuessWord(Category.Country);
                        break;
                    case 2:
                        Console.WriteLine("Your Choice: try guessing animals");
                        GuessWord(Category.Animal);
                        break;
                    case 3:
                        Console.WriteLine("You Choose: Exit");
                        return;
                    default:
                        throw new Exception("Invalid Option. Please enter a valid option.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine($"You cannot convert {playMode} to integer");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    private void GuessWord(string category)
    {
        var wordList = _wordProvider.GetWords(category);

        Console.WriteLine($"You have 6 lives for guessing. Now you will guess the {category}");

        while (wordList.Count > 0)
        {
            var playerMaxGuess = Constants.InitialPlayerMaxGuess;
            var currentAlphabet = Constants.InitialAlphabet;
            var chosenWord = _wordProvider.GetRandomWord(wordList);
            var guessedLetters = new List<char>();
            var guessedWord = new string('_', chosenWord.Length);

            while (playerMaxGuess > 0 && guessedWord.Contains('_'))
            {
                Console.WriteLine($"Enter a letter for guess: {guessedWord}. Enter 3 to exit");
                var chosenLetter = Console.ReadLine()?.ToUpper()[0] ?? ' ';

                if (chosenLetter.Equals('3'))
                {
                    goto endgame;
                }

                Console.WriteLine($"Your guess is {chosenLetter}. ");

                if (guessedLetters.Contains(chosenLetter))
                {
                    Console.WriteLine($"You have already guessed this {chosenLetter} letter. Try another one.");
                    continue;
                }

                guessedLetters.Add(chosenLetter);
                if (chosenWord.Contains(chosenLetter))
                {
                    guessedWord = UpdateGuessedWord(chosenWord, guessedWord, chosenLetter);
                }
                else
                {
                    playerMaxGuess--;
                    Console.WriteLine($"wrong guess.. You have : {playerMaxGuess} lives left");
                }

                if (!currentAlphabet.Contains(chosenLetter)) 
                    continue;

                currentAlphabet = currentAlphabet.Replace(chosenLetter.ToString(), "-");
                Console.WriteLine($" letters: {currentAlphabet}");
            }

            if (!guessedWord.Contains('_'))
            {
                Console.WriteLine($" You guessed the {category}: {chosenWord}. You win!");
            }
            else
            {
                Console.WriteLine($"You couldn't guess the {category} {chosenWord}. You are a loser. HAHAHAHAHA :D ");
            }

            wordList.Remove(chosenWord);
        }

        Console.WriteLine($"There is no {category} left. You are end off the game");
        endgame:
        Console.WriteLine("Bye!");
    }

    private string UpdateGuessedWord(string chosenWord, string guessedWord, char chosenLetter)
    {
        var updatedGuess = guessedWord.ToCharArray();

        for (var i = 0; i < chosenWord.Length; i++)
            if (chosenWord[i] == chosenLetter)
                updatedGuess[i] = chosenLetter;

        return new string(updatedGuess);
    }
}