using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("AudioManager");
                _instance = go.AddComponent<AudioManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    private AudioSource audioSource;
    private bool isPlayingPickupSound = false;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    public bool CanPlayPickupSound()
    {
        return !isPlayingPickupSound;
    }

    public void PlayPickupSound(AudioClip clip)
    {
        if (clip != null && !isPlayingPickupSound)
        {
            audioSource.PlayOneShot(clip);
            StartCoroutine(WaitForSound(clip.length));
        }
    }

    private IEnumerator WaitForSound(float duration)
    {
        isPlayingPickupSound = true;
        yield return new WaitForSeconds(duration);
        isPlayingPickupSound = false;
    }
}