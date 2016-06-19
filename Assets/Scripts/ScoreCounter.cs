using UnityEngine;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private Text scoreText;
    private float score;
    private float playerScore;
    private GameObject sphere;

    private int lastSecond;

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
        var addscore = (maxDistance - Vector3.Magnitude(sphere.transform.position)) * Time.deltaTime * 2;

        if (sphere.transform.position.z > 3f)
        {
            sphere.transform.position = new Vector3(0, 0, -0.2f);
            playerScore = playerScore - 50;
            Config.LogData.Add(Time.timeSinceLevelLoad + " - Ball dropped out of bounds -50");
        }

        score = score + addscore;
        playerScore = playerScore + addscore;
        scoreText.text = Mathf.RoundToInt(playerScore).ToString();

    }

    void LateUpdate()
    {
        var thisSecond = Mathf.RoundToInt(Time.timeSinceLevelLoad);

        if (lastSecond != thisSecond)
        {
            lastSecond = thisSecond;
            Config.LogData.Add(Time.timeSinceLevelLoad + " - " + score + " - " + playerScore);
        }
    }

    public void ReducePlayerScore(float reduction)
    {
        playerScore = playerScore - reduction;
        Debug.Log("Reducing by: " + reduction);
    }
}
