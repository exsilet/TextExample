using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform player;
    
    private Vector3 offset;

    public void Start()
    {
        offset = transform.position - player.position;
    }

    public void LateUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + player.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, 1f);
    }
}
