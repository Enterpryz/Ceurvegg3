using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)]
    float fltCurrentSpeed = 1f;
    GameObject GOcurrentTarget;

    private void Awake()
    {
        // when an Attacker is born
        FindObjectOfType<LevelController>().AttackerSpawned();
    } // Awake()

    private void OnDestroy()
    {
        // when an Attacker is killed
        FindObjectOfType<LevelController>().AttackerKilled();

    } // OnDestroy()

    void Update()
    {
        // speed to move attacker
        transform.Translate(Vector2.left * fltCurrentSpeed * Time.deltaTime);
        UpdateAnimationState();
    } // Update()

    private void UpdateAnimationState()
    {
        if (!GOcurrentTarget)
        {
            // stop attacking once the defender is destroyed
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    } // UpdateAnimationState()

    public void SetMovementSpeed(float speed)
    {
        fltCurrentSpeed = speed;
    } // SetMovementSpeed()

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        GOcurrentTarget = target;
    } // Attack()

    public void StrikeCurrentTarget(float damage)
    {
        if (!GOcurrentTarget)
        {
            return;
        }
        Health health = GOcurrentTarget.GetComponent<Health>();

        if (health)
        {
            health.DealDamage(damage);
        }
    } // StrikeCurrentTarget()

} // class Attacker

