using UnityEngine;

public class InvisibleBlock : MonoBehaviour, Action
{
    [SerializeField] private bool _startActionObject;
    private void Start()
    {
        gameObject.SetActive(_startActionObject);
    }
    public void launch()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}
