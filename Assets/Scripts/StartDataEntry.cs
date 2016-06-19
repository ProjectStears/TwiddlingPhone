using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartDataEntry : MonoBehaviour {

    void Start()
    {
        SetTestSubjectId("Blub");
    }

    public void SetTestSubjectId(string id)
    {
        Config.TestSubjectId = id;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
