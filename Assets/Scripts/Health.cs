using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float fltHealth = 100f; // health of attacker
    [SerializeField] GameObject GOdeathVFX; // particle effects for death of an attacker

    public void DealDamage(float fltDamage)
    {
        fltHealth -= fltDamage; // increase damage to attacker
        if (fltHealth <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject); // attacker
        } // if
    } // DealDamage()

    private void TriggerDeathVFX()
    {
        if (!GOdeathVFX)
        {
            return;
        } // if
        // create a particle effect when an attacker dies
        GameObject GOdeathVFXObject = Instantiate(GOdeathVFX, transform.position, transform.rotation);
        Destroy(GOdeathVFXObject, 1f); // destroy particle effect
    } // TriggerDeathVFX()

} // class Health
