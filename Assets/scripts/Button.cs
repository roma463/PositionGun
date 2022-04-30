using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject _objectAction;
    private Action _action;
    private List<GameObject> _objectClickedButton = new List<GameObject>();
    private void Start()
    {
        if (_objectAction == null)
            return;
        if (!_objectAction.TryGetComponent(out _action))
        {
            _objectAction = null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_objectClickedButton.Count == 0)
            _action.launch();
        _objectClickedButton.Add(collision.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _objectClickedButton.Remove(collision.gameObject);
        if (_objectClickedButton.Count == 0)
            _action.launch();
    }
}
public interface Action
{
    void launch();
}

