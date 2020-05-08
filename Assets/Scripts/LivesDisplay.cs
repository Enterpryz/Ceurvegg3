using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] int intLives = 5;
    Text txtLives;
    [SerializeField] int intDamage = 1;

    void Start()
    {
        // to access the text component within the text field
        txtLives = GetComponent<Text>();
        UpdateDisplay();

    } // Start()

    private void UpdateDisplay()
    {
        // convert the integer star field to a string
        txtLives.text = intLives.ToString();

    } // UpdateDisplay()

    public void TakeLife()
    {
        // decrease our lives by one
        intLives -= intDamage;
        UpdateDisplay();
        if (intLives <= 0)
        {
            // no lives remaining, go to LoseScreen
            FindObjectOfType<LevelLoader>().LoadYouLose();
        }

    } // SpendStars()

} // class Lives
