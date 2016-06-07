using UnityEngine;

public class Alerter : MonoBehaviour
{
    private GameObject alertPanel;

    //private bool lastState;
    private float alertTimer;
    private float alertDuration;

	// Use this for initialization
	void Start ()
	{
	    alertDuration = 5;
	    alertTimer = -1;

	    alertPanel = GameObject.Find("AlertPanel");
        alertPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
	{

	    if (alertTimer > 0)
	    {
	        alertTimer = alertTimer - Time.deltaTime;
	    }
	    else
	    {
	        alertPanel.SetActive(false);
	    }

        /*
	    if (Input.touchCount > 0)
	    {
	        if (!lastState && alertTimer < 0)
	        {
	            ShowAlert();
	        }

	        lastState = true;
	    }
	    else
	    {
	        lastState = false;
	    }
        */
	}

    public void ShowAlert()
    {
        alertTimer = alertDuration;
        alertPanel.SetActive(true);
        Handheld.Vibrate();
    }
}
