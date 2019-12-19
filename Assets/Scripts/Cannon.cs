using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectile;
    public float rotationSpeed = 100.0f;
    public float cannonSpeed = 100.0f;
    public int playerId = 1;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = Input.GetAxis("Vertical" + playerId) * rotationSpeed;
        rotation *= Time.deltaTime;
        transform.Rotate(0, 0, rotation);


        if (Input.GetButtonDown("Fire" + playerId))
        {
            animator.SetBool("isFiring", true);
            var swag = Instantiate(projectile, this.transform.position, this.transform.rotation);
            var rb = swag.GetComponent<Rigidbody2D>();

            var offsetRotation = Quaternion.Euler(0, 0, 65) * this.transform.rotation;
            rb.transform.position = rb.transform.position + (offsetRotation * Vector2.up)*1;
            rb.AddForce((offsetRotation * Vector2.up) * cannonSpeed);
        }
        else
        {
            animator.SetBool("isFiring", false);
        }
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Player : " + playerId + " is eliminated!");
    }

}
