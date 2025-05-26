using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioSource backgroundAudioSource; // Reference to the background music AudioSource
    [SerializeField] private AudioSource effectAudioSource; // Reference to the coin sound AudioSource

    [SerializeField] private AudioClip backGroundClip;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip coinClip;
    void Start()
    {
        PlayBackGroundMusic(); // Play the background music at the start of the game
    }


    public void PlayBackGroundMusic(){
        backgroundAudioSource.clip = backGroundClip; // Set the background music clip
        backgroundAudioSource.Play();
    }

    public void PlayCoinSound(){
        effectAudioSource.PlayOneShot(coinClip); // Play the coin sound effect
    }

    public void PlayJumpSound(){
        effectAudioSource.PlayOneShot(jumpClip); // Play the jump sound effect
    }

    public void PauseBackgroundMusic() {
    backgroundAudioSource.Pause();
}

public void ResumeBackgroundMusic() {
    backgroundAudioSource.UnPause();
}
}
