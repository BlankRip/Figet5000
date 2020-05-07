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


    Vector3 camForward;
    Quaternion rayRotationAngle;
    RaycastHit hitInfo;
    [Header("For ray cast to not stick to things")]
    [SerializeField] Transform castPosTop;
    [SerializeField] Transform castPosBottom;
    [SerializeField] LayerMask noStickLayers;
    [SerializeField] float castDistance;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentVelRef = Vector3.zero;
        mainCam = Camera.main.gameObject;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") * currentSettings.moveSpeed;
        verticaleInput = Input.GetAxis("Vertical") * currentSettings.moveSpeed;

        DoNotStick(castPosTop.position);
        DoNotStick(castPosBottom.position);

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


    //Functions----------------------------

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

    // When close to things it will stop motion in that direction
    void DoNotStick(Vector3 castPos)
    {
        if (Camera.main != null)
            camForward = Camera.main.transform.forward;
        camForward.y = 0;

        rayRotationAngle = Quaternion.LookRotation(camForward.normalized, Vector3.up);

        Debug.DrawRay(castPos, rayRotationAngle * Vector3.forward * castDistance, Color.red);
        Debug.DrawRay(castPos, rayRotationAngle * -Vector3.forward * castDistance, Color.green);
        Debug.DrawRay(castPos, rayRotationAngle * Vector3.right * castDistance, Color.yellow);
        Debug.DrawRay(castPos, rayRotationAngle * -Vector3.right * castDistance, Color.blue);

        if (Physics.Raycast(castPos, rayRotationAngle * Vector3.forward, out hitInfo, castDistance, noStickLayers))
        {
            if (verticaleInput > 0)
                verticaleInput = 0;
        }
        else if (Physics.Raycast(castPos, rayRotationAngle * -Vector3.forward, out hitInfo, castDistance, noStickLayers))
        {
            if (verticaleInput < 0)
                verticaleInput = 0;
        }

        if (Physics.Raycast(castPos, rayRotationAngle * Vector3.right, out hitInfo, castDistance, noStickLayers))
        {
            if (horizontalInput > 0)
                horizontalInput = 0;
        }
        if (Physics.Raycast(castPos, rayRotationAngle * -Vector3.right, out hitInfo, castDistance, noStickLayers))
        {
            if (horizontalInput < 0)
                horizontalInput = 0;
        }
    }
}
