using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : Enemy, IEnemy
{
    public static BigEnemy _instance;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        maxHealth = 20;
        speed = 0.2f;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (this.currentHealth == 0)
        {
            this.gameObject.SetActive(false);
            Destroy(this);
        }
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
        if (targetTransform)
        {
            if (Vector3.Dot(right, toTarget) > 0)
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right), Color.yellow);
            else
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left), Color.yellow);
        }

        //Raycast hit detection
        if (Physics.Raycast(ray, out hit, 1))
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
    public void Attack()
    {
        Player._instance.StartCoroutine("ReceiveDamage", 2);
    }

    //Moving behaviour
    public void Move(Vector3 dir)
    {
        rb.MovePosition((Vector3)transform.position + (dir * speed * Time.deltaTime));
    }

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
        healthBar.SetHealth(currentHealth);
    }
}