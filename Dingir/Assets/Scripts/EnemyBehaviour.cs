using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    
    [HideInInspector] Rigidbody rb;
    [HideInInspector] BoxCollider boxCollider;
    public Player Player;

    [Header("Target Values")]
    public GameObject target;
    public Transform targetTransform;
    
    [Header("Enemy Values")]
    [SerializeField] float speed;
    [SerializeField] int health;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        //Update Variables
        RaycastHit hit;

        Vector3 right = transform.TransformDirection(Vector3.right);
        Vector3 toTarget = targetTransform.position - transform.position;

        Ray ray = new Ray(transform.position, transform.TransformDirection(toTarget));

        //Enemy direction towards Target_Transform variable
        if (targetTransform /*Objetivo del enemigo*/)
        {
            if (Vector3.Dot(right, toTarget) > 0)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right), Color.yellow);
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left), Color.yellow);
            }
        }

        //Raycast hit detection
        if(Physics.Raycast(ray, out hit, 1))
        {
            if (hit.collider.isTrigger) 
                Attack();
        }
        else
        {
            Move();
        }
    }

    //Attacking behaviour
    void Attack()
    {
        print("Hit someone");
        Player.StartCoroutine("ReceiveDamage", 2);
    }

    //Moving behaviour
    void Move()
    {
        float movement = speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(transform.position, target.transform.position, movement);
    }
}
