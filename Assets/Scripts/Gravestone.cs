using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        Attacker attacker = otherCollider.GetComponent<Attacker>();

        // if there is a collision with an Attacker
        if (attacker)
        {
            // TODO some sort of animation
        }
    } // OnTriggerStay2D()

} // class Gravestone
