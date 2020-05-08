using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    [SerializeField] int intTimeToWait = 4; // time to wait before starting scene
    int intCurrentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        intCurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (intCurrentSceneIndex == 0)
        {
            // if first scene, wait to start
            StartCoroutine(WaitForTime());
        } // if
    } // Start()

    IEnumerator WaitForTime()
    {
        // wait and load next scene
        yield return new WaitForSeconds(intTimeToWait);
        LoadNextScene();
    } // WaitForTime()

    public void LoadNextScene()
    {
        SceneManager.LoadScene(intCurrentSceneIndex + 1);
    } // LoadNextScene()

    public void LoadYouLose()
    {
        SceneManager.LoadScene("LoseScreen");
    }

} // class LevelLoader
