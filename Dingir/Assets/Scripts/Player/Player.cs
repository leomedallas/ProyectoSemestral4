using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Controls input;
    public static Player _instance;

    [Header("Health Values")]
    public HealthBar healthBar;
    public int maxHealth = 20;
    public int currentHealth;

    [Header("Movement Values")]
    public int speed;
    Rigidbody rb;
    public Collider HitCol;
    public float direction;
    public float rotateSpeed;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        input = new Controls();
        input.Enable();
        rb = GetComponent<Rigidbody>();
    }

    private void OnDestroy()
    {
        input.Disable();
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        Vector3 dir = ctx.ReadValue<Vector3>();
        rb.velocity = new Vector3(dir.x * speed, 0, dir.z * speed);
        Debug.Log(dir);

        Vector3 pointToView = transform.position + dir;

        transform.LookAt(pointToView);
    }

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
        healthBar.SetHealth(currentHealth);
    }

    //Coroutine for player receiving damage
    IEnumerator ReceiveDamage(int _damage)
    {
        HitCol.enabled = false;
        TakeDamage(_damage);
        yield return new WaitForSeconds(2);
        HitCol.enabled = true;
    }
}
