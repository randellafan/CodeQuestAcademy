using UnityEngine;

public class AudioManagerMain : MonoBehaviour
{
    [Header ("Audio Source")] 
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header ("Audio Clip")] 
    public AudioClip background;
    public AudioClip Interact;

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
