using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

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
        GameObject newProjectile =
            Instantiate(projectile, gun.transform.position, transform.rotation) 
            as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    } // Fire()
} // class Shooter()
