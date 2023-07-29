using UnityEngine;

public class WinPos : MonoBehaviour
{
    [SerializeField] private GameObject winPos;
    internal int coin = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //SceneManager.LoadScene("SampleScene");
            coin++;
            PlayerPrefs.SetInt("coin", coin);
            UIManager.instance.SetCoin(coin);
        }
    }
}
