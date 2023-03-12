using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.UI;

[System.Serializable]
public class AudioManager : MonoBehaviour
{

    //public AudioSource BGM;
    public AudioSource MasterAudio;
    
    public Sound[] sounds;
    private GameObject[] audioManager;
    private int index;
    [SerializeField]  Slider volumeSlider;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch; 

        }
    }

    private void Start()
    {
        

        audioManager = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)

            audioManager[i] = transform.GetChild(i).gameObject;


        //toggle off audio
        foreach (GameObject song in audioManager)

            song.SetActive(false);


        //toggle on the selected audio
        if (audioManager[index])
            audioManager[index].SetActive(true);


        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            LoadVol();
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* public void ChangeBGM(AudioClip music)

     {
         BGM.Stop();
         BGM.clip = music;
         BGM.Play();
     }


     public void Play(string name)
     {
         Sound s = Array.Find(sounds, sound => sound.name == name);
         s.source.Play();
     }
     */

    public void SwitchSoundR()
    {
        audioManager[index].SetActive(false);
        index++; //index -= 1; index = index - 1;
        if (index == audioManager.Length)
            index = 0;


        // Toggle on the new audio
        audioManager[index].SetActive(true);
    }

    public void SwitchSoundL()
    {
        //Toggle off current model
        audioManager[index].SetActive(false);
        index--; //index -= 1; index = index - 1;
        if (index < 0)
            index = audioManager.Length - 1;

        // Toggle on the new model
        audioManager[index].SetActive(true);
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }

    public void LoadVol()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    public void SaveVol()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
