using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] float fltbaselives = 3;
    [SerializeField] int intDamage = 1;
    float fltlives;
    Text txtLives;

    void Start()
    {
        fltlives = fltbaselives - PlayerPrefsController.GetDifficulty();
        txtLives = GetComponent<Text>();
        UpdateDisplay();
        UnityEngine.Debug.Log("Difficulty Setting Is Presently " + PlayerPrefsController.GetDifficulty());
    } // Start()

    private void UpdateDisplay()
    {
        // convert the integer star field to a string
        txtLives.text = fltlives.ToString();

    } // UpdateDisplay()

    public void TakeLife()
    {
        // decrease our lives by one
        fltlives -= intDamage;
        UpdateDisplay();
        if (fltlives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }

    } // SpendStars()

} // class Lives
