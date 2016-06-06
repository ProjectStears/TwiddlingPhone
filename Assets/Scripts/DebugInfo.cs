using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebugInfo : MonoBehaviour
{
    private Text debugText;

	// Use this for initialization
	void Start ()
	{
	    var debugGo = GameObject.Find("Debug");

        debugText = debugGo.GetComponent<Text>();
	    Input.gyro.enabled = true;

#if !DEBUG
        debugGo.SetActive(false);
#endif

    }

    // Update is called once per frame
    void Update ()
    {
        debugText.text = "";
    }

    public void SetDebugMsg(string msg)
    {
        debugText.text = debugText.text + "\n" + msg;
    }
}
