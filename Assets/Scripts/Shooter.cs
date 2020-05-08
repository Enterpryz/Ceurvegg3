using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    
    } // Start() 


    private void Update()
    {
        if (IsAttackerInLane())
        {
            // change animation state to shooting
            animator.SetBool("isAttacking", true);
        }
        else
        {
            // change animation state to idle
            animator.SetBool("isAttacking", false);

        }

    } // Update()

    private void SetLaneSpawner()
    {
        // array to store the AttackerSpawners
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in attackerSpawners)
        {
            // is an attacker in my lane
            bool boolIsCloseEnough =
                // use the absolute value of the difference
                (Mathf.Abs(spawner.transform.position.y - transform.position.y) 
                <= Mathf.Epsilon);
            if (boolIsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        } // foreach

    } // SetLaneSpawner()

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false; // no attacker in our lane
        }
        else
        {
            return true; // there is an attacker in our lane
        }
    } // IsAttackerInLane()

    public void Fire()
    {
        // create a projectile and move it based on the position of the gun 
        Instantiate(projectile, gun.transform.position, transform.rotation);
    } // Fire()
} // class Shooter()
