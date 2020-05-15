using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBall : MonoBehaviour
{
    [SerializeField] float speed = 10;
    Vector3 moveDir;
    Rigidbody rb; 


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveDir = Random.insideUnitSphere;
        rb.velocity = moveDir * speed;
    }
}
