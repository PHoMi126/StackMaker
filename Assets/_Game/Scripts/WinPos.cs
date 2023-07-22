using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPos : MonoBehaviour
{
    [SerializeField] private GameObject winPos;
    //private Player player;

    void Start()
    {
        Invoke(nameof(OnTriggerEnter), 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
