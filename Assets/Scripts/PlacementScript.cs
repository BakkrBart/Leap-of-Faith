using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementScript : MonoBehaviour
{
    public GameManager manager;
    [SerializeField]
    private GameObject Platform;
    [SerializeField]
    private GameObject TurningPlatform;
    [SerializeField]
    private Camera cam;

    private int norPlatsLeft;
    public int norPlatsStart;
    private int turPlatsLeft;
    public int turPlatsStart;

    // Use this for initialization
    void Start()
    {
        norPlatsLeft = norPlatsStart;
        turPlatsLeft = turPlatsStart;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Alpha1) && !manager.paused)
        {
            //Debug.Log("input left");
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Ground" && norPlatsLeft > 0)
                {
                    //Debug.Log("Ground hit");
                    Vector3 spawnPos = new Vector3((Mathf.Round(hit.point.x/10)*10), (Mathf.Round(hit.point.y/10)*10), (Mathf.Round(hit.point.z/10)*10));
                    GameObject.Instantiate(Platform, spawnPos, Quaternion.identity);
                    norPlatsLeft--;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && !manager.paused)
        {
            //Debug.Log("input left");
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Ground" && turPlatsLeft > 0)
                {
                    //Debug.Log("Ground hit");
                    Vector3 spawnPos = new Vector3((Mathf.Round(hit.point.x / 10) * 10), (Mathf.Round(hit.point.y / 10) * 10), (Mathf.Round(hit.point.z / 10) * 10));
                    GameObject.Instantiate(TurningPlatform, spawnPos, Quaternion.identity);
                    turPlatsLeft--;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && !manager.paused)
        {
            //Debug.Log("input right");
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Platform")
                {
                    if (hit.transform.name == "Turning Platform")
                    {
                        turPlatsLeft++;
                        Destroy(hit.transform.parent.gameObject);
                    }
                    else
                    {
                        norPlatsLeft++;
                        Destroy(hit.transform.gameObject);
                    }
                }
            }
        }


    }

    private void OnGUI()
    {
        if (!manager.paused)
        {
            GUI.skin.label.fontSize = 20;
            GUI.Label(new Rect(20, 115, 500, 500), "Platforms remaining: " + norPlatsLeft);
            GUI.Label(new Rect(20, 130, 500, 500), "Turning platforms remaining: " + turPlatsLeft);
        }
    }

}
