using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private int _fire;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Torch player))
        {
            player.AddFire(_fire);
            Destroy(gameObject);
        }
    }      
}