using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    // Member Variables & Objects
    public Rigidbody rb;
    public GameObject Lemon, WaterMelon, Strawberry;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Tree>();
        rb.transform.position = new Vector3(56f,-15,-30);
        transform.Rotate(new Vector3(90, 0, 0));
        rb.transform.localScale = new Vector3(3f, 3f, 3f);
        rb.mass = 0.5f;
    }

    // Method that collission with tree will spawn pick-ups
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Instantiate(Lemon, transform.position, Quaternion.identity);
            Instantiate(Strawberry, transform.position, Quaternion.identity);
            Instantiate(WaterMelon, transform.position, Quaternion.identity);
        }
    }
}
