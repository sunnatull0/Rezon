using UnityEngine;

public class IgnoreColliders : MonoBehaviour
{
    private void Start()
    {
        Physics2D.IgnoreLayerCollision(3, 8);
        Physics2D.IgnoreLayerCollision(9, 10);
    }
}
