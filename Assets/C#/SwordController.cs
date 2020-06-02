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


    // Start is called before the first frame update
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Reset();
        startpos = transform.localPosition;
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
        SwordX.SetAngle(Vector3.right);
        SwordY.SetAngle(Vector3.up);

        transform.localPosition = startpos;
    }



}
