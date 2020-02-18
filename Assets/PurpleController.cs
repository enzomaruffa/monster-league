using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class PurpleController : MonoBehaviour
{
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = new Player(GetComponent<Rigidbody2D>());
    }

    // Update is called once per frame
    void Update()
    {
        player.Update(Input.GetKeyDown(KeyCode.UpArrow),
                        Input.GetKey(KeyCode.LeftArrow),
                        Input.GetKey(KeyCode.RightArrow),
                        Input.GetKey(KeyCode.M),
                        transform);
            
        //if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        //    rb.AddForce(Vector2.up * (force/4) * 3);
        //    else if (Input.GetKeyDown(KeyCode.W) && !isGrounded && !doubleJumped){
        //        doubleJumped = true;
        //        extraRotation = 2;
        //        timeLeft = 0.5f;
        //        float rotation = transform.rotation.z;
        //        Vector2 thrustDirection = new Vector2(-Mathf.Sin(rotation), Mathf.Cos(rotation));
        //        rb.AddForce(thrustDirection * force);
        //    }

        //// else if (Input.GetKeyDown(KeyCode.W) && !isGrounded)
        ////     // Fazer cambalhota

        //while (timeLeft > 0)
        //{
        //    Debug.Log("Rotation with time " + (rotateSpeed * extraRotation));
        //    timeLeft -= Time.deltaTime;
        //    extraRotation -= Time.deltaTime * 2;

        //}

        //Debug.Log("Rotation Speed" + (rotateSpeed * extraRotation));
        //if (Input.GetKey(KeyCode.D) && isGrounded)
        //    rb.AddForce(Vector3.right * speed);
        //else if (Input.GetKey(KeyCode.D) && !isGrounded)
        //    transform.Rotate(new Vector3(0, 0, -1) * rotateSpeed * extraRotation);

        //if (Input.GetKey(KeyCode.A) && isGrounded)
        //    rb.AddForce(Vector3.left * speed);
        //else if (Input.GetKey(KeyCode.A) && !isGrounded)
        //    transform.Rotate(new Vector3(0, 0, +1) * rotateSpeed * extraRotation);




        //if (Input.GetKey(KeyCode.Space)) {
        //    float rotation = transform.rotation.z;
        //    float rotationRadians = rotation;
        //    Debug.Log(rotation);            //Debug.LrotationRadiansog("Current rotation angle: " + rotationRadians);


        //    Debug.Log("Sin: " + Mathf.Sin(rotationRadians));
        //    Debug.Log("Cos: " + Mathf.Cos(rotationRadians));     //Debug.Log("Current rotation angle: " + rotationRadians);

        //    Vector2 thrustDirection = new Vector2(-Mathf.Sin(rotationRadians), Mathf.Cos(rotationRadians));

        //    //Debug.Log("Current thurst direction: " + thrustDirection.ToString());

        //    rb.AddForce(thrustDirection * thrustPower);
        //}
    }

    //make sure u replace "floor" with your gameobject name.on which player is standing
    void OnCollisionEnter2D(Collision2D collision)
    {
        player.OnCollisionEnter2D(collision);
    }
    
    //consider when character is jumping .. it will exit collision.
    void OnCollisionExit2D(Collision2D collision)
    {
        player.OnCollisionExit2D(collision);
    }
}
