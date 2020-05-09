using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        // spawn the defender
        AttemptToPlaceDefenderAt(GetSquareClicked());

    } // OnMouseDown()

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        // determining which type of defender we want to select
        defender = defenderToSelect;
    } // SetSelectedDefender

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int intDefenderCost = defender.GetStarCost();
        // if we have enough resources, spawn a defender
        if (starDisplay.HaveEnoughStars(intDefenderCost))
        {
            SpawnDefender(gridPos);
            //deduct cost of defender
            starDisplay.SpendStars(intDefenderCost);
        } // if

    } // AttemptToPlaceDefenderAt()

    private Vector2 GetSquareClicked()
    {
        // obtain the mouse position to add a defender
        Vector2 V2clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        // convert from a screen to a World coordinate
        Vector2 V2worldPos = Camera.main.ScreenToWorldPoint(V2clickPos);
        // obtain world (grid) values (as integer)
        Vector2 V2gridPos = SnapToGrid(V2worldPos);
        return V2gridPos;
    } // GetSquareClicked()

    private Vector2 SnapToGrid(Vector2 V2rawWorldPos)
    {
        // want to round x and y values to an integer value
        // obtain x and y values as float
        float fltNewX = Mathf.RoundToInt(V2rawWorldPos.x);
        float fltNewY = Mathf.RoundToInt(V2rawWorldPos.y);
        return new Vector2(fltNewX, fltNewY);

    } // SnapToGrid()
    private void SpawnDefender(Vector2 roundedPos)
    {
        Defender newDefender = Instantiate(defender, roundedPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }

}
