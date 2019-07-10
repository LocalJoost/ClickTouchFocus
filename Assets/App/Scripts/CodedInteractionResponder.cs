using Microsoft.MixedReality.Toolkit.Input;
using TMPro;
using UnityEngine;

public class CodedInteractionResponder : MonoBehaviour, 
    IMixedRealityFocusHandler, IMixedRealityTouchHandler, IMixedRealityPointerHandler
{
    [SerializeField]
    private TextMeshPro _text;

    [SerializeField]
    private AudioClip _clickAudio;

    [SerializeField]
    private AudioClip _focusAudio;

    [SerializeField]
    private AudioClip _focusLostAudio;

    [SerializeField]
    private AudioClip _startTouchAudio;

    [SerializeField]
    private AudioClip _endTouchAudio;

    private int _timesClicked = 0;

    private int _timesTouched = 0;

    private int _timesFocused = 0;
    

    public void OnFocusEnter(FocusEventData eventData)
    {
        _timesFocused++;
        UpdateText();
        PlayClip(_focusAudio);
    }

    public void OnFocusExit(FocusEventData eventData)
    {
        PlayClip(_focusLostAudio);
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        _timesClicked++;
        UpdateText();
        PlayClip(_clickAudio);
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
    }


    public void OnTouchStarted(HandTrackingInputEventData eventData)
    {
        _timesTouched++;
        UpdateText();
        PlayClip(_startTouchAudio);
    }

    public void OnTouchCompleted(HandTrackingInputEventData eventData)
    {
        PlayClip(_endTouchAudio);

    }

    public void OnTouchUpdated(HandTrackingInputEventData eventData)
    {
    }




    private void UpdateText()
    {
        _text.text = $"Clicked: {_timesClicked} Touched: {_timesTouched} Focused: {_timesFocused}";
    }

    private void PlayClip(AudioClip clip)
    {
        if (clip == null)
        {
            return;
        }

        var audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }

        audioSource.clip = clip;
        audioSource.Play();
    }
}
