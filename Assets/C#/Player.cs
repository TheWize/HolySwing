using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [Range(0, 50)]
    [SerializeField]
    private float moveSpeed;
    private float _moveX;
    private float _moveZ;
    public Animator anim;
    public Rigidbody rb;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("IsStabbing", true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(BacktoIdle());
        }
        _moveZ = Input.GetAxis("Vertical") * moveSpeed * -1;
        Debug.Log(_moveZ);
        _moveZ = Mathf.Clamp(_moveZ, -15, 15);
        rb.AddRelativeForce(0f, 0f, _moveZ);
        if (_moveZ == 0)
        {
            rb.velocity.Set(0f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddRelativeForce(0f, 0f, _moveZ);

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            rb.AddRelativeForce(moveSpeed * -.7f, 0f, 0f, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rb.AddRelativeForce(moveSpeed * .7f, 0f, 0f, ForceMode.Impulse);
        }
    }
    private IEnumerator BacktoIdle()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("IsStabbing", false);
        yield return null;
    }
}
