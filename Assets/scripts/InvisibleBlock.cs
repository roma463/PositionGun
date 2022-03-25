using UnityEngine;

public class InvisibleBlock : MonoBehaviour, Action
{
    public void launch()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}
