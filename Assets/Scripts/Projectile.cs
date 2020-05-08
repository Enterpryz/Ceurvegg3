using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float fltSpeed = 1f; // speed of weapon
    [SerializeField] float fltDamage = 50f; // amount of damage to attacker
    
    void Update()
    {
        // move the weapon towards the attacker
        transform.Translate(Vector2.right * fltSpeed * Time.deltaTime);
    } // Update()

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // deal damage to attacker
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>(); // reference the attacker
        // if there are both health and attacker components...
        if (attacker && health)
        {
            health.DealDamage(fltDamage); // damage the attacker
            Destroy(gameObject); // destroy the projectile
        } // if
        
    } // OnTriggerEnter2D() 

} // class Projectile
