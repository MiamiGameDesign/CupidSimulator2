using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum CurrentlyPlaying
{
    Nothing,
    Jazz,
    Metal
};
public class MusicScript : MonoBehaviour
{
    static CurrentlyPlaying currently_playing = CurrentlyPlaying.Nothing;

    AudioSource jazz_source;
    AudioSource metal_source;
    public void StopPlaying()
    {
        jazz_source.Stop();
        metal_source.Stop();
        currently_playing = CurrentlyPlaying.Nothing;
    }

    public void PlayMetal()
    {
        metal_source.Play();
        jazz_source.Stop();
        currently_playing = CurrentlyPlaying.Metal;
    }
    public void PlayJazz()
    {
        jazz_source.Play();
        metal_source.Stop();
        currently_playing = CurrentlyPlaying.Jazz;
    }

    void Start()
    {
        jazz_source = GameObject.Find("JazzSource").GetComponent<AudioSource>();
        metal_source = GameObject.Find("MetalSource").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
