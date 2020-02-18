using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{


    class Player
    {
        bool isGrounded = true;
        private float force = 200;
        private float speed = 2;
        private float rotateSpeed = 1f;
        bool doubleJumped = false;
        private float extraRotation = 1f;
        public float timeLeft = 0f;
        public float thrustPower = 3f;
        private Rigidbody2D rb;

        public Player(Rigidbody2D _rb)
        {
            rb = _rb;
            rb.centerOfMass = new Vector2(0, -0.27f);
        }

        public void Update(bool up, bool left, bool right, bool space, Transform t)
        {
            if (up && isGrounded)
                rb.AddForce(Vector2.up * (force / 4) * 3);
            else if (up && !isGrounded && !doubleJumped)
            {
                doubleJumped = true;
                extraRotation = 2;
                timeLeft = 0.5f;
                float rotation = t.rotation.z;
                Vector2 thrustDirection = new Vector2(-Mathf.Sin(rotation), Mathf.Cos(rotation));
                rb.AddForce(thrustDirection * force);
            }

            // else if (up && !isGrounded)
            //     // Fazer cambalhota

            while (timeLeft > 0)
            {
                Debug.Log("Rotation with time " + (rotateSpeed * extraRotation));
                timeLeft -= Time.deltaTime;
                extraRotation -= Time.deltaTime * 2;

            }

            Debug.Log("Rotation Speed" + (rotateSpeed * extraRotation));
            if (right && isGrounded)
                rb.AddForce(Vector3.right * speed);
            else if (right && !isGrounded)
                t.transform.Rotate(new Vector3(0, 0, -1) * rotateSpeed * extraRotation);

            if (left && isGrounded)
                rb.AddForce(Vector3.left * speed);
            else if (left && !isGrounded)
                t.transform.Rotate(new Vector3(0, 0, +1) * rotateSpeed * extraRotation);




            if (space)
            {
                float rotation = t.transform.rotation.z;
                float rotationRadians = rotation;
                Debug.Log(rotation);            //Debug.LrotationRadiansog("Current rotation angle: " + rotationRadians);


                Debug.Log("Sin: " + Mathf.Sin(rotationRadians));
                Debug.Log("Cos: " + Mathf.Cos(rotationRadians));     //Debug.Log("Current rotation angle: " + rotationRadians);

                Vector2 thrustDirection = new Vector2(-Mathf.Sin(rotationRadians), Mathf.Cos(rotationRadians));

                //Debug.Log("Current thurst direction: " + thrustDirection.ToString());

                rb.AddForce(thrustDirection * thrustPower);
            }
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("OnCollisionEnter");
            if (collision.gameObject.name == "ground")
            {
                Debug.Log("Changing to grounded");
                isGrounded = true;
                timeLeft = 0;
                doubleJumped = false;
                extraRotation = 1;
            }
        }

        //consider when character is jumping .. it will exit collision.
        public void OnCollisionExit2D(Collision2D collision)
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


}
