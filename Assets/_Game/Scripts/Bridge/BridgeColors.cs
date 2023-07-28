using UnityEngine;

public class BridgeColors : MonoBehaviour
{
    Color[] colors = new Color[6];

    void Start()
    {
        colors[0] = Color.cyan;
        colors[1] = Color.red;
        colors[2] = Color.green;
        colors[3] = new Color(255, 165, 0);
        colors[4] = Color.yellow;
        colors[5] = Color.magenta;
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, colors.Length)];
    }
}
