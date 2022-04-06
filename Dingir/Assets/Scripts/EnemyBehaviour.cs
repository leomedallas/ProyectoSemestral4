using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Player Player;

    [Header("Target Values")]
    public Transform targetTransform;
    Rigidbody rb;
    
    [Header("Enemy Values")]
    [SerializeField] float speed;
    public HealthBar healthBar;
    public int maxHealth;
    public int currentHealth;
    float minDistance = 1f;

    public static EnemyBehaviour instance;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (this.gameObject.CompareTag("LittleEnemy"))
            maxHealth = 10;
        else if (this.gameObject.CompareTag("BigEnemy"))
            maxHealth = 20;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        instance = this;
    }


    void FixedUpdate()
    {
        //Update Variables
        Vector3 direction = targetTransform.position - transform.position;

        RaycastHit hit;

        Vector3 right = transform.TransformDirection(Vector3.right);
        Vector3 toTarget = targetTransform.position - transform.position;

        Ray ray = new Ray(transform.position, transform.TransformDirection(toTarget));

        //Enemy direction towards Target_Transform variable
        if (targetTransform /*Objetivo del enemigo*/)
        {
            if (Vector3.Dot(right, toTarget) > 0)
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right), Color.yellow);
            else
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left), Color.yellow);
        }

        //Raycast hit detection
        if(Physics.Raycast(ray, out hit, 1))
        {
            if (hit.collider.isTrigger) 
                Attack();
        }
        else
        {
            Move(direction);
        }
    }

    //Attacking behaviour
    void Attack()
    {
        print("Hit someone");
        Player.StartCoroutine("ReceiveDamage", 2);
    }

    //Moving behaviour
    void Move(Vector3 dir)
    {
        rb.MovePosition((Vector3)transform.position + (dir * speed * Time.deltaTime));
    }

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
        healthBar.SetHealth(currentHealth);
    }
}
