using Meta.XR.ImmersiveDebugger;
using NaughtyAttributes;
using UnityEngine;

public class PassthroughLayerControls : MonoBehaviour
{
    [SerializeField] private GameObject _defaultPassthroughLayer;
    [SerializeField] private GameObject _greyPassthroughLayer;

    [DebugMember(Category = "Passthrough Layer Controls")]
    [Button("🔄 Reset to default")]
    public void ResetToDefaultPassthroughLayerOnly()
    {
        // Disable all the other passthrough layers
        _defaultPassthroughLayer.SetActive(true);
    }

    [DebugMember(Category = "Passthrough Layer Controls")]
    [Button("☑️ Enable Default")]
    public void EnableDefaultPassthroughLayer()
    {
        _defaultPassthroughLayer.SetActive(true);
    }

    [DebugMember(Category = "Passthrough Layer Controls")]
    [Button("❌ Disable Default")]
    public void DisableDefaultPassthroughLayer()
    {
        _defaultPassthroughLayer.SetActive(false);
    }
    
    [DebugMember(Category = "Passthrough Layer Controls")]
    [Button("☑️ Enable GreyScale")]
    public void EnableGreyPassthroughLayer()
    {
        _greyPassthroughLayer.SetActive(true);
    }

    [DebugMember(Category = "Passthrough Layer Controls")]
    [Button("❌ Disable GreyScale")]
    public void DisableGreyPassthroughLayer()
    {
        _greyPassthroughLayer.SetActive(false);
    }
}
