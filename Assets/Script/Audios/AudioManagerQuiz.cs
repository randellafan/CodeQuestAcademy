using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header ("Audio Source")] 
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header ("Audio Clip")] 
    public AudioClip background;
    public AudioClip Correct;
    public AudioClip Incorrect;
    public AudioClip Return;

    public void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
