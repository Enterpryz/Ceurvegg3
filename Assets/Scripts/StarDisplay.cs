using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    // initial number of stars for the game
    [SerializeField] int intStars = 100;
    // the text for the star text field
    Text txtStarText;

    void Start()
    {
        // to access the text component within the text field
        txtStarText = GetComponent<Text>();
        UpdateDisplay();

    } // Start()

    private void UpdateDisplay()
    {
        // convert the integer star field to a string
        txtStarText.text = intStars.ToString();
        
    } // UpdateDisplay()

    public bool HaveEnoughStars(int amount)
    {
        return intStars >= amount;
    }

    public void AddStars(int amount)
    {
        // increase our number of stars
        intStars += amount;
        UpdateDisplay();

    } // AddStars()

    public void SpendStars(int amount)
    {
        // only decrease if there is something available to decrease
        if (intStars >= amount)
        {
            // decrease our number of stars
            intStars -= amount;
            UpdateDisplay();
        } // if
        
    } // SpendStars()

} // class StarDisplay
