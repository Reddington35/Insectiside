using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insect : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject Explode,Straw;
    public Animator animator;
    private Vector3 startPos;
    private Vector3 endPos;
    public AudioSource hit;
    public int health;
    int max = 4;
    int speed = 1;


    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Insect>();
        hit = GetComponent<AudioSource>();
        rb.transform.position = new Vector3(-37f, -20f, -30f);
        transform.Rotate(180,90,90);
        rb.transform.localScale = new Vector3(1f, 1f, 1f);
        rb.mass = 10f;
        startPos = transform.position;
        endPos = transform.position;
        setHealth(100);
        hit.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        // same as Queen and Platform
        endPos.y = startPos.y + (max * Mathf.Sin(Time.time * speed));
        transform.position = endPos;
        // animations taken from unity asset store
        animator.SetTrigger("Walk_Cycle_1");

        // Raycast created here
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;


        if (Physics.Raycast(ray, out hitInfo, 50))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
        }

        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 50, Color.green);
        }
    }

    // method to set health
    public void setHealth(int new_health)
    {
        health = new_health;
    }

    // method that checks if Inset is hit if so deduct health 
    // if health less than one Destroy object and instantiate explosion + set score
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Fireball")
        {
            Debug.Log("bug hit");
            hit.Play();
            setHealth(health - 20);
            Destroy(col.gameObject);

            Debug.Log(health);
            if (health < 1)
            {
                Destroy(this.gameObject);
                Instantiate(Explode, transform.position, Quaternion.identity);
                Instantiate(Straw, transform.position, Quaternion.identity);
                GameManager.setScore(GameManager.score + 400);
            }
        }
    }
}
