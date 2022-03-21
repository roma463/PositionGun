using UnityEngine;

public class InputButton : MonoBehaviour
{
    public float Horizontal { private set; get; }
    public bool MouseRightStay { private set; get; }
    public bool MouseLeft { private set; get; }
    public bool Space { private set; get; }
    private bool _isPause = true;
    private void Update()
    {
        if (_isPause)
        {

        Horizontal = Input.GetAxis("Horizontal");

        if (Input.GetMouseButtonDown(1))
            MouseRightStay = true;
        else if (Input.GetMouseButtonUp(1))
            MouseRightStay = false;

        MouseLeft = Input.GetMouseButtonDown(0);
        Space = Input.GetKeyDown(KeyCode.Space);
        }
    }
    public void Pause(bool pause)
    {
        _isPause = pause;
    }
}
