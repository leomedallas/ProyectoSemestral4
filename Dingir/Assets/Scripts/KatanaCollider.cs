using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("LittleEnemy") || other.gameObject.CompareTag("BigEnemy"))
        {
            EnemyBehaviour.instance.TakeDamage(1);
        }
    }
}
