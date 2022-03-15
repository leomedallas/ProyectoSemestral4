using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    
    [HideInInspector] Rigidbody rb;
    public GameObject Target;
    
    [SerializeField] float speed;
    [SerializeField] int health;
    [SerializeField] int attack_Range;

    [HideInInspector] bool CanAttack;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        float TargetDist = Vector3.Distance(this.transform.position, Target.transform.position);

        if(TargetDist < 2 && CanAttack)
        {
            Attack();
        }
        else
        {
            Move();
        }
    }

    void Attack()
    {

    }

    void Move()
    {
        float movement = speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, movement);
    }
}
