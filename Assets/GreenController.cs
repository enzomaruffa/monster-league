using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenController : MonoBehaviour
{
    bool isGrounded = true;
    private float force = 300;
    private float speed = 2;
    private float rotateSpeed = 2;
    bool doubleJumped = false;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.centerOfMass = new Vector2(0, -0.27f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            rb.AddForce(Vector2.up * force/2);
            else if (Input.GetKeyDown(KeyCode.W) && !isGrounded && !doubleJumped){
                doubleJumped = true;
                float rotation = transform.rotation.z;
                Vector2 thrustDirection = new Vector2(-Mathf.Sin(rotation), Mathf.Cos(rotation));
                rb.AddForce(thrustDirection * force);
            }
            
        // else if (Input.GetKeyDown(KeyCode.W) && !isGrounded)
        //     // Fazer cambalhota

        if (Input.GetKey(KeyCode.D) && isGrounded)
            rb.AddForce(Vector3.right * speed);
        else if (Input.GetKey(KeyCode.D) && !isGrounded)
            transform.Rotate(new Vector3(0, 0, -1) * rotateSpeed);

        if (Input.GetKey(KeyCode.A) && isGrounded)
            rb.AddForce(Vector3.left * speed);
        else if (Input.GetKey(KeyCode.A) && !isGrounded)
            transform.Rotate(new Vector3(0, 0, +1) * rotateSpeed);




        if (Input.GetKey(KeyCode.Space)) {
            float rotation = transform.rotation.z;
            float rotationRadians = rotation;
            Debug.Log(rotation);            //Debug.LrotationRadiansog("Current rotation angle: " + rotationRadians);


            Debug.Log("Sin: " + Mathf.Sin(rotationRadians));
            Debug.Log("Cos: " + Mathf.Cos(rotationRadians));     //Debug.Log("Current rotation angle: " + rotationRadians);

            Vector2 thrustDirection = new Vector2(-Mathf.Sin(rotationRadians), Mathf.Cos(rotationRadians));

            //Debug.Log("Current thurst direction: " + thrustDirection.ToString());

            rb.AddForce(thrustDirection * force/100);
        }
    }

    //make sure u replace "floor" with your gameobject name.on which player is standing
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter");
        if (collision.gameObject.name == "ground")
        {
            Debug.Log("Changing to grounded");
            isGrounded = true;
            doubleJumped = false;
        }
    }
    
    //consider when character is jumping .. it will exit collision.
    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("OnCollisionExit");
        if (collision.gameObject.name == "ground")
        {
            Debug.Log("Changing to not grounded");
            isGrounded = false;
            doubleJumped = false;
        }
    }
}
