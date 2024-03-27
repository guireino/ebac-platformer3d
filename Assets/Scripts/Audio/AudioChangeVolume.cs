using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioChangeVolume : MonoBehaviour{

    public AudioMixer group;
    public string floatParam = "myExposeParam"; // Na aula criamos no audio mixer no groups 4 mesa de volume master outra music esta ambience e sfx

    public void ChangeValue(float f){  // para ajustar volume criar duas MyExposedParam um ambience outra sfx
        group.SetFloat(floatParam, f);
    }

}