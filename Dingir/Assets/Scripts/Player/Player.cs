using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    #region variables
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
    [SerializeField] GameObject square;
    [SerializeField] GameObject susanoo;
    [SerializeField] GameObject amaterasu;

    [Header("Attack")]
    public GameObject col;
    public int combo;
    public bool attacking;

    [Header("EnemiesActive")]
<<<<<<< HEAD
    [SerializeField] GameObject[] LittleEnemmyzone1;
    [SerializeField] GameObject BigEnemmyz1;
    [SerializeField] GameObject[] LittleEnemyzone2;
    [SerializeField] GameObject[] BigEnemmyz2;
    [SerializeField] GameObject[] LittleEnemyzone3;
    [SerializeField] GameObject[] BigEnemmyz3;
    public int killcount;
    [SerializeField] Collider[] zoneCol;
=======
    [SerializeField] GameObject LittleEnemy;
>>>>>>> Fixed
    #endregion
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

    private void Update()
    {
        bool space = Keyboard.current.spaceKey.wasPressedThisFrame;
        if (space && !attacking)
            Combo();
<<<<<<< HEAD

        if(killcount >= 5)
        {
            zoneCol[0].isTrigger = true;
        }
        else if (killcount >= 10)
        {
            zoneCol[1].isTrigger = true;
        }
        else if (killcount >= 15)
        {
            zoneCol[2].isTrigger = true;
        }
=======
>>>>>>> Fixed
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
<<<<<<< HEAD
    #region colliders&enemys
=======
>>>>>>> Fixed
    IEnumerator DesactiveCollider()
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
<<<<<<< HEAD
        yield return new WaitForSeconds(5);
        foreach (GameObject enemy in LittleEnemmyzone1)
        {
            enemy.SetActive(true);
            yield return new WaitForSeconds(4);
        }
        yield return new WaitForSeconds(5);
        BigEnemmyz1.SetActive(true);
    }
    #endregion
=======
        //yield return new WaitForSeconds(5);
        //LittleEnemy.SetActive(true);
    }
>>>>>>> Fixed
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
<<<<<<< HEAD
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("zone2"))
        {
            StartCoroutine("Invokeenemyszone2");
        }
        else if (other.CompareTag("zone3"))
        {
            StartCoroutine("Invokeenemyszone3");
        }
    }

    #region invoke
    IEnumerator Invokeenemyszone2()
    {
        foreach (GameObject enemy in LittleEnemyzone2)
        {
            enemy.SetActive(true);
            yield return new WaitForSeconds(2.5f);
        }
        foreach(GameObject Benemy in BigEnemmyz2)
        {
            Benemy.SetActive(true);
            yield return new WaitForSeconds(2.5f);
        }
    }
    IEnumerator Invokeenemyszone3()
    {
        foreach (GameObject enemy in LittleEnemyzone3)
        {
            enemy.SetActive(true);
            yield return new WaitForSeconds(2f);
        }
        foreach (GameObject Benemy in BigEnemmyz3)
        {
            Benemy.SetActive(true);
            yield return new WaitForSeconds(2.5f);
        }
    }
#endregion
=======
>>>>>>> Fixed
}
