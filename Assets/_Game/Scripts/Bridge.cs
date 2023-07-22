using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField] private GameObject bridge;

    private void OnTriggerEnter(Collider other)
    {
        //unhide Mesh Renderer
        if (other.CompareTag("Player"))
        {
            if (bridge.GetComponent<MeshRenderer>().isVisible == false)
            {
                bridge.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
