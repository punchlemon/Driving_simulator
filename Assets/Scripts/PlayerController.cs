using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float accelerator = 35f;
    private float turnTorque = 0.5f;
    private float turnSpeed = 4f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody carRigidbody;

    // Start is called before the first frame update
    void Start()
    {   
        carRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        carRigidbody.AddForce(transform.forward * accelerator * forwardInput, ForceMode.Force);
        //carRigidbody.AddTorque(transform.up * turnTorque * horizontalInput * carRigidbody.velocity.magnitude, ForceMode.Impulse);
        // Move the car forward based on vertical input
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Rotates the car based on horizontal input
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput * carRigidbody.velocity.magnitude);
    }
}
