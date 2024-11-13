using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public static event Action OnCollected;
    public static int total;
    AudioSource collectablesAudio;

    void Awake()
    {
        total++;
        collectablesAudio = GetComponent<AudioSource>(); // Initialize the audio source
    }



    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0f, Time.time * 130f, 0);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Cadeau récupéré!");
           gameObject.GetComponent<AudioSource>();
            if (collectablesAudio != null)
            {
                PlayAudioDetached();
            }
            OnCollected?.Invoke();
            Destroy(gameObject);


        }

    }
    void PlayAudioDetached()
    {
        // Create a new GameObject to play the sound
        GameObject audioObject = new GameObject("CollectibleSound");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        audioSource.clip = collectablesAudio.clip;
        audioSource.volume = collectablesAudio.volume;
        audioSource.pitch = collectablesAudio.pitch;
        audioSource.spatialBlend = collectablesAudio.spatialBlend; // If it's a 3D sound
        audioSource.Play();

        // Destroy the new GameObject after the sound finishes
        Destroy(audioObject, audioSource.clip.length);
    }
}
