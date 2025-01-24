using Meta.XR.ImmersiveDebugger;
using NaughtyAttributes;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private GameObject _lightActiveVisual;
    
    [DebugMember(Category = "Flashlight")]
    [SerializeField] private bool _isOn;

    void Start()
    {
        _lightActiveVisual.SetActive(_isOn);
    }

    [DebugMember(Category = "Flashlight")]
    [Button("💡 Turn On")]
    public void TurnOn()
    {
        _lightActiveVisual.SetActive(true);
        _isOn = true;
        Debug.Log("Flashlight is on");
    }

    [DebugMember(Category = "Flashlight")]
    [Button("🔦 Turn Off")]
    public void TurnOff()
    {
        _lightActiveVisual.SetActive(false);
        _isOn = false;
        Debug.Log("Flashlight is off");
    }

    public bool GetFlashLightStatus()
    {
        return _isOn;
    }
}
