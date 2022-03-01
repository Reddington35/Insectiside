using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    //public CharacterController controller;
    public Animator anim;
    private bool Idle = true;
    private bool Walk = false;
    private bool Jump = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && !Walk)
        {
            anim.SetBool("Walk", true);
        }

        if (Input.GetKey(KeyCode.W) && Walk)
        {
            anim.SetBool("Walk", false);
        }

        if (Input.GetKey(KeyCode.Space) && !Jump)
        {
            anim.SetBool("Jump", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Jump)
        {
            anim.SetBool("Jump", false);
        }

    }
}
