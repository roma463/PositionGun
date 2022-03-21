using UnityEngine;

public class RotateArm : MonoBehaviour
{
    private Camera _mainCamera;
    private void Start()
    {
        _mainCamera = Camera.main;
    }
    private void Update()
    {
        Move();
    }
    public void Move()
    {
        var positionMouse = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var midllePosition = transform.position - positionMouse;
        var rotateByZ = Mathf.Atan2(midllePosition.x, midllePosition.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * -rotateByZ);
    }
}
