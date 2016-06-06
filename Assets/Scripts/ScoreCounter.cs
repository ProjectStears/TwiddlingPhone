using UnityEngine;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private Text scoreText;
    private float score;
    private GameObject sphere;

    private float maxDistance;

    // Use this for initialization
    void Start()
    {
        maxDistance = 5;

        sphere = GameObject.Find("Sphere");
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score = score + (maxDistance - Vector3.Magnitude(sphere.transform.position))*Time.deltaTime*2;
        scoreText.text = Mathf.RoundToInt(score).ToString();
    }

    void LateUpdate()
    {
        if (Time.frameCount % 60 == 0)
        {
            Config.LogData.Add(Time.timeSinceLevelLoad + " - " + score);
        }
    }



}
