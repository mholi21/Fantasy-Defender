using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile;
    public GameObject gun;

    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;

    void Start()
    {
        animator = GetComponent<Animator>();
        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        SetMyLaneSpawner();
    }

    void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    void SetMyLaneSpawner()
    {
        Spawner[] allSpawners = GameObject.FindObjectsOfType<Spawner>();
        foreach ( Spawner spawn in allSpawners)
        {
            if(spawn.transform.position.y == transform.position.y)
            {
                myLaneSpawner = spawn;
                return;
            }
        }

        Debug.LogError(name + " can't find spawner in my lane [" + transform.position.y + "]");
    }

    bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }

        foreach (Transform attackers in myLaneSpawner.transform)
        {
            if (attackers.transform.position.x > transform.position.x)
            {
                return true;
            }
        }

        return false;
    }

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile);
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}
