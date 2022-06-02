using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("BigEnemy"))
        {
            //BigEnemy._instance.TakeDamage(1);
        }

        if (other.gameObject.CompareTag("LittleEnemy"))
        {
            //LittleEnemy._instance.TakeDamage(1);
        }
    }
}
