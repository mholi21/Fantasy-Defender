using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour {

    private Animator anim;
    private Attacker attacker;

	void Start () {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;

        //abort if not defender
        if (!obj.GetComponent<Defender>())
        {
            return;
        }
        /*if (obj.GetComponent<Stone>())
        {
            anim.SetTrigger("jumpTrigger");
        }*/
        else
        {
            anim.SetBool("isAttacking", true);
            attacker.Attack(obj);
        }
    }
}
