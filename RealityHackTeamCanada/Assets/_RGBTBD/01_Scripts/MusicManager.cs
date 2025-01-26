using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip introClip; // Optional: The audio clip to play once at the start
    public AudioClip mainLoopClip; // The audio clip to loop if provided

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource found on the GameObject!");
            return;
        }

        if (mainLoopClip == null)
        {
            Debug.LogError("Main Loop clip is missing! Ensure you provide a main loop audio clip.");
            return;
        }

        if (introClip != null)
        {
            PlayIntroThenLoop();
        }
        else
        {
            StartMainLoop();
        }
    }

    void PlayIntroThenLoop()
    {
        audioSource.clip = introClip;
        audioSource.Play();
        Invoke(nameof(StartMainLoop), introClip.length);
    }

    void StartMainLoop()
    {
        audioSource.clip = mainLoopClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void PauseMusic()
    {
        audioSource.Pause();
    }

    public void ResumeMusic()
    {
        audioSource.UnPause();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}