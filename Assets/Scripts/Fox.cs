using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // the Game Object the Fox collided with
        GameObject GOotherObject = otherCollider.gameObject;

        // if a Gravestone, jump over it
        if (GOotherObject.GetComponent<Gravestone>())
        {
            // change the animation
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        }
        else if (GOotherObject.GetComponent<Defender>()) // if the other object has a Defender component
        {
            GetComponent<Attacker>().Attack(GOotherObject);  // call the attack method on a Defender
        }

    } // OnTriggerEnter2D


} // class Fox
