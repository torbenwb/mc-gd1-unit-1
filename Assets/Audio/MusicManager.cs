using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    public List<AudioClip> musicTracks;
    public int trackIndex = 0;
    public AudioSource audioSource;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }

        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying) return;

        trackIndex++;
        if (trackIndex >= musicTracks.Count) trackIndex = 0;

        audioSource.clip = musicTracks[trackIndex];
        audioSource.Play();
    }

    public void NextTrack()
    {
        trackIndex++;
        if (trackIndex >= musicTracks.Count) trackIndex = 0;
        audioSource.clip = musicTracks[trackIndex];
        audioSource.Play();
    }
}
