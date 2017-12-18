using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour {

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D col)
    {
        Attacker attacker = col.gameObject.GetComponent<Attacker>();
        if (attacker)
        {
            anim.SetTrigger("isHitTrigger");
        }
    }
}
