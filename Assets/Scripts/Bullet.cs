using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 3;
    [SerializeField] private float bounceForce = 100;
    [SerializeField] private float bounceRadius = 100;
    private Vector3 moveDirection;
    private readonly int hit = Animator.StringToHash("Hit");

    private void Start()
    {
        moveDirection = Vector3.forward;
    }

    private void FixedUpdate()
    {
        transform.Translate(moveDirection * bulletSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter (Collider obj)
    {
        if (obj.TryGetComponent(out Block block))
        {
            var component = block.GetComponentInChildren<Animator>();
            component.SetTrigger(hit);
            Destroy(gameObject);
        }
        
        if (obj.TryGetComponent(out Fence _)) Bounce();
    }

    private void Bounce()
    {
        moveDirection = Vector3.back + Vector3.up;
        var component = GetComponent<Rigidbody>();
        component.isKinematic = false;
        component.AddExplosionForce(
            bounceForce,
            transform.position + new Vector3(0, 0, 1),
            bounceRadius);
    }
}
