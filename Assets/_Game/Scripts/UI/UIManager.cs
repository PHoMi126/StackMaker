using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text coinText;
    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void SetCoin(int coin)
    {
        coinText.text = coin.ToString();
    }
}
