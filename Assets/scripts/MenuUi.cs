using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUi : MonoBehaviour
{
    public void Play()
    {
        PlayerPrefs.DeleteAll();
        var numberLevel = PlayerPrefs.GetInt("Scene", 1);
        SceneManager.LoadScene(numberLevel);
    }
}
