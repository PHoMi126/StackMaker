using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _moveSpeed;
    [SerializeField] private Rigidbody _MyRigidbody;
    [SerializeField] private GameObject _addBrick;
    [SerializeField] private Transform _brickTransform;
    [SerializeField] private WinPos _winPos;

    private Vector3 targetPos;
    //Vector3 des;
    RaycastHit oneHit;
    GameObject duplicate, obj;
    public List<GameObject> listBricks = new();

    private void Awake()
    {
        _winPos.coin = PlayerPrefs.GetInt("coin", 0);
    }

    void Start()
    {
        targetPos = transform.position;
        UIManager.instance.SetCoin(_winPos.coin);
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
        Vector3 startRayPos = this.transform.position;
        List<Collider> rays = new(); //new List<Collider>()
        while (Physics.Raycast(startRayPos, direction, out oneHit))
        {
            startRayPos = new Vector3(oneHit.transform.position.x, startRayPos.y, oneHit.transform.position.z);
            //Debug.Log(startRayPos);
            if (oneHit.collider.CompareTag("BrickLine"))
            {
                duplicate = Instantiate(_addBrick, _brickTransform);
                duplicate.transform.position = new Vector3(targetPos.x, rays.Count * 0.5f, targetPos.z);

                rays.Add(oneHit.collider);
                listBricks.Add(duplicate);
                //Debug.Log("Wall's hit: " + oneHit.transform.name);
            }
            else if (oneHit.collider.CompareTag("BridgeLine"))
            {
                rays.Add(oneHit.collider);
                obj = listBricks[listBricks.Count - 1];
                listBricks.Remove(obj);
                Destroy(obj);
            }
            else
            {
                //Debug.Log(oneHit.transform.name);
                if (rays.Count > 0)
                {
                    targetPos = new Vector3(rays[rays.Count - 1].transform.position.x, this.transform.position.y + 0.5f, rays[rays.Count - 1].transform.position.z);
                }
                break;
            }
        }
    }
}
