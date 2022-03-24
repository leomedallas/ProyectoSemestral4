using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Controls input;
    [SerializeField] private int speed = 15;

    public int life = 20;
    public Collider HitCol;
    Vector3 dir;

    Rigidbody rb;
    public float jumpForce;

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
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(dir.x * speed, 0, dir.z * speed);
    }
    public void Jump(InputAction.CallbackContext ctx)
    {
        rb.AddForce(transform.up * jumpForce);
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        dir = ctx.ReadValue<Vector3>();
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
