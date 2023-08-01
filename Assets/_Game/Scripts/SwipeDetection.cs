using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    public Player player;
    private Vector2 startPos;
    public int pixelDistToDetect;
    private bool fingerDown;

    void Update()
    {
        if (fingerDown == false && Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            fingerDown = true;
        }

        if (fingerDown)
        {
            //Swipe up
            if (Input.mousePosition.y >= startPos.y + pixelDistToDetect)
            {
                fingerDown = false;
                player.FindTheDestination(Vector3.forward);
            }
            //Swipe left
            else if (Input.mousePosition.x <= startPos.x - pixelDistToDetect)
            {
                fingerDown = false;
                player.FindTheDestination(Vector3.left);
            }
            //Swipe right
            else if (Input.mousePosition.x >= startPos.x + pixelDistToDetect)
            {
                fingerDown = false;
                player.FindTheDestination(Vector3.right);
            }
            //Swipe down
            else if (Input.mousePosition.y <= startPos.y - pixelDistToDetect)
            {
                fingerDown = false;
                player.FindTheDestination(Vector3.back);
            }
        }
    }
}
