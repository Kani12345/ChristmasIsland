using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cache : MonoBehaviour
{
    AudioSource neigeAudio;
    void OnTriggerEnter(Collider other)
        
    {
        
        if (other.tag == "Player")
        {
            Debug.Log("neige balayée");
            gameObject.GetComponent<AudioSource>();
            if (neigeAudio != null)
            {
                PlayAudioDetached();
            }
            Destroy(this.gameObject);
            

        }


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        neigeAudio = GetComponent<AudioSource>();
    }




    // Update is called once per frame
    void Update()
    {
        
    }
    void PlayAudioDetached()
    {
        // Create a new GameObject to play the sound
        GameObject audioObject = new GameObject("CollectibleSound");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        audioSource.clip = neigeAudio.clip;
        audioSource.volume = neigeAudio.volume;
        audioSource.pitch = neigeAudio.pitch;
        audioSource.spatialBlend = neigeAudio.spatialBlend; // If it's a 3D sound
        audioSource.Play();

        // Destroy the new GameObject after the sound finishes
        Destroy(audioObject, audioSource.clip.length);
    }

}
