using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomPlayAudioClips : MonoBehaviour{

    private int _index;
    public List<AudioClip> audioClipList;
    public List<AudioSource> audioSourceList; // criamos 3 AudioSource para pode tocar um 1 por vez, vai tem 3 AudioSource um primeiro que vai mudar os audios dos passo

    public void PlayRandom(){

        if(_index >= audioSourceList.Count){
            _index = 0;
        }

        var audioSource = audioSourceList[_index]; // criando variável e atualizando valor da lista de audioClipList

        audioSource.clip = audioClipList[Random.Range(0, audioClipList.Count)];
        Debug.Log("audioSource " + audioSource);
        audioSource.Play();

        Debug.Log("_index " + _index);
        _index++;
    }
    
}