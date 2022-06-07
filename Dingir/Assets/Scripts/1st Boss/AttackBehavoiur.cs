using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavoiur : MonoBehaviour
{
    Movement movScript;
    GameObject Target;
    bool Attacking;

    void Start()
    {
        Attacking = false;
        Target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.LookAt(Target.transform);
        if(Attacking!)
        {
            StartCoroutine(changePos());
        }
        else
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator changePos()
    {
        Attacking = false;

        yield return new WaitForSeconds(5);
        movScript.posRandomizer();
        yield return new WaitForSeconds(3);
        movScript.posSpawn(this.transform);
        yield return new WaitForSeconds(2);
        
        Attacking = true;
    }

    IEnumerator Attack()
    {
        Attacking = true;

        yield return new WaitForSeconds(2);

        Attacking = false;
    }
}
