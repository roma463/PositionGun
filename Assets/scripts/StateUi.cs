using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StateUi : MonoBehaviour
{
    [SerializeField] private GameObject _winDisplay;
    [SerializeField] private GameObject _pauseDisplay;
    [SerializeField] private GameObject _lostDisplay;
    [SerializeField] private Text _nextLevel;
    [SerializeField] private Text _countShotText;
    [SerializeField] private InputButton _inputButton;
    [SerializeField] private int _countShot;
    private int _currentScene;
    private void Start()
    {
        if (PlayerPrefs.HasKey("Scene"))
            _currentScene = PlayerPrefs.GetInt("Scene");
    }
    public void Win()
    {
        _winDisplay.SetActive(true);
            _currentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Scene", _currentScene + 1);
        if (SceneManager.sceneCount - 1 < _currentScene)
            _nextLevel.gameObject.SetActive(true);
                
    }
    public void Lost() 
    {
        _lostDisplay.SetActive(true);
        _inputButton.Pause(false);
    }
    public bool DecreaseCountShot()
    {
        _countShot--;
        _countShotText.text = _countShot.ToString();
        if(_countShot > 0)
        {
            return true;
        }
        return false;
    }
    public void Pause()
    {
        _pauseDisplay.SetActive(!_pauseDisplay.activeInHierarchy);
        _inputButton.Pause(!_pauseDisplay.activeInHierarchy);
    }
    public void Restart()
    {
        SceneManager.LoadScene(_currentScene);
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ButtonPause()
    {
        Pause();
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(_currentScene + 1);
    }
}