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

    private List<string> scoreList;


    // Use this for initialization
    void Start()
    {
        maxDistance = 5;

        sphere = GameObject.Find("Sphere");
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        score = 0;

        scoreList = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        score = score + (maxDistance - Vector3.Magnitude(sphere.transform.position))*Time.deltaTime*2;
        scoreText.text = Mathf.RoundToInt(score).ToString();
    }

    void LateUpdate()
    {
        if (Time.frameCount%60 == 0)
        {
            scoreList.Add(Time.realtimeSinceStartup + " - " + score);
        }
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
            File.WriteAllLines(Application.persistentDataPath + "/blubscore.txt", scoreList.ToArray());
    }

}
