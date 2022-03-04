using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMakeClick : MonoBehaviour
{
    private bool isClicked = false;

    public GameObject manualBuilding = null;
    private GameObject dragBuilding = null;
    public GameObject realBuilding = null;

    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        isClicked = true;
        dragBuilding = Instantiate(manualBuilding, transform);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 1.0f;
        dragBuilding.transform.position = mousePos;
    }

    private void OnMouseDrag()
    {
        if (isClicked == true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 1.0f;
            dragBuilding.transform.position = mousePos;
        }
    }

    private void OnMouseUp()
    {
        isClicked = false;
        Instantiate(realBuilding, dragBuilding.transform.position, Quaternion.identity);
        Destroy(dragBuilding);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("collision");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger enter");
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("trigger stay");
    }
}
