using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Controls input;
    public int speed;
    Rigidbody rb;

    void Start()
    {
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
}
