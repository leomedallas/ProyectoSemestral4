using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public HealthBar healthBar;
    public Rigidbody rb;
    public GameObject target;
    public Transform targetTransform;

    public float speed;
    public int maxHealth;
    public int currentHealth;
    
}

public interface IEnemy 
{
    public void TakeDamage(int _damage);
    public void Attack();
    public void Move(Vector3 dir);
}