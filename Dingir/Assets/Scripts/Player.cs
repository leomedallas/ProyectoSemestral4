using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Controls input;

    [Header("Health Values")]
    public HealthBar healthBar;
    public int MaxLife = 20;
    public int currentLife;

    public int speed;
    Rigidbody rb;
    public Collider HitCol;

    void Start()
    {
        currentLife = MaxLife;

        input = new Controls();
        input.Enable();
        //input.Player.Movement.performed += Move;
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
    }

    void Update()
    {
        Keyboard kb = InputSystem.GetDevice<Keyboard>(); 
    }

    //Coroutine for player receiving damage
    IEnumerator ReceiveDamage(int damage)
    {
        HitCol.enabled = false;
        currentLife = currentLife -= damage;
        yield return new WaitForSeconds(2);
        HitCol.enabled = true;
    }
}
