using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Controls input;
    public int life = 20;
    [SerializeField] private int speed = 15;
    Rigidbody rb;
    public Collider HitCol;

    void Start()
    {
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
    }

    void Update()
    {
        Keyboard kb = InputSystem.GetDevice<Keyboard>(); 
    }

    //Coroutine for player receiving damage
    IEnumerator ReceiveDamage()
    {
        HitCol.enabled = false;
        life = life - 2;
        yield return new WaitForSeconds(2);
        HitCol.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
