namespace SpeechPurifier.Mistakes;

public class WordSpellingMistake : IWordMistake
{
    public int Weight => 5;
    public string Entry { get; init; }
    public WordSpellingMistake(string entry) => Entry = entry;
}