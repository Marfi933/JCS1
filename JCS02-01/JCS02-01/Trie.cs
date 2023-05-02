using System.Collections;

public class TrieNode
{
    public bool is_leaf { get; set; }
    public TrieNode[] children { get; set; }
    public char letter { get; set; }

    public TrieNode(char c, int alphabet_count = 26, bool is_leaf = false)
    {
        children = new TrieNode[alphabet_count];
        this.is_leaf = is_leaf;
        letter = c;
        children = new TrieNode[alphabet_count];
    }
}

public class PrefixTree : IEnumerable
{
    public TrieNode root { get; set; }
    public int alphabet_count { get; set; }
    public int count { get; set; }


    public bool Contains(string word)
    {
        //c - 'a' = 0-25 - index of the array
        var node = root;
        foreach (var c in word)
        {
            if (node.children[c - 'a'] == null) return false;
            node = node.children[c - 'a'];
        }

        return node.is_leaf;
    }

    public TrieNode GetChildren(string text)
    {
        var node = root;
        foreach (var c in text)
        {
            if (node.children[c - 'a'] == null) return null;
            node = node.children[c - 'a'];
        }

        return node;
    }

    public int GetChildrenCount(string text)
    {
        var node = root;
        foreach (var c in text)
        {
            if (node.children[c - 'a'] == null) return 0;
            node = node.children[c - 'a'];
        }

        return node.children.Length;
    }

    public PrefixTree(string word, int alphabet_count = 26)
    {
        this.alphabet_count = alphabet_count;
        root = new TrieNode(' ', alphabet_count);
        count = 0;
        insert(word);
    }

    public void insert(string word)
    {
        var node = root;
        foreach (var c in word)
        {
            if (node.children[c - 'a'] == null) node.children[c - 'a'] = new TrieNode(c, alphabet_count);
            node = node.children[c - 'a'];
        }

        node.is_leaf = true;
        count++;
    }

    public bool search(string word)
    {
        var node = root;
        foreach (var c in word)
        {
            if (node.children[c - 'a'] == null) return false;
            node = node.children[c - 'a'];
        }

        return node.is_leaf;
    }

    public int CompareTo(PrefixTree other)
    {
        return count.CompareTo(other.count);
    }


    public IEnumerator<string> GetEnumerator()
    {
        return GetWords(root, "").GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    private IEnumerable<string> GetWords(TrieNode node, string prefix)
    {
        if (node == null) yield break;
        if (node.is_leaf) yield return prefix + node.letter;
        for (var i = 0; i < alphabet_count; i++)
            foreach (var word in GetWords(node.children[i], prefix + node.letter))
                yield return word;
    }
}