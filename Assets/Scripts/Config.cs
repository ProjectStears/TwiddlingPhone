using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Config
{
    public static string TestSubjectId { get; set; }

    public static int SaveFileNumber { get; set; }

    public static string SaveFileName
    {
        get { return "TestData-" + TestSubjectId + "-" + SaveFileNumber; }
    }

    public static List<string> LogData { get; set; }

    static Config()
    {
        LogData = new List<string>();
    }
}
