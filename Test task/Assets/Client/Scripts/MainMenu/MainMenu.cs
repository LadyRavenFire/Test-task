using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private Button _playButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _recordButton;

    [SerializeField] private Button _backFromRecordButton;

    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _recordPanel;

    [SerializeField] private Texture2D _mainMenuImage;
    [SerializeField] private Texture2D _recordSprite;
    [SerializeField] private RawImage _backgroundRawImage;

    [SerializeField] private TextMeshProUGUI _scoreText;

    [SerializeField] private GameObject _bestiaryPanel;
    [SerializeField] private Button _backFromBestriaryButton;
    [SerializeField] private Button _goToBestiaryButton;
    
    void Start()
    {
        _playButton.onClick.AddListener(Play);
        _quitButton.onClick.AddListener(Quit);
        _recordButton.onClick.AddListener(ShowRecord);
        _goToBestiaryButton.onClick.AddListener(ShowBestiary);
        _backFromBestriaryButton.onClick.AddListener(BackFromBestiary);
        

        _scoreText.text = "Best score: " + PlayerPrefs.GetInt("BestScore");
        _backFromRecordButton.onClick.AddListener(BackFromRecord);
        _recordPanel.SetActive(false);
        _bestiaryPanel.SetActive(false);
    }

    private void BackFromRecord()
    {
        _recordPanel.SetActive(false);
        _mainMenuPanel.SetActive(true);
        _backgroundRawImage.texture = _mainMenuImage;
    }

    private void ShowBestiary()
    {
        _bestiaryPanel.SetActive(true);
        _mainMenuPanel.SetActive(false);
        _backgroundRawImage.texture = _recordSprite;
    }

    private void BackFromBestiary()
    {
        _bestiaryPanel.SetActive(false);
        _mainMenuPanel.SetActive(true);
        _backgroundRawImage.texture = _mainMenuImage;
    }

    private void Play()
    {
        SceneManager.LoadScene(1);
    }

    private void ShowRecord()
    {
        _recordPanel.SetActive(true);
        _mainMenuPanel.SetActive(false);
        _backgroundRawImage.texture = _recordSprite;
    }   

    private void Quit()
    {
        Application.Quit();
    }
}
