using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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
    Animator anim;
    Rigidbody rb;
    public Collider HitCol;
    public float direction;
    public float rotateSpeed;

    [Header("UI")]
    [SerializeField] GameObject Dialogue;
    [SerializeField] GameObject Dialogue1;
    [SerializeField] GameObject hb;

    [Header("EnemiesActive")]
    [SerializeField] GameObject LittleEnemy;
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
        anim = GetComponent<Animator>();
        StartCoroutine("DesactiveCollider");
    }

    private void OnDestroy()
    {
        input.Disable();
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        Vector3 dir = ctx.ReadValue<Vector3>();
        anim.SetBool("Running", dir != Vector3.zero);
        rb.velocity = new Vector3(dir.x * speed, 0, dir.z * speed);
        Debug.Log(dir);

        Vector3 pointToView = transform.position + dir;

        transform.LookAt(pointToView);
    }
    IEnumerator DesactiveCollider()
    {
        hb.SetActive(false);
        Dialogue1.SetActive(false);
        rb.constraints = RigidbodyConstraints.FreezeAll;
        yield return new WaitForSeconds(8);
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        Dialogue.SetActive(false);
        hb.SetActive(true);
        Dialogue1.SetActive(true);
        yield return new WaitForSeconds(5);
        Dialogue1.SetActive(false);
        yield return new WaitForSeconds(5);
        LittleEnemy.SetActive(true);
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