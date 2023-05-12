using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody MyRigidbody;
    [SerializeField] private GameObject brick;
    private Vector3 targetPos;
    Vector3 des;
    RaycastHit oneHit;
    void Start()
    {
        targetPos = transform.position;
        Invoke("Restart", 6);
    }

    public void Move(Vector3 moveDirection)
    {
        targetPos += moveDirection;
    }

    private void Update()
    {
        //Debug.DrawLine(transform.position, des, Color.red);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }

    public void FindTheDestination(Vector3 direction)
    {
        
        //hits = Physics.RaycastAll(transform.position, direction, 100f);
        //des = this.transform.position + (direction * 100f);
        Vector3 startRayPos = this.transform.position;
        List<Collider> listBricks = new List<Collider>();
        while(Physics.Raycast(startRayPos, direction, out oneHit))
        {
            Debug.Log(startRayPos);
            if(oneHit.collider.tag == "Brick")
            {
                listBricks.Add(oneHit.collider);
                startRayPos = new Vector3(oneHit.transform.position.x, startRayPos.y, oneHit.transform.position.z);
                GameObject duplicate = Instantiate(brick);
                brick.SetActive(true);

                Debug.Log("Wall's hit: " + oneHit.transform.name);
            }
            else
            {
                Debug.Log(oneHit.transform.name);
                if(listBricks.Count > 0)
                {
                    targetPos = new Vector3(listBricks[listBricks.Count - 1].transform.position.x, this.transform.position.y, listBricks[listBricks.Count - 1].transform.position.z);
                }
                break;
            }
        }
    }
    void Restart()
    {
        if(oneHit.collider.tag == "WinPos")
        {
            SceneManager.LoadSceneAsync("SampleScene");
        }
    }
}
