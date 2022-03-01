using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    // Member Variables & Objects
    public Rigidbody rb;
    public AudioSource hit;
    public GameObject Explode;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Castle>();
        hit = GetComponent<AudioSource>();
        transform.Rotate(new Vector3(90,0,0));
        rb.transform.localScale = new Vector3(1f, 1f, 1f);
        setHealth(100);
        hit.Stop();
    }

    public void setHealth(int new_health)
    {
        health = new_health;
    }

    // method for handling collissions with Castle object and adding score for player
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Fireball")
        {
            Debug.Log("Castle hit");
            hit.Play();
            setHealth(health - 20);
            Destroy(col.gameObject);

            Debug.Log(health);
            if (health < 1)
            {
                Destroy(this.gameObject);
                Instantiate(Explode, transform.position, Quaternion.identity);
                GameManager.setScore(GameManager.score + 1000);
            }
        }
    }

}
