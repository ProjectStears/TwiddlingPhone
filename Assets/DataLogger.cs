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

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
            File.WriteAllLines(SaveFile, Config.LogData.ToArray());
    }

    private void CalcFileName()
    {
        while (File.Exists(SaveFile))
        {
            Config.SaveFileNumber++;
        }
    }


}
