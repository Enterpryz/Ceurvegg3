using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // the Game Object the Lizard collided with
        GameObject GOotherObject = otherCollider.gameObject;

        // determine if the object the lizard collided with 
        // is a defender and if it is then attack
        if (GOotherObject.GetComponent<Defender>()) // if the other object has a Defender component
        {
            GetComponent<Attacker>().Attack(GOotherObject);  // call the attack method on a Defender
        }
    } // OnTriggerEnter2D


} // class Lizard
