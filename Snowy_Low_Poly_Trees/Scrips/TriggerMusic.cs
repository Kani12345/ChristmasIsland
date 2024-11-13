using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMusic : MonoBehaviour
{
    public AudioClip musicClip;      // The audio clip to be played
    private AudioSource audioSource; // Reference to the audio source component

    void Start()
    {
        // Add an AudioSource component if it doesn't already exist
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Ensure the audio source is set up
        audioSource.clip = musicClip;      // Set the audio clip
        audioSource.playOnAwake = false;   // Don't play automatically when the game starts
        audioSource.loop = true;          // Set to false if you only want the music to play once
    }

    // This method will be called when something enters the trigger zone
    void OnTriggerEnter(Collider other)
    {
        // Check if the object that triggered the event has the "Player" tag
        if (other.CompareTag("Player"))
        {
            if (musicClip != null && !audioSource.isPlaying)
            {
                audioSource.Play(); // Play the music
            }
        }
    }
}
