using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    // Member Variables & Objects
    public Rigidbody rb;
    private Vector3 startPos;
    private Vector3 endPos;
    int max = 4;
    int speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Platforms>();
        transform.Rotate(new Vector3(90, 0, 0));
        rb.transform.localScale = new Vector3(6f, 1f,10f);

        startPos = transform.position;
        endPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // same as queen
        endPos.y = startPos.y + (max * Mathf.Sin(Time.time * speed));
        transform.position = endPos;
    }
}
