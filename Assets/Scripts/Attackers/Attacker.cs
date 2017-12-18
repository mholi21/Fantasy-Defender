using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    private float currentSpeed;
    private GameObject currentTarget;
    private Animator anim;
    private Attacker attacker;

    public float spawnEverySeconds;

    void Start()
    {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

	void Update ()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if (!currentTarget)
        {
            anim.SetBool("isAttacking", false);
        }
	}

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;
        //abort if not defender

        if (!obj.GetComponent<Defender>())
        {
            return;
        }

        anim.SetBool("isAttacking", true);
        attacker.Attack(obj);
    }
}
