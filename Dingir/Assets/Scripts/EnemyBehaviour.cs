using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    
    [HideInInspector] Rigidbody rb;
    [HideInInspector] BoxCollider BoxCol;
    public Player Player;

    [Header("Targets")]
    public GameObject Target;
    public Transform Target_Transform;
    
    [Header("Enemy Variables")]
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

        Vector3 Right = transform.TransformDirection(Vector3.right);
        Vector3 toTarget = Target_Transform.position - transform.position;

        Ray ray = new Ray(transform.position, transform.TransformDirection(toTarget));

        //Enemy direction towards Target_Transform variable
        if (Target_Transform /*Objetivo del enemigo*/)
        {
            if (Vector3.Dot(Right, toTarget) > 0)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right), Color.yellow);
                print("Esta a mi derecha");
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left), Color.yellow);
                print("Esta a mi izquierda");
            }
        }

        //Raycast hit detection
        if(Physics.Raycast(ray, out hit, 1))
        {
            if (hit.collider.isTrigger)
            { 
                Attack();
            }
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
        this.transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, movement);
    }
}
