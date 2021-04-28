using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float tankOffset = 0.01f;
    [SerializeField] private float recoilDuration = 0.05f;
    
    private void OnMouseDown()
    {
        Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        transform.DOMoveZ(transform.position.z - tankOffset, recoilDuration).SetLoops(2, LoopType.Yoyo);
    }
}