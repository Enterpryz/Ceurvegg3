using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string DIFFICULTY_KEY = "difficulty";
    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;
    const float FLT_MIN_DIFFICULTY = 0f;
    const float FLT_MAX_DIFFICULTY = 2f;




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

    public static void SetDifficulty(float fltDifficulty)
    {
        // if the difficulty is in the range set
        if (fltDifficulty >= FLT_MIN_DIFFICULTY && fltDifficulty <= FLT_MAX_DIFFICULTY)
        {
            // sets "DIFFICULTY_KEY" to whatever is passed onto the method
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, fltDifficulty);
        }
        else
        {
            // prints an error message if difficulty set is too high
            print(" Difficulty Setting not it range");

        }
    }

        /*   public static void SetDifficulty(float difficulty)
           {
               if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY);
               { 
                   PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
               }
               else
               {
                   UnityEngine.Debug.LogError("YA DUN GOOFED THE DIFFICULTY (not in range)");
               }

           }*/

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }


}
