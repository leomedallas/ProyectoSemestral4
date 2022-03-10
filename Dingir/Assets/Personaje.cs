using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Personaje : MonoBehaviour
{
    [SerializeField] Rigidbody rbody;
    public float speed;
    public Controles input; // Controles = > Es el nombre del archivo  de configuracion 

    void Start()
    {
        rbody = GetComponent<Rigidbody>();

        input = new Controles();
        input.Enable(); // Se tiene que encender 

        input.Personaje.Movimiento.performed += ctx => Move(ctx.ReadValue<Vector3>());
        input.Personaje.Saltar.performed += ctx => Jump(ctx.ReadValue<Vector3>());

    }

    private void OnDestroy()
    {
        input.Disable();
    }

    public void MoveAction(InputAction.CallbackContext ctx)
    {
        Vector3 dir = ctx.ReadValue<Vector3>();
        rbody.velocity = dir * speed;
    }

    void Move(Vector3 dir)
    {
        //print(dir);
    }

    void Jump(Vector3 dir)
    {

    }

    void JumpAction(InputAction.CallbackContext ctx)
    {
        Vector3 dir = ctx.ReadValue<Vector3>();
    }

    void Update()
    {
        Keyboard kb = InputSystem.GetDevice<Keyboard>();
        Mouse mouse = InputSystem.GetDevice<Mouse>();
        Gamepad gamepad = InputSystem.GetDevice<Gamepad>();

        if(mouse.leftButton.wasPressedThisFrame)
        {
            print("Fue presionado el boton del norte de un control (en el xbox es Y)");
        }

        if(kb.pKey.wasPressedThisFrame)
        {
            print("La tecla P fue preisonada");
        }
    }
}
