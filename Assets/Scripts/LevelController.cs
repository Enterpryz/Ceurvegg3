using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] float fltWaitToLoad = 4f;
    [SerializeField] GameObject GOwinLabel;
    int intNumberOfAttackers = 0;
    bool boolLevelTimerFinished = false;

    private void Start()
    {
        // don't display Win Level text
        GOwinLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        intNumberOfAttackers++;
    } // AttackerSpawned()

    public void AttackerKilled()
    {
        intNumberOfAttackers--;
        if (intNumberOfAttackers <= 0 && boolLevelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    } // AttackerKilled()

    IEnumerator HandleWinCondition()
    {
        // display Win Level text
        GOwinLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(fltWaitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void LevelTimerFinished()
    {
        boolLevelTimerFinished = true;
        StopSpawners();
    } // LevelTimerFinished()

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    } // StopSpawners()

} // class LevelController
