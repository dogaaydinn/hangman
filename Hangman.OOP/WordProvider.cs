namespace Hangman.OOP;
public class WordProvider
{
    private readonly Random _random;

    public WordProvider()
    {
        _random = new Random();
    }

    public List<string> GetWords(string category)
    {
        return category switch
        {
            Category.Animal => Constants.AnimalList,
            Category.Country => Constants.CountryList,
            _ => Constants.CountryList.Concat(Constants.AnimalList).ToList()
        };
    }

    public string GetRandomWord(List<string> wordList)
    {
        return wordList[_random.Next(wordList.Count)].ToUpper();
    }
}