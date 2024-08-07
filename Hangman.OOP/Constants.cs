namespace Hangman.OOP;
public static class Constants
{
    public static readonly List<string> AnimalList = new List<string>
    {
        "Bird", "snake", "dog", "cat", "bear", "tiger", "gorilla", "frog", "dinosaur", "elephant", "fox",
        "leopard", "starfish", "horse", "turtle", "shark"
    };

    public static readonly List<string> CountryList = new List<string>
    {
        "Japan", "Denmark", "Sweden", "Germany", "Spain", "Serbia", "France", "Ecuador", "Estonia", "Chile", "Morocco",
        "Algeria", "Thailand", "Turkey", "HongKong", "Belize"
    };

    public static readonly string InitialAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public static readonly int InitialPlayerMaxGuess = 6;
}