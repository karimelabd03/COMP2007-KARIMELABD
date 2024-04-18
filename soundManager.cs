using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static soundManager instance;

    public AudioSource gameSounds;
    public AudioClip shot;
    public AudioClip treasure;
    public AudioClip button;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gunSound()
    {
        gameSounds.clip = shot;
        gameSounds.Play();
    }
    public void treasureSound()
    {
        gameSounds.clip = treasure;
        gameSounds.Play();
    }
    public void buttonSound()
    {
        gameSounds.clip = button;
        gameSounds.Play();
    }
 
}
