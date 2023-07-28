using UnityEngine;

public class SpeedBump : MonoBehaviour
{
    public Player player;

    private void OnTriggerEnter(Collider other)
    {
        //Reduce speed on bridge
        if (other.CompareTag("Player"))
        {
            player._moveSpeed -= 15;
        }
    }
}
