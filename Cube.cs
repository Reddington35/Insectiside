using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Member Variables & Objects
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Cube>();
        transform.Rotate(new Vector3(90,0,0));
        rb.transform.localScale = new Vector3(6f, 4f, 10f);
    }
}
