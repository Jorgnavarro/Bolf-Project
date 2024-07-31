using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource soundManagerVFX;
    public AudioSource soundManagerMusic;
    public AudioClip[] sonidosGolpes;
    [SerializeField] AudioMixer mixerGeneral;
    [SerializeField] Slider sliderMusic;
    [SerializeField] Slider sliderVFX;


    private static SoundManager instance;
    public static  SoundManager Instance {get {return instance;}}
    
    private void Awake() {
            if ( instance == null )
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

    }

    void Start()
    {
        soundManagerVFX = GameObject.Find("VFXManager").GetComponent<AudioSource>();
        soundManagerMusic = GameObject.Find("MusicManager").GetComponent<AudioSource>();
    }
    public void SetMusicVolume()
    {
        float volumenMusic = sliderMusic.value;
        mixerGeneral.SetFloat("Music", Mathf.Log10(volumenMusic)*20);
    }
    public void SetVFXVolume()
    {
        float volumenVFX = sliderVFX.value;
        mixerGeneral.SetFloat("VFX", Mathf.Log10(volumenVFX)*20);
    }
        public void ApretarBoton()
    {
        soundManagerVFX.PlayOneShot(sonidosGolpes[3]);
    }
    public void SeleccionarBoton()
    {
        soundManagerVFX.PlayOneShot(sonidosGolpes[4]);
    }
}