// See https://aka.ms/new-console-template for more information
Console.WriteLine("***** Async Stream *****");

await foreach (int number in GenerateSequence())
{
    Console.WriteLine(number);
}

static async IAsyncEnumerable<int> GenerateSequence()
{
    for (int i = 0; i < 20; ++i)
    {
        await Task.Delay(300);
        yield return i;
    }
}