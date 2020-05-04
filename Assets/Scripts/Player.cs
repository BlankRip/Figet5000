using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    GameObject mainCam;
    Vector3 targetVel;
    Vector3 currentVelRef;
    Quaternion turnAngle;
    float horizontalInput;
    float verticaleInput;
    bool jump;

    [SerializeField] float moveSpeed;
    [Range(0, 1)] [SerializeField] float moveSmothness;
    [Range(0, 1)] [SerializeField] float rotationSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] KeyCode jumpKey = KeyCode.Space;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentVelRef = Vector3.zero;
        mainCam = Camera.main.gameObject;
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
        targetVel = transform.rotation * targetVel;

        if (horizontalInput != 0 || verticaleInput != 0)
        {
            turnAngle = Quaternion.Euler(0, mainCam.transform.eulerAngles.y, 0);
            rb.rotation = Quaternion.Slerp(transform.rotation, turnAngle, rotationSpeed);
        }

        
        if(jump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jump = false;
        }
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVel, ref currentVelRef, moveSmothness);
    }
}
