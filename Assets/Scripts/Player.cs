using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 targetPos;
    public Rigidbody MyRigidbody;

    Vector3 des;

    void Start()
    {
        targetPos = transform.position;
    }

    public void Move(Vector3 moveDirection)
    {
        targetPos += moveDirection;
    }

    private void Update()
    {
        Debug.DrawLine(transform.position, des, Color.red);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }

    public void FindTheDestination(Vector3 direction)
    {
        RaycastHit[] hits;
        //hits = Physics.RaycastAll(transform.position, direction, 100f);
        des = this.transform.position + (direction * 100f);
        hits = Physics.RaycastAll(this.transform.position, direction, Mathf.Infinity, LayerMask.NameToLayer("Brick"));
        List<Collider> listBricks = new List<Collider>();
        for(int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            Debug.LogError(hit.collider.name);
            if(hit.collider.tag == "Brick")
            {
                

                listBricks.Add(hit.collider);
                Debug.Log("Wall's hit");
                //MyRigidbody.isKinematic = true;
                //MyRigidbody.velocity = Vector3.zero;
            }
            else
            {
                if(listBricks.Count > 0)
                {
                    targetPos = new Vector3(listBricks[listBricks.Count - 1].transform.position.x, this.transform.position.y, listBricks[listBricks.Count - 1].transform.position.z);
                }
                break;
            }
        }
    }
}
