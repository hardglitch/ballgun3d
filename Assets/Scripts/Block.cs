using UnityEngine;
using UnityEngine.Events;

public sealed class Block : MonoBehaviour
{
    public event UnityAction<Block> BulletHit;
    
    public void Break()
    {
        Destroy(gameObject);
        BulletHit?.Invoke(this);
    }
}
