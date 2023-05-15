using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPos : MonoBehaviour
{
    [SerializeField] private GameObject winPos;
    private Player player;

    void Start()
    {
        Invoke("OnTriggerEnter", 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
