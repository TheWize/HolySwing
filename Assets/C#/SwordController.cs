using System;
using UnityEngine;
using Utillities;

public class SwordController : MonoBehaviour {

    [SerializeField]
    NonePhysicsRotatingObject2D CursorRotation;

    Vector3 startpos;

    [SerializeField]
    PhysicsRotatingObject2D SwordRotation;
    

    // Start is called before the first frame update
    void Start() {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        Reset();
        startpos = transform.localPosition;
    }

    private void Reset() {
        SwordRotation.Reset();
        CursorRotation.Reset();
    }



    // Update is called once per frame
    void Update() {

        CursorRotation.X.UpdateAngle(Input.GetAxisRaw("Mouse Y"));
        CursorRotation.Y.UpdateAngle(Input.GetAxisRaw("Mouse X"));
        CursorRotation.SetAngle();

        SwordRotation.X.UpdateAngle(Mathf.DeltaAngle(CursorRotation.X.Transform.localRotation.eulerAngles.x, SwordRotation.X.Transform.localRotation.eulerAngles.x));
        SwordRotation.Y.UpdateAngle(Mathf.DeltaAngle(CursorRotation.Y.Transform.localRotation.eulerAngles.y, SwordRotation.Y.Transform.localRotation.eulerAngles.y));
        SwordRotation.SetAngle();

        transform.localPosition = startpos;
    }

    

}
