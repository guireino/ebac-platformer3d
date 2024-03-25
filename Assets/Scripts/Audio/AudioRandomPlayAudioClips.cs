using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomPlayAudioClips : MonoBehaviour{

    private int _index = 0;
    public List<AudioClip> audioClipList;
    public List<AudioSource> audioSourceList; // criamos 3 AudioSource para pode tocar tres som de um vez, para tocar um 1 por vez

    public void PlayRandom(){

        if(_index >= audioSourceList.Count){
            _index = 0;
        }

        var audioSource = audioSourceList[_index]; // criando variável e atualizando valor da lista de audioClipList

        audioSource.clip = audioClipList[Random.Range(0, audioClipList.Count)];
        audioSource.Play();

        _index++;
    }
    
}