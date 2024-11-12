using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;

    Rigidbody m_Rigidbody;
    Vector3 m_Movement;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);

        m_Rigidbody.AddForce(m_Movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            //other.gameObject.SetActive(false);
            //Destroy(other.gameObject);
            other.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    //void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.CompareTag("PickUp"))
    //    {
    //        other.gameObject.GetComponent<Renderer>().material.color = Color.blue;
    //    }
    //}

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
