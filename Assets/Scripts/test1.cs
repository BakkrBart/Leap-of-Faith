using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test1 : MonoBehaviour
{
    #region "Variables"
    public Rigidbody Rigid;
    public float MouseSensitivity;
    public float MoveSpeed;
    public float JumpForce;
    #endregion

    void Update()
    {
        Rigid.MoveRotation(Rigid.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * MouseSensitivity, 0)));
        Rigid.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * MoveSpeed) + (transform.right * Input.GetAxis("Horizontal") * MoveSpeed));
        if (Input.GetKeyDown("space"))
            Rigid.AddForce(transform.up * JumpForce);
    }
}
