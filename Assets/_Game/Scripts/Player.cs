using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Rigidbody _MyRigidbody;
    [SerializeField] private GameObject _addBrick;
    [SerializeField] private Transform _brickTransform;

    private Vector3 targetPos;
    //Vector3 des;
    RaycastHit oneHit;
    GameObject duplicate;

    void Start()
    {
        targetPos = transform.position;
    }

    /* public void Move(Vector3 moveDirection)
    {
        targetPos += moveDirection;
    } */

    private void Update()
    {
        //Debug.DrawLine(transform.position, des, Color.red);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, _moveSpeed * Time.deltaTime);
        //_addBrick.transform.localPosition = targetPos;
    }

    public void FindTheDestination(Vector3 direction)
    {
        //hits = Physics.RaycastAll(transform.position, direction, 100f);
        //des = this.transform.position + (direction * 100f);
        Vector3 startRayPos = this.transform.position;
        List<Collider> listBricks = new(); //new List<Collider>()
        while (Physics.Raycast(startRayPos, direction, out oneHit))
        {
            //Debug.Log(startRayPos);
            if (oneHit.collider.CompareTag("Brick"))
            {
                startRayPos = new Vector3(oneHit.transform.position.x, startRayPos.y, oneHit.transform.position.z);
                duplicate = Instantiate(_addBrick, _brickTransform);
                duplicate.transform.localPosition = new Vector3(0f, listBricks.Count * -0.35f, 0f);

                listBricks.Add(oneHit.collider);

                //Debug.Log("Wall's hit: " + oneHit.transform.name);
            }
            else
            {
                Debug.Log(oneHit.transform.name);
                if (listBricks.Count > 0)
                {
                    targetPos = new Vector3(listBricks[listBricks.Count - 1].transform.position.x, this.transform.position.y + .5f, listBricks[listBricks.Count - 1].transform.position.z);
                }
                break;
            }
        }
    }
}
