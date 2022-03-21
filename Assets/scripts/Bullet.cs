using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private DisableParticle _train;
    private Teleport _teleport;
    private Vector2 _x;
    void Start()
    {
        _teleport = Teleport.GlobaTP;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CollisionSurface collsionSurface))
        {
            _train.transform.parent = null;
            _train.StopParticals();
            _x = collision.GetContact(0).normal;
                Teleport.Offset a = new Teleport.Offset();
                if (_x == Vector2.up)
                {
                    a = Teleport.Offset.up;
                }
                else if (_x == -Vector2.up)
                {
                    a = Teleport.Offset.down;
                }
                if (_x == Vector2.right)
                {
                    a = Teleport.Offset.right;
                }
                else if (_x == -Vector2.right)
                {
                    a = Teleport.Offset.left;
                }
                print(a);
                _teleport.Player(a, collision.GetContact(0).point);
        }
        Destroy(gameObject);
    }
}
