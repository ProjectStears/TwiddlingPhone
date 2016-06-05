using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour
{
    private float pitch; //rotation around the X axis
    private float roll; //rotation around the Y axis

    private float rotationSensitivity;

    private GameObject sphere;
    private GameObject playfieldRig;
    
    void Start()
    {
        Input.gyro.enabled = true;

        rotationSensitivity = 25;

	    sphere = GameObject.Find("Sphere");
        playfieldRig = GameObject.Find("Playfield");
	}
	
	void Update ()
    { 
        //Todo: compensate for start position of roll

#if UNITY_EDITOR

        pitch += Input.GetAxis("Vertical"); 
        roll += Input.GetAxis("Horizontal");

#elif UNITY_ANDROID

	    pitch = Input.gyro.gravity.y * rotationSensitivity;
	    roll = Input.gyro.gravity.x * rotationSensitivity;

#endif

        playfieldRig.transform.rotation = Quaternion.AngleAxis(pitch, Vector3.right) * Quaternion.AngleAxis(roll,Vector3.down);

	    if (Random.value < 0.01)
	    {
	        Bounce();
	    }
	}

    void LateUpdate()
    {
        this.GetComponent<DebugInfo>().SetDebugMsg(pitch + " " + roll);
        this.GetComponent<DebugInfo>().SetDebugMsg(Config.SaveFileName);
    }


    private void Bounce()
    {
        sphere.GetComponent<Rigidbody>().AddForce(Random.onUnitSphere, ForceMode.Impulse);
    }
}
