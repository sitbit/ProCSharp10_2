// See https://aka.ms/new-console-template for more information
Console.WriteLine("***** PLINQ Data Processing With Cancellation *****\n");

CancellationTokenSource _cancelToken = new();
do
{
    Console.WriteLine("Press any key to start processing...");
    _ = Console.ReadKey();
    Console.WriteLine("Processing...");
    _ = Task.Factory.StartNew(ProcessIntData);
    Console.Write("Enter 'Q' to quit: ");
    string ans = Console.ReadLine();
    if (ans.Equals("Q", StringComparison.OrdinalIgnoreCase))
    {
        _cancelToken.Cancel();
        break;
    }

} while (true);

void ProcessIntData()
{
    int[] source = Enumerable.Range(1, 100_000_000).ToArray();

    DateTime start = DateTime.Now;
    int[] mod3IsZero = null;
    try
    {
        mod3IsZero = (from i in source.AsParallel().WithCancellation(_cancelToken.Token)
                      where i % 3 == 0
                      orderby i descending
                      select i).ToArray();
    }
    catch (OperationCanceledException ex)
    {
        Console.WriteLine(ex.Message);
    }
    TimeSpan time = DateTime.Now - start;
    Console.WriteLine($"Found {mod3IsZero.Length} numbers in {time.TotalMilliseconds} ms " +
        "that match query");
}