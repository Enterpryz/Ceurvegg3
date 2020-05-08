using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    // the price each individual star will cost
    [SerializeField] int intStarCost = 100;

    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    } // AddStars

    public int GetStarCost()
    {
        return intStarCost;
    } // GetStarCost

} // class Defender
