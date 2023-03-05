using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton;

public class SingletonDemo
{
    private static SingletonDemo instance;
    private List<string> data = new List<string>();
    private int index = 0;

    // Shoule be private in real project
    public SingletonDemo()
    {
        data.Add("1");
        data.Add("2");
        data.Add("3");
        data.Add("4");
        data.Add("5");
    }

    public static SingletonDemo GetInstance()
    {
        if (instance == null) {
            Console.WriteLine("Initialize Signleton");
            instance = new SingletonDemo();
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
