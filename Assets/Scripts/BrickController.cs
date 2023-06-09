using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField] private GameObject brick;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            brick.SetActive(false);
        }
    }
}
