using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField] private GameObject bridge;

    private void OnTriggerEnter(Collider other)
    {
        //unhide Mesh Renderer
        if (other.tag == "Player") //other.gameObject.CompareTag("Player")
        {
            if (bridge.GetComponent<MeshRenderer>().isVisible == false)
            {
                bridge.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
