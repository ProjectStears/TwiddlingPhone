using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartDataEntry : MonoBehaviour {

    public void SetTestSubjectId(string id)
    {
        Config.TestSubjectId = id;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
