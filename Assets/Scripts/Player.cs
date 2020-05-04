using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    Vector3 targetVel;
    Vector3 currentVelRef;
    float horizontalInput;
    float verticaleInput;
    bool jump;

    [SerializeField] float moveSpeed;
    [SerializeField] float moveSmothness;
    [SerializeField] float jumpForce;
    [SerializeField] KeyCode jumpKey = KeyCode.Space;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentVelRef = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") * moveSpeed;
        verticaleInput = Input.GetAxis("Vertical") * moveSpeed;

        if (Input.GetKeyDown(jumpKey))
            jump = true;
    }

    private void FixedUpdate()
    {
        Movement(horizontalInput, verticaleInput, ref jump);
    }

    void Movement(float horizontalInput, float verticleInput, ref bool jump)
    {
        targetVel = new Vector3(horizontalInput, rb.velocity.y, verticleInput);
        if(jump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jump = false;
        }
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVel, ref currentVelRef, moveSmothness);
    }
}
