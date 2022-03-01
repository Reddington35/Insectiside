using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // member variables and objects
    public Rigidbody rb;
    public ParticleSystem explode;
   
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Fire>();
        rb.transform.Rotate(new Vector3(90, 0, 0));
        rb.transform.localScale = new Vector3(3,10,3);
        explode.GetComponent<ParticleSystem>();
    }

    // if player is caught by fire or fireball collides with fire both are destroyed instantly and explode Particle System is instantiated
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Fireball")
        {
            Destroy(col.gameObject);
            Instantiate(explode, transform.position, Quaternion.identity);
            Debug.Log("Player Destroyed");
        }
    }
}