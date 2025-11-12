using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip playerShoot;
    public AudioClip asteroidExplosion;
    public AudioClip playerDamage;
    public AudioClip playerExplosion;
    public AudioClip BgMusicGameplay;
    public AudioClip BgMusicTitleScreen;
    public AudioClip impressiveScore1;
    public AudioClip impressiveScore2;
    public AudioClip impressiveScore3;

    private AudioSource SFXaudioSource;

    private AudioSource BgMusicAudioSource;

    [SerializeField] float pitchVariance = 0.05f; // this is for the sfx variance

    public void Awake()
    {
        SFXaudioSource = GetComponent<AudioSource>();

        //GameObject child = this.transform.Find("BgMusic").gameObject;

        BgMusicAudioSource = gameObject.transform.Find("BgMusic").gameObject.GetComponent<AudioSource>();



        //BgMusicAudioSource.GetComponent<AudioSource>().Play();       
    }



    //called in the PlayerController Script
    public void PlayerShoot()
    {
        float randomPitch = Random.Range(1f - pitchVariance, 1f + pitchVariance);
        SFXaudioSource.pitch = randomPitch;
        SFXaudioSource.PlayOneShot(playerShoot);
    }

    //called in the PlayerController Script
    public void PlayerDamage()
    {
        float randomPitch = Random.Range(1f - pitchVariance, 1f + pitchVariance);
        SFXaudioSource.pitch = randomPitch;
        SFXaudioSource.PlayOneShot(playerDamage);
    }

    //called in the PlayerController Script
    public void PlayerExplosion()
    {
        SFXaudioSource.PlayOneShot(playerExplosion);
    }

    //called in the AsteroidDestroy script
    public void AsteroidExplosion()
    {
        SFXaudioSource.PlayOneShot(asteroidExplosion);
    }


    public void BGMusicMainMenu()
    {
        BgMusicAudioSource.clip = BgMusicTitleScreen;
        BgMusicAudioSource.Play();
    }

    public void BGMusicGameplay()
    {
        BgMusicAudioSource.GetComponent<AudioSource>().clip = BgMusicGameplay;
        BgMusicAudioSource.Play();

    }

    public AudioSource GetBgMusicAudioSource()
    {
        return BgMusicAudioSource;
    }

    public void PlayScoreMilestone(int milestone)
    {
        switch (milestone)
        {
            case 100:
                SFXaudioSource.PlayOneShot(impressiveScore1);
                break;
            case 200:
                SFXaudioSource.PlayOneShot(impressiveScore2);
                break;
            case 300:
                SFXaudioSource.PlayOneShot(impressiveScore3);
                break;
        }
    }
}
