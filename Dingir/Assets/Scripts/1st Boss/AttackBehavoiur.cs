using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavoiur : MonoBehaviour
{
    public Movement movScript;
    public Collider bigCol;
    public Collider smallCol;
    int currentHealth = 50;
    public HealthBar healthBar;
    public float Cooldown = 5f;

    List<System.Func<IEnumerator>> routines = new List<System.Func<IEnumerator>>();

    public GameObject Target;
    public bool Attacking;

    void Start()
    {
        bigCol.enabled = false;
        smallCol.enabled = false;
        Attacking = false;
        Target = GameObject.FindGameObjectWithTag("Player");

        routines.Add(Attack1);
        routines.Add(Attack2);
    }

    void Update()
    {
        transform.LookAt(Target.transform);

        if(!Attacking && Cooldown>4f)
        {
            bigCol.enabled = false;
            smallCol.enabled = false;
            changePos();
        }
        else
        {
            Cooldown = Cooldown - Time.deltaTime;
            StartCoroutine(routines[Random.Range(0,routines.Count)]());
        }

        if(Cooldown<= 0)
        {
            Cooldown = 5f;
        }
    }

    void changePos()
    {
        Attacking = false;
        movScript.posRandomizer();
        movScript.posSpawn(this.transform);
        Cooldown = 3;
        Attacking = true;
    }

    void areaAttack()
    {
        Attacking = true;
        bigCol.enabled = true;
    }

    void directAttack()
    {
        Attacking = true;
        smallCol.enabled = true;
    }

    IEnumerator Attack1()
    {
        areaAttack();
        yield return new WaitForSeconds(1);
        Attacking = false;
    }
    IEnumerator Attack2()
    {
        directAttack();
        yield return new WaitForSeconds(1);
        Attacking = false;
    }

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
        healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Katana"))
        {
            TakeDamage(5);
        }
    }
}
