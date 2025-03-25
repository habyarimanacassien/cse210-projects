using System;
using System.Collections.Generic;

public class ScriptureLibrary
{
    private List<Scripture> _scriptures;
    private Random _random;

    // Constructor
    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>();
        _random = new Random();
        InitializeLibrary();
    }

    // Initialize the library with several scriptures
    private void InitializeLibrary()
    {
        // John 3:16
        Reference ref1 = new Reference("John", 3, 16);
        Scripture scripture1 = new Scripture(ref1, "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
        _scriptures.Add(scripture1);

        // Proverbs 3:5-6
        Reference ref2 = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture2 = new Scripture(ref2, "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.");
        _scriptures.Add(scripture2);

        // 1 Nephi 3:7
        Reference ref3 = new Reference("1 Nephi", 3, 7);
        Scripture scripture3 = new Scripture(ref3, "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.");
        _scriptures.Add(scripture3);

        // Alma 32:21
        Reference ref4 = new Reference("Alma", 32, 21);
        Scripture scripture4 = new Scripture(ref4, "And now as I said concerning faith—faith is not to have a perfect knowledge of things; therefore if ye have faith ye hope for things which are not seen, which are true.");
        _scriptures.Add(scripture4);

        // Matthew 5:14-16
        Reference ref5 = new Reference("Matthew", 5, 14, 16);
        Scripture scripture5 = new Scripture(ref5, "Ye are the light of the world. A city that is set on an hill cannot be hid. Neither do men light a candle, and put it under a bushel, but on a candlestick; and it giveth light unto all that are in the house. Let your light so shine before men, that they may see your good works, and glorify your Father which is in heaven.");
        _scriptures.Add(scripture5);
    }

    // Get a random scripture from the library
    public Scripture GetRandomScripture()
    {
        int randomIndex = _random.Next(0, _scriptures.Count);
        return _scriptures[randomIndex];
    }
}
