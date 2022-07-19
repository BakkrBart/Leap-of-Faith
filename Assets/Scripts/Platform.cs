using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private bool isGrounded = false;
    public float groundDistance = 5;
    public float groundWidth;
    public float groundLength;
    public LayerMask playerMask;
    bool visable;
    public bool turnInvisible = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        if (isGrounded && turnInvisible)
        {
            visable = true;
            gameObject.layer = 14;
        }
        else if (!isGrounded && turnInvisible)
        {
            visable = false;
            gameObject.layer = 7;
        }
        
    }
    void GroundCheck()
    {
        if (Physics.CheckBox(transform.position, new Vector3(groundWidth, groundDistance, groundLength), Quaternion.identity, playerMask))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position, new Vector3(groundWidth * 2, groundDistance * 2, groundLength *2));
    }
}
