using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebugInfo : MonoBehaviour
{
    private Text debugText;

	// Use this for initialization
	void Start ()
	{
	    debugText = GameObject.Find("Debug").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    debugText.text = Input.gyro.rotationRate.ToString();
	}
}
