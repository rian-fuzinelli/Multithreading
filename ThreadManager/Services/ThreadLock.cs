using System;
using System.Threading;

namespace ThreadManager.Services;

public static class ThreadLock
{
    private static readonly object lockObject = new object();
    
    static void ThreadTask(int id)
    {
        lock (lockObject)
        {
            Console.WriteLine($"Thread {id} has started");
        }

        for (int i = 1; i <= 3; i++)
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

    public static void ThreadCount(string[] args)
    {
        int threadsSize = 3;

        Thread[] threads = new Thread[threadsSize];

        for (int i = 0; i < threadsSize; i++)
        {
            int id = i + 1;
            threads[i] = new Thread(() => ThreadTask(id));
        }

        foreach (Thread t in threads)
        {
            t.Join();
        }
        
        Console.WriteLine("All threads are finished");
    }
    
}