using UnityEngine;

public class Teleport : MonoBehaviour
{
    public enum Offset
    {
        right,
        left,
        up,
        down,
    }

    [SerializeField] private Transform _pointUP;
    [SerializeField] private Transform _pointDown;
    [SerializeField] private Transform _pointLeft;
    [SerializeField] private Transform _pointRight;

    [SerializeField] private HoldObject _holdObject;
    public static Teleport GlobaTP { get; private set; }
    private void Awake()
    {
        GlobaTP = this;
    }
    public void Player(Offset of, Vector2 newPosition)
    {
        Vector2 offset = Vector2.zero;
        if (of == Offset.down)
        {
            offset = transform.position - _pointDown.position;
        }
        else if (of == Offset.up)
        {
            offset = transform.position - _pointUP.position;
        }
        if (of == Offset.left)
        {
            offset = transform.position - _pointLeft.position;
        }
        else if (of == Offset.right)
        {
            offset = transform.position - _pointRight.position;
        }
        offset *= transform.localScale.y;
        transform.position = newPosition - offset;
        _holdObject.TeleportCurrentUseObject(transform.position);
        PlayerMove.GlobalPlayer.UnplugJump();
    }
}
