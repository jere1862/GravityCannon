using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 initalForce;
    public List<Planet> planets;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Planet");
        foreach (GameObject obj in objects)
        {
            planets.Add(obj.GetComponent<Planet>());
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Planet planet in planets)
        {
            var heading = this.transform.position - planet.transform.position;
            heading /= -2*heading.magnitude;
            
            rb.AddForce(heading * planet.gravity);
        }
        if(Mathf.Abs(rb.velocity.magnitude) < 0.1f && rb.velocity.magnitude != 0)
        {
            Destroy(this.gameObject);
        }
    }
}
