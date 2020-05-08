using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    private void OnTriggerEnter2D()
    {
        // decrease our lives because an attacker has hit
        // our DamageCollider
        FindObjectOfType<LivesDisplay>().TakeLife();
    }

} // class DamageCollider
