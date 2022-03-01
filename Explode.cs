using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    // Member Variables & Objects
    private ParticleSystem ps;
    public AudioSource explosion;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        // Coroutine called
        StartCoroutine(WaitAndDestroy());
    }

    // Coroutine Method that frees up memory of Particle System
    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    // Explosion Sound method 
    // Sounds taken from Unity Assets Store (Zero Rare Home, 2020)
    public void PlayExposion()
    {
        explosion.Play();
    }
}
