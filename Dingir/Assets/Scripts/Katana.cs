using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Katana : MonoBehaviour
{
    Animator anim;
    public GameObject col1;

    public int combo;
    public bool attacking;

    private void Start()
    {
        anim = GetComponent<Animator>();
        col1.gameObject.SetActive(false);
    }

    private void Update()
    {
        bool space = Keyboard.current.spaceKey.wasPressedThisFrame;
        if (space && !attacking) 
            Combo();
    }

    public void StartCombo()
    {
        col1.gameObject.SetActive(true);
        attacking = false;
        if (combo < 3)
            combo++;
    }

    public void Combo()
    {
        attacking = true;
        anim.SetTrigger("" + combo);  
    }

    public void FinishCombo()
    {
        col1.gameObject.SetActive(false);
        attacking = false;
        combo = 0;
    }
}
