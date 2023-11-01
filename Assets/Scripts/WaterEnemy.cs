using UnityEngine;

public class WaterEnemy : MonoBehaviour
{
    [SerializeField] private int _water;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Torch player))
        {
            player.ExtinguishingFire(_water);
        }
    }
}