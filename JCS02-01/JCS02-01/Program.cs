using System.Text.RegularExpressions;

PrefixTree trie = new PrefixTree("word");
trie.insert("wo");
trie.insert("wilson");
trie.insert("will");

foreach (string n in trie)
{
  Console.WriteLine(n);
}



string text= "Jméno: Tomáš Davies,  Ročník: 2\nJméno: Matěj Dluhoš, Ročník: 2\nJméno: Ondřej Dresler, Ročník: 2\nJméno: Bohumil Federmann, Ročník: 2\nJméno: Petr Gajdošík, Ročník: 2\nJméno: Jakun Galeta, Ročník: 2\nJméno: Michael Hajný, Ročník: 3\nJméno: Than Tú Phan, Ročník: 2\n";

// 1. počet studentů --> Jméno: - tohle je vzor
var count = Regex.Matches(text, "Jméno:").Count;
Console.WriteLine(count);

// 2. všechna příjmení --> (\\w+) (\\w+) - závorka je skupina a \\w+ je slovo
var matches = Regex.Matches(text, "Jméno: (\\w+) (\\w+),");
foreach (Match match in matches)
{
    Console.WriteLine(match.Groups[2].Value);
}

// 3. všechny ročníky --> (\\d) - závorka je skupina a \\d je číslice
var matches_year = Regex.Matches(text, "Ročník: (\\d)");
foreach (Match match in matches_year)
{
    Console.WriteLine(match.Groups[1].Value);
}
