using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : MonoBehaviour
{
    // Member Variables & Objects
    public Rigidbody rb;
    public AudioSource hit;
    public GameObject Explode, Lemon;
    public Animator animator;
    private Vector3 startPos;
    private Vector3 endPos;
    public int health;
    int max = 4;
    int speed = 1;


    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Queen>();
        rb.transform.position = new Vector3(9f, -20f, -30f);
        transform.Rotate(180, 90, 90);
        rb.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        rb.mass = 20f;
        startPos = transform.position;
        endPos = transform.position;
        setHealth(200);
        animator.SetTrigger("Idle");
        hit.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        // code used to nmove platforms over and back, same code reused for moving enemy Spiders over and back
        // this took ages for me to get an elegent solution for this problem , I read up online about this and found a math function that can be used in this context
        // (movement, 2020)
        endPos.y = startPos.y + (max * Mathf.Sin(Time.time * speed));
        transform.position = endPos;

        animator.SetTrigger("Walk");

        // Raycast created here to show lines from enemy to objects at a distance of 50
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

    // method to set  Spider Queens Health
    public void setHealth(int new_health)
    {
        health = new_health;
    }

    // Method for if a fireball hits queen  , health is reduced 
    // if health less than on queen is destroyed , explode particle system is displayed and lemon object is dropped
    // player scrore is increased by 900 as Queen has more health (is kind of Boss Charachter!)
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Fireball")
        {
            Debug.Log("Queen hit");
            hit.Play();
            setHealth(health - 20);
            Destroy(col.gameObject);

            Debug.Log(health);
            if (health < 1)
            {
                Destroy(this.gameObject);
                Instantiate(Explode, transform.position, Quaternion.identity);
                Instantiate(Lemon, transform.position, Quaternion.identity);
                GameManager.setScore(GameManager.score + 900);
            }
        }
    }

}
