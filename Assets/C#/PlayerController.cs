using System;
using UnityEngine;
using Utillities;

public class PlayerController : MonoBehaviour {

    
    [SerializeField]
    RotatingDimension PlayerY;

    // Start is called before the first frame update
    void Start() {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        PlayerY.Angle = PlayerY.Transform.localRotation.y;
    }



    // Update is called once per frame
    void Update() {
        PlayerY.UpdateAngle(Input.GetAxis("Horizontal"));
        PlayerY.SetAngle(Vector3.up);
    }

    

}
