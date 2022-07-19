using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private bool isGrounded = false;
    public float groundDistance = 2;
    public LayerMask playerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isGrounded);
        GroundCheck();
        if (isGrounded)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
    void GroundCheck()
    {
        if (Physics.CheckBox(transform.position, new Vector3(5, groundDistance, 5), Quaternion.identity, playerMask))
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
        Gizmos.DrawCube(transform.position, new Vector3(10, groundDistance * 2, 10));
    }
}
