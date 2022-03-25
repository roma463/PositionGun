using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour, Action
{
    [SerializeField] private float _speed;
    private bool _isOpen;
    private float _startPosition;
    private Coroutine _currentCorutine;

    private void Start()
    {
        _startPosition = transform.localScale.y;
    }
    public void launch()
    {
        if (_currentCorutine != null)
        {
            StopCoroutine(_currentCorutine);
            _isOpen = !_isOpen;
            _currentCorutine = null;
        }
        if (_isOpen == false)
            _currentCorutine = StartCoroutine(Raise());
        else
            _currentCorutine = StartCoroutine(Closed());
    }
    private IEnumerator Raise()
    {
        for (float i = transform.localScale.y; i > 1; i -= Time.deltaTime * _speed)
        {
            ChangeSize(i);
            yield return null;
        }
        _currentCorutine = null;
        _isOpen = true;
    }
    private IEnumerator Closed()
    {

        for (float i = transform.localScale.y; i < _startPosition; i += Time.deltaTime * _speed)
        {
            ChangeSize(i);
            yield return null;
        }
        _currentCorutine = null;
        _isOpen = false;
    }
    private void ChangeSize(float size)
    {
        var scale = transform.localScale;
        scale.y = size;
        transform.localScale = scale;
    }
}

