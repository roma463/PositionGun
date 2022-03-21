using UnityEngine;

[RequireComponent(typeof(Trajectory))]
public class PositionGun : MonoBehaviour
{
    public enum StateMove
    {
        moveObject,
        teleportPLayer
    }
    public StateMove StateTP { get; private set; }
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _gunPoint;
    [SerializeField] private float _force;
    [SerializeField] private HoldObject _holdObject;
    [SerializeField] private LayerMask _rayCollsiion;
    [SerializeField] private InputButton _inputButton;
    [SerializeField] private StateUi _stateUi;
    private Trajectory _trajectory;
    private Camera _camera;
    private bool _posibilityShot = true;
    private void Start()
    {
        _trajectory = GetComponent<Trajectory>();
        _camera = Camera.main;
    }
    private void Update()
    {
        var speed = -(transform.position - _camera.ScreenToWorldPoint(Input.mousePosition)) * _force;
        _trajectory.TrajectoryBullet(speed);
        if (_inputButton.MouseLeft)
        {
            if (_posibilityShot)
            {
               if (!Physics2D.OverlapCircle(_gunPoint.position, .1f, _rayCollsiion))
               {
                   _posibilityShot = _stateUi.DecreaseCountShot();
                   var bullet = Instantiate(_bullet, _gunPoint.position, Quaternion.identity);
                   var rb = bullet.GetComponent<Rigidbody2D>();
                   rb.gravityScale *= transform.parent.gameObject.transform.parent.localScale.y;
                   rb.AddForce(speed, ForceMode2D.Impulse);
               }
            }
            else
            {
                _stateUi.Lost();
            }
        }
        else if (_inputButton.MouseRightStay)
        {
            _holdObject.GameobjectKeep();
        }
        else if (!_inputButton.MouseRightStay)
        {
            _holdObject.Throw();
        }
    }
}
