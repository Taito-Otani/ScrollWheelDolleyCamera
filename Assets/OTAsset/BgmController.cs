using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BgmController : MonoBehaviour
{
    private AudioSource bgm;
    private float maxVolume;
    // Start is called before the first frame update
    void Start()
    {
        bgm = GetComponent<AudioSource>();
        maxVolume = bgm.volume;

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider other)
    {
        FadeIn(bgm, 1.0f);

        Debug.Log("BGM START"+bgm.clip.ToString());
    }

    void OnTriggerExit(Collider other)
    {
        FadeOut(bgm, 5.0f);
        Debug.Log("BGM STOP" + bgm.clip.ToString());
    }

    void FadeIn(AudioSource _audio,float _time)
    {
        _audio.Play();
        _audio.DOFade(maxVolume, _time);

    }

    void FadeOut(AudioSource _audio, float _time)
    {
        _audio.DOFade(0.0f, _time);
    }
}
