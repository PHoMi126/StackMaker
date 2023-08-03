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
    RaycastHit oneHit;
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

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, _moveSpeed * Time.deltaTime);
    }

    public void FindTheDestination(Vector3 direction)
    {
        Vector3 startRayPos = this.transform.position;
        List<Collider> rays = new(); //new List<Collider>()
        while (Physics.Raycast(startRayPos, direction, out oneHit))
        {
            startRayPos = new Vector3(oneHit.transform.position.x, startRayPos.y, oneHit.transform.position.z);
            if (oneHit.collider.CompareTag("BrickLine"))
            {
                GameObject duplicate = Instantiate(_addBrick, _brickTransform);
                duplicate.transform.localPosition = new Vector3(0f, listBricks.Count * -0.5f, 0f);
                //Debug.Log(duplicate.transform.position);
                rays.Add(oneHit.collider);
                listBricks.Add(duplicate);
                transform.localPosition = new Vector3(targetPos.x, targetPos.y + 1.155f, targetPos.z);
                Debug.Log(transform.localPosition);
            }
            else if (oneHit.collider.CompareTag("BridgeLine"))
            {
                rays.Add(oneHit.collider);
                GameObject obj = listBricks[listBricks.Count - 1];
                listBricks.Remove(obj);
                Destroy(obj);
                transform.localPosition = new Vector3(targetPos.x, targetPos.y - 6.155f, targetPos.z);
            }
            else if (oneHit.collider.CompareTag("NoBrick"))
            {
                rays.Add(oneHit.collider);
                transform.localPosition = new Vector3(targetPos.x, targetPos.y, targetPos.z);
            }
            //break;
            else
            {
                if (rays.Count > 0)
                {
                    targetPos = new Vector3(rays[rays.Count - 1].transform.position.x, this.transform.position.y, rays[rays.Count - 1].transform.position.z);
                }
                break;
            }
        }
    }
}
