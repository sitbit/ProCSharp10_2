// See https://aka.ms/new-console-template for more information

using Microsoft.VisualStudio.Threading;

Console.WriteLine("***** C# async/await *****\n");

Console.WriteLine(DoWork());

string message = await DoWorkAsync();
Console.WriteLine($"0 - {message}");

_ = DoWorkAsync().Result;
_ = DoWorkAsync().GetAwaiter().GetResult();

string msg = await DoWorkAsync().ConfigureAwait(false);
Console.WriteLine($"1 - {msg}");

try
{
    await MethodReturningVoidTaskAsync();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("Multiple awaits");
await MultipleAwaits();
Console.WriteLine("Multiple awaits done");

Console.WriteLine("Multiple awaits take 2");
await MultipleAwaitsTake2();
Console.WriteLine("Take 2 done.");

Console.WriteLine("Multiple awaits take 3");
await MultipleAwaitsAsync();
Console.WriteLine("Take 3 done.");

Console.WriteLine("Completed");

Console.ReadLine();

#pragma warning disable CS8321, VSTHRD100 // Local function is declared but never used
static string DoWork()
{
    JoinableTaskFactory jtf = new(new JoinableTaskContext());
    string message = jtf.Run(async () => await DoWorkAsync().ConfigureAwait(true));
    return message;
}
static async Task<string> DoWorkAsync()
{
    return await Task.Run(() =>
    {
        Thread.Sleep(1_000);
        return "Done with work!";
    });
}
static async void MethodReturningVoidAsync()
{
    await Task.Run(() =>
    {
        Thread.Sleep(2_000);
        throw new Exception("Something wicked this way comes");
    });
    Console.WriteLine("Fire and forget 'void' method complete.");
}
static async Task MethodReturningVoidTaskAsync()
{
    await Task.Run(() =>
    {
        Thread.Sleep(2_000);
        throw new Exception("Something wicked this way comes");
    });
    Console.WriteLine("Fire and forget 'void' method complete.");
}
static async Task MultipleAwaits()
{
    await Task.Run(() => Thread.Sleep(1000));
    Console.WriteLine("Done with task #1");

    await Task.Run(() => Thread.Sleep(1000));
    Console.WriteLine("Done with task #2");

    await Task.Run(() => Thread.Sleep(1000));
    Console.WriteLine("Done with task #3");
}
static async Task MultipleAwaitsAsync()
{
    _ = await Task.WhenAny(
        Task.Run(() =>
        {
            Thread.Sleep(2_000);
            Console.WriteLine("Done with task #1");
        }),
        Task.Run(() =>
        {
            Thread.Sleep(1_000);
            Console.WriteLine("Done with task #2");
        }),
        Task.Run(() =>
        {
            Thread.Sleep(1_000);
            Console.WriteLine("Done with task #3");
        }
        )
        );
}
static async Task MultipleAwaitsTake2()
{
    List<Task> tasks = new()
    {
        Task.Run(() =>
        {
            Thread.Sleep(2_000);
            Console.WriteLine("Done with task #1");
        }),
        Task.Run(() =>
        {
            Thread.Sleep(1_000);
            Console.WriteLine("Done with task #2");
        }),
        Task.Run(() =>
        {
            Thread.Sleep(1_000);
            Console.WriteLine("Done with task #3");
        }
        )
    };
    await Task.WhenAll(tasks);
}