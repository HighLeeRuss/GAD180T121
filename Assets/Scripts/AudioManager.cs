using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource backGroundMusic;
    public AudioClip songA;
    public AudioClip songB;
    public AudioClip songC;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChangeMusicA", 60f);
        Invoke("ChangeMusicB", 120f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMusicA()
    {
        backGroundMusic.Stop();
        backGroundMusic.clip = songA;
        backGroundMusic.Play();
    }
    
    public void ChangeMusicB()
    {
        backGroundMusic.Stop();
        backGroundMusic.clip = songB;
        backGroundMusic.Play();
    }
}
