using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Katana : MonoBehaviour
{
    Animator anim;
    public int combo;
    public bool attacking;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        bool space = Keyboard.current.spaceKey.wasPressedThisFrame;
        if (space && !attacking)
        {
            Combo();
        }
        
    }

    public void StartCombo()
    {
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
        attacking = false;
        combo = 0;
    }
}
