using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController cc;
    GameObject mainCam;
    Vector3 currentVelRef;
    Quaternion turnAngle;
    float horizontalInput, verticaleInput;
    bool jump, sprinting;
    private bool grounded;
    private Vector3 velocity;

    [SerializeField] PlayerSettings currentSettings;
    [SerializeField] float currentVelMag;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        currentVelRef = Vector3.zero;
        mainCam = Camera.main.gameObject;

        if(currentSettings.gravity > 0)
            currentSettings.gravity = currentSettings.gravity * -1;
    }

    void Update()
    {
        grounded = cc.isGrounded;

        horizontalInput = Input.GetAxis("Horizontal") * currentSettings.moveSpeed;
        verticaleInput = Input.GetAxis("Vertical") * currentSettings.moveSpeed;

        if (Input.GetKeyDown(currentSettings.jumpKey))
            jump = true;

        if (Input.GetKeyDown(KeyCode.LeftShift))
            sprinting = true;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            sprinting = false;

        Movement(horizontalInput, verticaleInput, ref jump);
        currentVelMag = cc.velocity.y;
    }


    //Functions----------------------------

    void Movement(float horizontalInput, float verticleInput, ref bool jump) {
        if(sprinting) {
            horizontalInput = horizontalInput * currentSettings.sprintSpeedMultiplier;
            verticleInput = verticleInput * currentSettings.sprintSpeedMultiplier;
        }

        Vector3 move = transform.forward * verticleInput + transform.right * horizontalInput;
        cc.Move(move * Time.deltaTime);

        if(grounded && velocity.y < 0)
            velocity.y = -2;

        if(jump) {
            velocity.y = Mathf.Sqrt(currentSettings.jumpHight * -2 * currentSettings.gravity);
            jump = false;
        }
        velocity.y += currentSettings.gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);

        //Rotation
        if (horizontalInput != 0 || verticaleInput != 0) {
            turnAngle = Quaternion.Euler(0, mainCam.transform.eulerAngles.y, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, turnAngle, currentSettings.rotationSpeed * Time.deltaTime);
        }
    }


    private void OnTriggerEnter(Collider other) 
    {
        //Debug.Log(currentVelMag);
        //Debug.Log(Mathf.Abs((int)(currentVelMag/20)) - 0.7f);
        if(currentVelMag < -30)
            ScreenShake.instance.ShakeCamera(0.5f, Mathf.Abs((int) (currentVelMag/20)) - 0.7f, true);
    }
}
