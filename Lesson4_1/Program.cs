using System;
using System.IO;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

/// <summary>
/// Random string generators.
/// </summary>
static class RandomUtil
{
    /// <summary>
    /// Get random string of 11 characters.
    /// </summary>
    /// <returns>Random string.</returns>
    public static string GetRandomString()
    {
        string path = Path.GetRandomFileName();
        path = path.Replace(".", ""); // Remove period.
        return path;
    }
}

class Program
{
    static void Main(string[] args)
    {
        BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

        ////Проверка заполнение случайных строк
        int n = 10_001;
        string[] myRandomStringArray = new string[n + 1];
        var array = BechmarkClass.GenerateRandomArray(myRandomStringArray);
        //for (int i = 0; i < array.Length; i++)
        //{
        //    Console.WriteLine(array.Length);
        //    Console.WriteLine(array[i]);
        //}

        //BechmarkClass.TestSearchRandomStringByHeshSet();
        //BechmarkClass.TestSearchRandomStringByArray();
        //BechmarkClass.GetRandomString(10);
    }
}

public class BechmarkClass
{

    public static int n = 10_000;
    public static string[] randomStringArray = new string[n + 1];

    public static HashSet<string> myHashSet = new HashSet<string>();

    public static string[] GenerateRandomArray(string[] myRandomStringArray)
    {
        for (int i = 0; i < n; i++)
        {
            myHashSet.Add(RandomUtil.GetRandomString());
            myHashSet.CopyTo(randomStringArray);
        }
        return randomStringArray;
    }


    [Benchmark]
    public void TestSearchRandomStringByArray()
    {

        //int index = 9131;//задаём элемент который хотим искать
        string randomString = "gm30ywwkte1"; //randomStringArray[index];

        for (int i = 0; i < randomStringArray.Length; i++)
        {
            if (randomString == randomStringArray[i])
            {
                break;
            }

        }
    }

    [Benchmark]
    public void TestSearchRandomStringByHeshSet()
    {
        //int index = 9831;//задаём элемент который хотим искать
        string randomString = "gm30ywwkte1"; //randomStringArray[index];
        myHashSet.Contains(randomString);
    }
}