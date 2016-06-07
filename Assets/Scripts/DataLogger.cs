using UnityEngine;
using System.IO;

public class DataLogger : MonoBehaviour
{
    private string SaveFile
    {
        get { return Application.persistentDataPath + "/" + Config.SaveFileName + ".txt"; }
    }

    void Start()
    {
        Config.SaveFileNumber = 1;
        CalcFileName();
    }

    private void CalcFileName()
    {
        while (File.Exists(SaveFile))
        {
            Config.SaveFileNumber++;
        }
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
            SaveData();
    }

    void OnApplicationQuit()
    {
        SaveData();
    }

    private void SaveData()
    {
        File.WriteAllLines(SaveFile, Config.LogData.ToArray());
    }
}
