using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    #region Variables
    public Controls input;
    public static Player Instance;

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

    /*[Header("UI")]
    [SerializeField] GameObject Dialogue;
    [SerializeField] GameObject Dialogue1;
    [SerializeField] GameObject square;
    [SerializeField] GameObject susanoo;
    [SerializeField] GameObject amaterasu;*/

    [Header("Attack")]
    public GameObject col;
    public int combo;
    public bool attacking;

    [Header("EnemiesActive")]
    [SerializeField] GameObject LittleEnemy;
    #endregion

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        input = new Controls();
        input.Enable();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        //StartCoroutine("DesactiveCollider");
    }

    private void Update()
    {
        bool space = Keyboard.current.spaceKey.wasPressedThisFrame;
        if (space && !attacking)
            Combo();
    }

    private void OnDestroy()
    {
        input.Disable();
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        Vector3 dir = ctx.ReadValue<Vector3>();
        anim.SetBool("Running", dir != Vector3.zero);
        anim.SetBool("IsHit", false);
        rb.velocity = new Vector3(dir.x * speed, 0, dir.z * speed);

        Vector3 pointToView = transform.position + dir;

        transform.LookAt(pointToView);
    }
    /*IEnumerator DesactiveCollider()
    {
        Dialogue1.SetActive(false);
        rb.constraints = RigidbodyConstraints.FreezeAll;
        yield return new WaitForSeconds(8);
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        Dialogue.SetActive(false);
        susanoo.SetActive(false);
        Dialogue1.SetActive(true);
        amaterasu.SetActive(true);
        yield return new WaitForSeconds(5);
        Dialogue1.SetActive(false);
        square.SetActive(false);
        amaterasu.SetActive(false);
    }*/

    public void TakeDamage(int _damage)
    {
        anim.SetBool("IsHit", true);
        currentHealth -= _damage;
        healthBar.SetHealth(currentHealth);
    }

    public void StartCombo()
    {
        attacking = false;
        if (combo < 3)
            combo++;

        col.SetActive(true);
    }

    public void Combo()
    {
        attacking = true;
        anim.SetTrigger("" + combo);
    }

    public void FinishCombo()
    {
        attacking = false;
        combo = 0;

        col.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BigEnemyCollider"))
        {
            TakeDamage(3);
        }
        
        if (other.gameObject.CompareTag("LittleEnemyCollider"))
        {
            TakeDamage(1);
        }
    }
}
