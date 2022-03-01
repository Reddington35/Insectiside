using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Fireball>();
        rb.transform.localScale = new Vector3(1, 1, 1);
        rb.velocity = Vector3.right * 20.0f;
        rb.GetComponentInChildren<MeshRenderer>().material.color = Color.red;

    }

    public void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
