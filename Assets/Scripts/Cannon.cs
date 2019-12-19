using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectile;
    public float rotationSpeed = 100.0f;
    public float cannonSpeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        rotation *= Time.deltaTime;
        transform.Rotate(0, 0, rotation);


        if (Input.GetButtonDown("Fire1"))
        {
            var swag = Instantiate(projectile, this.transform.position, this.transform.rotation);
            var rb = swag.GetComponent<Rigidbody2D>();

            rb.AddForce((this.transform.rotation * Vector2.up) * cannonSpeed);
        }
        
    }
}
