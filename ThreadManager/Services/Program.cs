namespace ThreadManager.Services;

public class Program
{
    private static readonly object lockObject = new object();
    static void ThreadManager(int id)
    {
        lock (lockObject)
        {
            Console.WriteLine($"Thread {id} has started");
        }

        for(int i = 1; i <= 5; i++)
        {
            lock (lockObject)
            {
                Console.WriteLine($"Thread {id} executing the step {i}");
            } 
            Thread.Sleep(1000);
        }
        
        lock (lockObject)
        {
            Console.WriteLine($"Thread {id} has ended");
        }
    }
    static void Main(string[] args)
    {
        Thread[] threads = new Thread[3];

        for (int i = 0; i < threads.Length; i++)
        {
            threads[i] = new Thread((() => ThreadManager(i + 1)));
            
            threads[i].Start();
        }
        
        foreach(Thread t in threads)
        {
            t.Join();
        }
        
        Console.WriteLine("All threads are finished");
    }
}