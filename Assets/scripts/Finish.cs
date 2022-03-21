using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private StateUi _ui;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMove plaeyerMove))
        {
            _ui.Win();
        }
    }
}
