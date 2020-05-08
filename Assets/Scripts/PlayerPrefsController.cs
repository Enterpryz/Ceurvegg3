using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string DIFFICULTY_KEY = "difficulty";
    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    public static void SetMasterVolume(float fltVolume)
    {
        if (fltVolume >= MIN_VOLUME && fltVolume <= MAX_VOLUME)
        {
            Debug.Log("Master volume set to " + fltVolume);
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, fltVolume);
        }
        else
        {
            Debug.LogError("Master volume is out of range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

}
