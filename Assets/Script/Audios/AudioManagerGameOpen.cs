using UnityEngine;

public class AudioManagerGameOpen : MonoBehaviour
{
    [Header ("Audio Source")] 
    [SerializeField] AudioSource musicSource;

    [Header ("Audio Clip")] 
    public AudioClip background;

    public void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
}

