using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbiter : MonoBehaviour
{
    public Transform OG;
    public Transform xOrb;
    public Transform yOrb;
    public Transform totalOrb;
    private Vector3 tOrb;

    private float moveY;
    private float moveX;

    public float Speed = 200f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Mouse X");
        moveY = Input.GetAxis("Mouse Y");

        if (xOrb.localPosition.x < 1.5 && xOrb.localPosition.x > -1.5f)
        {
            xOrb.RotateAround(OG.position, Vector3.up, Speed * moveX * Time.deltaTime);// im not sure why its vectorup but k
        }
        else
        {
            if (xOrb.localPosition.x > 1.5)
            {
                xOrb.RotateAround(OG.position, Vector3.up, Speed * -1 * Time.deltaTime);// im not sure why its vectorup but k
            }
            else
            {
                xOrb.RotateAround(OG.position, Vector3.up, Speed * 1 * Time.deltaTime);// im not sure why its vectorup but k

            }
        }


        yOrb.RotateAround(OG.position, Vector3.right, Speed * moveY * Time.deltaTime);// kinda inversed
        tOrb = xOrb.localPosition + yOrb.localPosition;
        totalOrb.localPosition = tOrb;
    }
}
