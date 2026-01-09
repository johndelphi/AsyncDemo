namespace AsyncDemo.Utils;

public class DelaySimulator
{
    public static async Task Simulate(string serviceName, CancellationToken token)
    {
        int delay = Random.Shared.Next(1000, 4000);
        Console.WriteLine($"{serviceName} started(delay:{delay}ms)");
        await Task.Delay(delay, token);
        Console.WriteLine($"{serviceName} stopped(delay:{delay}ms)");
        await Task.Delay(delay, token);
        Console.WriteLine($"{serviceName} finished (delay:{delay}ms)");
    }
}