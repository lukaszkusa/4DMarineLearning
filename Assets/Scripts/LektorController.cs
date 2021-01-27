using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LektorController : MonoBehaviour
{
    public List<AudioClip> PL = new List<AudioClip>();
    public List<AudioClip> EN = new List<AudioClip>();
    private List<AudioClip> curr = null;
    private bool isEnd = false;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Play(int i){
        isEnd = false;
        audio.clip = curr[i];
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying)
        {
           isEnd = true;
        }
    }
    public bool isPlaying(){
        return isEnd;
    }
    public void setLanguage(string lan){
        if(lan == "PL")curr = PL;
        else if(lan == "EN") curr =EN;
    }
}