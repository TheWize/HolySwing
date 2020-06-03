using UnityEngine;

namespace Utillities {

    [System.Serializable]
    class RotatingDimension {
        [SerializeField]
        internal Transform Transform;
        [SerializeField]
        internal float Coefficient;

        internal float Angle;

        [SerializeField]
        internal float MinDegree;
        [SerializeField]
        internal float MaxDegree;
        
        internal void UpdateAngle(float value) {
            Angle += value * Coefficient * Time.deltaTime;
            if (MinDegree != 0 || MaxDegree != 0) {
                Angle = Mathf.Clamp(Angle, MinDegree, MaxDegree);
            }

        }

        internal void SetAngle(Vector3 rotationVector) {
            Transform.localRotation = Quaternion.Euler(rotationVector * Angle);
        }
    }

    [System.Serializable]
    class PhysicRotationDimension {
        [SerializeField]
        internal Transform Transform;
        [SerializeField]
        internal Rigidbody Rigidbody;

        [SerializeField]
        internal float Force;

        internal float Angle;

        [SerializeField]
        internal float MinDegree;
        [SerializeField]
        internal float MaxDegree;

        float Velocity;

        [SerializeField]
        float MaxVelocity;
        [SerializeField]
        float Drag;
        //[SerializeField]
        //float Bounciness;

        internal void UpdateAngle(float value, Vector3 rotationVector) {
            Rigidbody.AddRelativeTorque(Vector3.Normalize(rotationVector) * Force * value * Time.deltaTime);
            //
            /* Acceleration = value * Force * Time.deltaTime * -1;
             Velocity += Acceleration;
             if (Mathf.Sign(Acceleration) != Mathf.Sign(Velocity)) {
                 Velocity *= Mathf.Pow(Drag, Time.deltaTime);
             }
             Velocity = Mathf.Clamp(Velocity, -MaxVelocity, MaxVelocity);

             Angle += Velocity;
             if (MinDegree != 0 || MaxDegree != 0) {
                 if (Angle <= MinDegree) {
                     Angle = MinDegree;
                     Velocity = -Velocity * Bounciness;
                 }
                 else if (Angle >= MaxDegree) {
                     Angle = MaxDegree;
                     Velocity = -Velocity * Bounciness;
                 }
             }*/
        }

        internal void SetAngle(Vector3 rotationVector) {
            Transform.localRotation = Quaternion.Euler(rotationVector * Angle);
        }
    }
}
