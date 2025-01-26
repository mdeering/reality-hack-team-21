using Meta.XR.ImmersiveDebugger;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private GameObject _lightActiveVisual;
    // List of audio clips to play when the flashlight is turned on or off
    [SerializeField] private AudioClip[] _audioClips;
    public UnityEvent OnTurnOn;
    public UnityEvent OnTurnOff;

    private AudioSource _audioSource;

    void Start()
    {
        // Cache our audio source
        _audioSource = GetComponent<AudioSource>();
    }
    
    [DebugMember(Category = "Flashlight")]
    [SerializeField] private bool _isOn;

    [DebugMember(Category = "Flashlight")]
    [Button("💡 Turn On")]
    public void TurnOn()
    {
        _lightActiveVisual.SetActive(true);
        _isOn = true;
        // Play a random audio clip from our list
        _audioSource.PlayOneShot(_audioClips[Random.Range(0, _audioClips.Length)]);
        Debug.Log("Flashlight is on");
    }

    [DebugMember(Category = "Flashlight")]
    [Button("🔦 Turn Off")]
    public void TurnOff()
    {
        _lightActiveVisual.SetActive(false);
        _isOn = false;
        // Play a random audio clip from our list
        _audioSource.PlayOneShot(_audioClips[Random.Range(0, _audioClips.Length)]);
        Debug.Log("Flashlight is off");
    }

    public bool GetFlashLightStatus()
    {
        return _isOn;
    }
}
