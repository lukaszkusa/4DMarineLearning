using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VolumeValueChallenge : MonoBehaviour
{
    public GameObject subPanel;
    public GameObject panel;
    public Button button;
    public Sprite [] images;
    public GameObject musicVolumePanel;
    public Camera camera;
    public RectTransform  handle;
    private bool musicVolumePanelActive = false;
    private bool subPanelActive = false;
    public  AudioSource audioSrc;
    private float musicVolume = 1f;

	// Use this for initialization
	void Start () {
        // audioSrc = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if(musicVolumePanelActive){
             if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
            {
                musicVolume+=0.09999f;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
            {  
                musicVolume-=0.09999f;
            }
            if(musicVolume <= 1.000f && musicVolume >= 0.000f){
                handle.anchorMin =new Vector2(0, musicVolume);
                handle.anchorMax =new Vector2(1, musicVolume);
                audioSrc.volume = musicVolume;
                if(musicVolume < 0.15)button.GetComponent<Image>().sprite = images[1];
                else if(musicVolume <= 0.3)button.GetComponent<Image>().sprite = images[2];
                else if(musicVolume <= 0.6)button.GetComponent<Image>().sprite = images[3];
                else if(musicVolume >= 0.6)button.GetComponent<Image>().sprite = images[0];
            }
        } 
          if(subPanel.gameObject )subPanelActive = true;
	}

    public void SetVolume(float vol)
    {
         musicVolume = vol;
        
       
        if(musicVolume == 0)button.GetComponent<Image>().sprite = images[1];
        else if(musicVolume <= 0.3)button.GetComponent<Image>().sprite = images[2];
        else if(musicVolume <= 0.6)button.GetComponent<Image>().sprite = images[3];
        else if(musicVolume >= 0.6)button.GetComponent<Image>().sprite = images[0];
        
    }
    public void OpenVolumePanel(){

         if(!musicVolumePanelActive){
            camera.GetComponent<CameraBehavior>().stopManualRotate();
            musicVolumePanelActive = true;
            musicVolumePanel.SetActive(true);
            panel.gameObject.SetActive(true);
            if(subPanel.gameObject)subPanel.gameObject.SetActive(false);
        }
        else
        {
            if(subPanelActive)subPanel.gameObject.SetActive(true);
            musicVolumePanel.SetActive(false);
            musicVolumePanelActive = false;
             panel.gameObject.SetActive(false);
            //subPanel.gameObject.SetActive(true);
            camera.GetComponent<CameraBehavior>().startManualRotate();
        }
       
    }
    public void CloseVolumePanel(){
       musicVolumePanel.SetActive(false);
            musicVolumePanelActive = false;
            //  panel.gameObject.SetActive(false);
            //subPanel.gameObject.SetActive(true);
            camera.GetComponent<CameraBehavior>().startManualRotate();
    }
}
