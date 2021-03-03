using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    public float thrust = 1f;

    [SerializeField]
    public float rotationalThrust = 1f;

    private Rigidbody rb;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        ProcessRotation();
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            rb.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

        }
        else
        {
            audioSource.Stop();
        }

    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationalThrust);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationalThrust);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        //Freezing rotation temporarily so we can manually change rotation
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
