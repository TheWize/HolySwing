using UnityEngine;
using Utillities;

public class SwordController : MonoBehaviour {


    [SerializeField]
    RotatingDimension CursorX;
    [SerializeField]
    RotatingDimension CursorY;

    [SerializeField]
    PhysicRotationDimension SwordX;
    [SerializeField]
    PhysicRotationDimension SwordY;

    Vector3 startpos;
    Quaternion SwordStartRot;

    [SerializeField]
    Transform SwordModelTransform;


    // Start is called before the first frame update
    void Start() {
        SwordY.Rigidbody.centerOfMass = new Vector3 (0f, 0f, -1.65f);
        Cursor.lockState = CursorLockMode.Locked;
        Reset();
        startpos = transform.localPosition;
        SwordStartRot = SwordModelTransform.localRotation;

    }

    private void Reset() {
        CursorX.Angle = CursorX.Transform.localRotation.x;
        CursorY.Angle = CursorY.Transform.localRotation.y;
    }



    // Update is called once per frame
    void Update() {

        CursorX.UpdateAngle(Input.GetAxisRaw("Mouse Y"));
        CursorY.UpdateAngle(Input.GetAxisRaw("Mouse X"));
        CursorX.SetAngle(Vector3.right);
        CursorY.SetAngle(Vector3.up);

        SwordX.UpdateAngle(Mathf.DeltaAngle(CursorX.Transform.localRotation.eulerAngles.x, SwordX.Transform.localRotation.eulerAngles.x), Vector3.right);
        SwordY.UpdateAngle(Mathf.DeltaAngle(CursorY.Transform.localRotation.eulerAngles.y, SwordY.Transform.localRotation.eulerAngles.y), Vector3.up);
        //SwordX.SetAngle(Vector3.right);
        //SwordY.SetAngle(Vector3.up);

        transform.localPosition = startpos;
        SwordModelTransform.localRotation = SwordStartRot;
    }



}
