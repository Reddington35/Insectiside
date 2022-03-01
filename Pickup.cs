using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioSource pickup;
    // Start is called before the first frame update
    void Start()
    {
        pickup = GetComponent<AudioSource>();
        pickup.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "watermelon")
        {
            pickup.Play();
        }
    }
}
