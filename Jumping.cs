using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    // Member Variables & Objects
    public AudioSource jumping,firing;

    // Start is called before the first frame update
    void Start()
    {
        // objects set to stop before action is taken
        jumping = GetComponent<AudioSource>();
        firing = GetComponent<AudioSource>();
        firing.Stop();
        jumping.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        // if keys are pressed perform this action
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayJumping();
        }

        if (Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.G))
        {
            PlayFiring();
        }
    }

    // Jumping Sound Method
    // Sounds taken from Unity Assets Store (Zero Rare Home, 2020)
    public void PlayJumping()
    {
        jumping.Play();
    }

    // fireball sound method
    // Sounds taken from Unity Assets Store (Zero Rare Home, 2020)
    public void PlayFiring()
    {
        firing.Play();
    }
}
