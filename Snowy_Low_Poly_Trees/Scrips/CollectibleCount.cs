using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollectibleCount : MonoBehaviour
{
    [SerializeField]
    private TMP_Text m_TextComponent;


    public static int count;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Awake()
    {
        Debug.Log("Avant initialisation de text");
        m_TextComponent = GetComponent<TMP_Text>();
        if (m_TextComponent == null)
        {
            Debug.Log("c'est null");
        }
        //m_TextComponent.text = "Some new line of text."; 
        Debug.Log("Après initialisation de text");
        
    }
    void Start()
    {
        
        UpdateCount();
   
        
    }
    void OnEnable() => Collectible.OnCollected += OnCollectibleCollected;
    

    void OnDisable() => Collectible.OnCollected -= OnCollectibleCollected;

    void OnCollectibleCollected() 
    {
        count++;
        if (count == Collectible.total)
        {
            m_TextComponent.text = "Bravo! Tous les cadeaux ont été récupérés!";
            SceneManager.LoadScene(2);



        }
        else
        {
            UpdateCount();
        }
    }


    //affiche le nombre de cadeaux récupérés
    void UpdateCount() 
    {
        m_TextComponent.text = $"{count} / {Collectible.total} ";
    }


}
