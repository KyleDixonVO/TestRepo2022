using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public bool jump;
    public bool grounded;
    public bool moveForward;
    public bool moveBackward;
    public bool moveLeft;
    public bool moveRight;
    public float speed;
    public RaycastHit groundedRay;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        rb = GameObject.Find("Player").GetComponent<Rigidbody>();
        grounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space Pressed");
            jump = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jump = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Move Left");
            moveLeft = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            moveLeft = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Move Right");
            moveRight = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            moveRight = false;
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Move Back");
            moveBackward = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            moveBackward = false;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Move Forward");
            moveForward = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            moveForward = false;
        }
    }

    private void FixedUpdate()
    {
        if (moveForward == true)
        {
            rb.AddForce(new Vector3(0, 0, speed));
        }

        if (moveBackward == true)
        {
            rb.AddForce(new Vector3(0, 0, -speed));
        }

        if (moveLeft == true)
        {
            rb.AddForce(new Vector3(-speed, 0, 0));
        }

        if (moveRight == true)
        {
            rb.AddForce(new Vector3(speed, 0, 0));
        }

        if (jump == true && grounded == true)
        {
            rb.AddForce(new Vector3(0, speed*speed*2, 0));
            //grounded = false;
        }

        checkGrounded();
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.gameObject.tag == "Floor")
    //    {
    //        grounded = true;
    //    }
    //}

    private void checkGrounded()
    {
        //Physics.SphereCast(this.gameObject.transform.position, 0.25f, -transform.up, out groundedRay);
        if (Physics.CheckSphere(this.gameObject.transform.position, 1.0f))
        {
            Debug.Log("Grounded");
            grounded = true;
        }
    }
}
