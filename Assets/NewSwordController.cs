using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class NewSwordController : MonoBehaviour
{
    private Rigidbody rb;
    private float tilt;
    private float pan;
    Transform targetTilt;
    Transform targetPan;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        tilt = Input.GetAxis("Mouse Y");
        pan = Input.GetAxis("Mouse X");
    }
}
