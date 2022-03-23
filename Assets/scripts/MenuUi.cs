using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUi : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
