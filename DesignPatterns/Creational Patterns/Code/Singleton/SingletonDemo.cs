using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton;

public class SingletonDemo
{
    private static readonly object Instancelock = new object();
    private static SingletonDemo instance = null;
    private List<string> data = new List<string>();
    private int index = 0;
    private static SingletonDemo EagerInstance = new SingletonDemo();
    // Shoule be private in real project
    public SingletonDemo()
    {
        data.Add("1");
        data.Add("2");
        data.Add("3");
        data.Add("4");
        data.Add("5");
    }

    public static SingletonDemo EagerGetInstance()
    {
        return EagerInstance;
    }

    // Lazy Loading
    // Will cause Thread-safe issue
    public static SingletonDemo LazyGetInstance()
    {
        if (instance == null) {
            Console.WriteLine("Initialize Signleton");
            instance = new SingletonDemo();
        }

        return instance;
    }

    // Single checked locking approach for Thread-safe Singleton
    // solves the multithreading issue, but only one thread can access at a given time
    public static SingletonDemo LazyGetInstanceThreadSafeSingleChecked()
    {
        lock (Instancelock)
        {
            if (instance == null)
            {
                Console.WriteLine("Initialize Signleton");
                instance = new SingletonDemo();
            }
        }
        return instance;
    }

    // Double checked locking approach for Thread-safe Singleton
    // Multiple thread can access at same time
    public static SingletonDemo LazyGetInstanceThreadSafeDoubleChecked()
     {
        if (instance == null)
        {
            lock (Instancelock)
            {
                if (instance == null)
                {
                    Console.WriteLine("Initialize Signleton");
                    instance = new SingletonDemo();
                }
            }
        }
        return instance;
    }

    public string GetNextData()
    {
        var value = data[index];
        index = index + 1;
        if (index == data.Count)
        {
            index = 0;
        }
        return value;
    }
}
