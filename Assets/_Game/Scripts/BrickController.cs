using UnityEngine;

public class BrickController : MonoBehaviour
{
    public GameObject brick;
    public string newTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            brick.SetActive(false);
            //Destroy(brick);
            gameObject.tag = newTag;
        }
    }
}
