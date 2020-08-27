using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundUIController : UIElement
{
    [SerializeField] SoundUIElement musicUIElement;
    [SerializeField] SoundUIElement soundEffectUIElement;
    bool isSliderSet;
    private void Awake()
    {
        isSliderSet = false;
        soundEffectUIElement.SetSliderVolume();
        musicUIElement.SetSliderVolume();
        isSliderSet = true;
    }
    public void UpdateSliders()
    {
        if (!isSliderSet) return;
        musicUIElement.UpdateAudioSourceVolume();
        soundEffectUIElement.UpdateAudioSourceVolume();
    }
    private void Update()
    {
        Debug.Log(animator.GetCurrentAnimatorStateInfo(0).length);
        Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsName(hideAnimation));
    }
}

[System.Serializable]
public class SoundUIElement
{
    [SerializeField] SoundCollection collection;
    [SerializeField] Slider slider;
    [SerializeField] Text volumeNumber;
    public void SetSliderVolume()
    {
        slider.value = collection.volume;
        volumeNumber.text = (collection.volume * 100).ToString();
    }
    public void UpdateAudioSourceVolume()
    {
        collection.volume = slider.value;
        volumeNumber.text = ((int)(collection.volume * 100)).ToString();
    }
}
