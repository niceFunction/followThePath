using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class scr_ManageSliderValue : MonoBehaviour
{
    scr_AudioManager audioManager;

    private Slider musicSlider;
    /*
    sliderns OnValueChanged går till det nya scriptet som du lägger på samma objekt.
    Det scriptet kör: AudioManager.instance.SetMusicVolume eller något
    Audiomanagern sätter sedan den faktiska volymen.

    i det nya scriptet så lägger du också 
    Start()
    { slider.setvalue(AudioManager.instance.GetMusicVolume) }
    eller liknande
    så det nya objektet gör bara 2 saker:
    Vid start, hämta volymen från Audiomanager och sätt slider på rätt plats
    När slider ändras, skicka vidare det till Audiomanagern
     */
    // Start is called before the first frame update
    void Start()
    {
        musicSlider.SetValueWithoutNotify(scr_AudioManager.instance.SetMusicVol);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
