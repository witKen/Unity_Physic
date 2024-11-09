using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Declare variables for movement
    public float moveSpeed;
    private float maxSpeed = 0f;

    // Hold input for movement along x and z
    private Vector3 input;

    // Start is called before the first frame update
    void Start()
    {   // Max speed will be set to 10 when game start
        maxSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        // Returns value of -1, 0 or 1 based on input key (w,a,s,d)
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        // Check if movement reach maximum speed
        if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
        {
            // Apply force to player and scaled by movement
            GetComponent<Rigidbody>().AddForce(input * moveSpeed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            //other.gameObject.SetActive(false);
            //Destroy(other.gameObject);
            other.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
