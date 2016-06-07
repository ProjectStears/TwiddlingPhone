using UnityEngine;
using System.Collections;

public class CommandGetter : MonoBehaviour
{
    private string urlget;
    private string urlreset;

    private WWW wwwget;
    private WWW wwwreset;

    private Alerter alerter;

    void Start()
    {
        alerter = this.gameObject.GetComponent<Alerter>();

        urlget = "http://aspepex.net/twiddle/twiddledata-23we4asdg76.txt";
        urlreset = "http://aspepex.net/twiddle/resetdata-hsdr47o2l20.php";

        wwwreset = new WWW(urlreset);
        wwwget = new WWW(urlget);
    }

    void Update()
    {
        if (wwwget.isDone && wwwreset.isDone)
        {
            if (wwwget.text != "0")
            {
                ExecuteCommand(int.Parse(wwwget.text));

                StartCoroutine(WebDataReset());
            }

            StartCoroutine(WebDataGet());
        }
    }

    private void ExecuteCommand(int result)
    {
        switch (result)
        {
            case 1:
                Config.LogData.Add(Time.timeSinceLevelLoad + " - Start");
                break;
            case 2:
                alerter.ShowAlert();
                Config.LogData.Add(Time.timeSinceLevelLoad + " - Warning");
                break;
            case 3:
                Config.LogData.Add(Time.timeSinceLevelLoad + " - Crash");
                break;
            case 4:
                Config.LogData.Add(Time.timeSinceLevelLoad + " - NoCrash");
                break;
            case 5:
                Config.LogData.Add(Time.timeSinceLevelLoad + " - End");
                Application.Quit();
                break;
        }
    }

    IEnumerator WebDataGet()
    {
        wwwget = new WWW(urlget);
        yield return wwwget;
    }

    IEnumerator WebDataReset()
    {
        wwwreset = new WWW(urlreset);
        yield return wwwreset;
    }
}
