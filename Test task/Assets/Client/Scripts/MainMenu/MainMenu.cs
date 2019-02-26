using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private Button _playButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _recordButton;

    [SerializeField] private Button _backButton;

    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _recordPanel;

    [SerializeField] private Texture2D _mainMenuImage;
    [SerializeField] private Texture2D _recordSprite;
    [SerializeField] private RawImage _backgroundRawImage;

    [SerializeField] private TextMeshProUGUI _scoreText;
    
    void Start()
    {
        _playButton.onClick.AddListener(Play);
        _quitButton.onClick.AddListener(Quit);
        _recordButton.onClick.AddListener(ShowRecord);

        _scoreText.text = "Best score: " + PlayerPrefs.GetInt("BestScore");
        _backButton.onClick.AddListener(BackToMainMenu);
        _recordPanel.SetActive(false);
    }

    private void BackToMainMenu()
    {
        _recordPanel.SetActive(false);
        _mainMenuPanel.SetActive(true);
        _backgroundRawImage.texture = _mainMenuImage;
    }

    void Play()
    {
        SceneManager.LoadScene(1);
    }

    void ShowRecord()
    {
        _recordPanel.SetActive(true);
        _mainMenuPanel.SetActive(false);
        _backgroundRawImage.texture = _recordSprite;
    }   

    void Quit()
    {
        Application.Quit();
    }
}
