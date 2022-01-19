using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public List<AudioClip> musicList = new List<AudioClip>();

    [SerializeField] AudioSource source;

    [SerializeField] float musicTimer = 0f;

    public static MusicManager Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        PlayRandomClip();
    }

    void Update()
    {
        musicTimer += Time.unscaledDeltaTime;
    }

    public void PlayNextClip()
    {
        if (musicTimer > 60f)
        {
            PlayRandomClip();
            musicTimer = 0f;
        }
    }

    void PlayRandomClip()
    {
        source.clip = musicList[Random.Range(0, musicList.Count)];
        source.Play();
    }
}
