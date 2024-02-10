using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    
    [SerializeField] private AudioSource sfxAudioSource;
    [SerializeField] private AudioClip shootSFX;
    [SerializeField] private AudioClip ammoAddedSFX;
    [SerializeField] private AudioClip slowTimeSFX;
    [SerializeField] private AudioClip freezeSFX;
    [SerializeField] private AudioClip buttonClickSFX;
    [SerializeField] private AudioClip reloadSFX;


    private void Awake()
    {
        instance = this;
    }

    public void PlayShootSFX() => sfxAudioSource.PlayOneShot(shootSFX);
    public void PlayAmmoAddedSFX() => sfxAudioSource.PlayOneShot(ammoAddedSFX);
    public void PlaySlowTimeSFX() => sfxAudioSource.PlayOneShot(slowTimeSFX);
    public void PlayFreezeSFX() => sfxAudioSource.PlayOneShot(freezeSFX);
    public void PlayButtonClickSFX() => sfxAudioSource.PlayOneShot(buttonClickSFX);
    public void PlayReloadSFX() => sfxAudioSource.PlayOneShot(reloadSFX);






}
