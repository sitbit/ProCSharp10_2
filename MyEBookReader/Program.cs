﻿// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Security.AccessControl;
using System.Text;

string _theEbook = "";

Console.WriteLine("***** My EBook Reader *****\n");

//GetBook();
Task task = GetBookAsync();
Console.WriteLine("Downloading the book...");
await task;

Console.WriteLine("Press <Enter> to continue...");
Console.ReadLine();

string FindLongestWord(string[] words)
{
    var sortByLength = from word in words
                       orderby word.Length descending
                       select word;
    return sortByLength.FirstOrDefault();
}
string[] FindTenMostCommon(string[] words)
{
    var frequency = from word in words
                    where word.Length > 6
                    group word by word into g
                    orderby g.Count() descending
                    select g.Key;
    return frequency.Take(10).ToArray();
}
#pragma warning disable CS8321 // Local function is declared but never used
void GetBook()
{
#pragma warning disable SYSLIB0014 // Type or member is obsolete
    using WebClient wc = new();
#pragma warning restore SYSLIB0014 // Type or member is obsolete
    wc.DownloadStringCompleted += (s, eArgs) =>
    {
        _theEbook = eArgs.Result;
        Console.WriteLine("Download complete.");
        GetStats();
    };
    wc.DownloadStringAsync(new Uri("http://www.gutenberg.org/files/98/98-0.txt"));
}
async Task GetBookAsync()
{
    HttpClient client = new();
    _theEbook = await client.GetStringAsync("http://www.gutenberg.org/files/98/98-0.txt");
    Console.WriteLine("Download complete.");
    GetStats();
}
#pragma warning restore CS8321 // Local function is declared but never used
void GetStats()
{
    char[] splitValues = new char[] { ' ', '\u000A', ',', '.', ';', ':', '-', '?', '!', '/' };
    string[] words = _theEbook.Split(splitValues, StringSplitOptions.RemoveEmptyEntries);
    string[] tenMostCommon = null;
    string longestWord = string.Empty;

    Parallel.Invoke(() => { tenMostCommon = FindTenMostCommon(words); },
                    () => { longestWord = FindLongestWord(words); });

    StringBuilder stats = new("Ten most common words are:\n");
    foreach (string word in tenMostCommon)
    {
        _ = stats.AppendLine(word);
    }
    _ = stats.AppendLine($"Longest word is: {longestWord}");

    Console.WriteLine($"{stats}", "Book info");
}