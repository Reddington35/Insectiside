﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : MonoBehaviour
{
    // Member Variables & Objects
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        rb.transform.Rotate(new Vector3(90, 0, 0));
        rb.transform.localScale = new Vector3(200f, 200f, 200f);
        rb.mass = 0.5f;
    }

    // method for handling collissions with fruit objects and adding score for player
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            GameManager.setScore(GameManager.score + 300);
            Debug.Log("Strawberry collected");
        }
    }
}
