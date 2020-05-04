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
    bool sprinting;

    [SerializeField] PlayerSettings currentSettings;

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
        horizontalInput = Input.GetAxis("Horizontal") * currentSettings.moveSpeed;
        verticaleInput = Input.GetAxis("Vertical") * currentSettings.moveSpeed;

        if (Input.GetKeyDown(currentSettings.jumpKey))
            jump = true;

        if (Input.GetKeyDown(KeyCode.LeftShift))
            sprinting = true;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            sprinting = false;
    }

    private void FixedUpdate()
    {
        Movement(horizontalInput, verticaleInput, ref jump);
    }

    void Movement(float horizontalInput, float verticleInput, ref bool jump)
    {
        if(sprinting)
        {
            horizontalInput = horizontalInput * currentSettings.sprintSpeedMultiplier;
            verticleInput = verticleInput * currentSettings.sprintSpeedMultiplier;
        }

        targetVel = new Vector3(horizontalInput, rb.velocity.y, verticleInput);
        targetVel = transform.rotation * targetVel;

        if (horizontalInput != 0 || verticaleInput != 0)
        {
            turnAngle = Quaternion.Euler(0, mainCam.transform.eulerAngles.y, 0);
            rb.rotation = Quaternion.Slerp(transform.rotation, turnAngle, currentSettings.rotationSpeed);
        }

        
        if(jump)
        {
            rb.AddForce(Vector3.up * currentSettings.jumpForce, ForceMode.Impulse);
            jump = false;
        }
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVel, ref currentVelRef, currentSettings.moveSmothness);
    }
}
