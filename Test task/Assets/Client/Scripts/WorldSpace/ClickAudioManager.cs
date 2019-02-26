using UnityEngine;

public class ClickAudioManager : MonoBehaviour
{
    [SerializeField] public AudioSource AudioSource;

    [SerializeField] private AudioClip _clickOnBirdSound;
    [SerializeField] private AudioClip _clickOnClockSound;

    public void ClickOnBird()
    {
        AudioSource.clip = _clickOnBirdSound;
        AudioSource.Play();
    }

    public void ClickOnClock()
    {
        AudioSource.clip = _clickOnClockSound;
        AudioSource.Play();
    }
}
