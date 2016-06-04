using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour
{
    private float pitch; //rotation around the X axis
    private float roll; //rotation around the Y axis

    private GameObject sphere;
    private GameObject playfieldRig;
    
	// Use this for initialization
	void Start () {
	    sphere = GameObject.Find("Sphere");
        playfieldRig = GameObject.Find("Playfield");
	}
	
	// Update is called once per frame
	void Update ()
	{

        pitch += Input.GetAxis("Vertical"); 
        roll += Input.GetAxis("Horizontal");

        playfieldRig.transform.rotation = Quaternion.AngleAxis(pitch, Vector3.right) * Quaternion.AngleAxis(roll,Vector3.down);

        if (Random.value < 0.01)
        { Bounce();}
	}


    private void Bounce()
    {
        sphere.GetComponent<Rigidbody>().AddForce(Random.onUnitSphere, ForceMode.Impulse);
    }
}
