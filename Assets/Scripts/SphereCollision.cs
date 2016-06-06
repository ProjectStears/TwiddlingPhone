using UnityEngine;
using System.Collections;

public class SphereCollision : MonoBehaviour
{
    private GameObject hitHighlight;
    private float highlightDuration;
    private float highlightTimer;

    void Start()
    {
        hitHighlight = GameObject.Find("HitHighlight");
        hitHighlight.SetActive(false);

        highlightDuration = 0.5f;
        highlightTimer = -1;
    }

    void Update()
    {
        if (highlightTimer > 0)
        {
            hitHighlight.SetActive(true);
            highlightTimer = highlightTimer - Time.deltaTime;
        }
        else
        {
            hitHighlight.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Respawn")
        {
            highlightTimer = highlightDuration;
        }
    }
}
