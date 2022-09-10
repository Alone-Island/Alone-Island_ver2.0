using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabBuillding : MonoBehaviour
{
    public GameObject LabCeil;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.name == "Player")
        {
            LabCeil.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.name == "Player")
        {
            LabCeil.SetActive(true);
        }
    }
}
