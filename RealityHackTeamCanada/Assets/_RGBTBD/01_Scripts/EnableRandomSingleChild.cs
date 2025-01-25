using UnityEngine;

public class EnableRandomSingleChild : MonoBehaviour
{
    void Start()
    {
        // First, disable all children
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        
        // Pick a random child to enable
        int randomIndex = Random.Range(0, transform.childCount);
        transform.GetChild(randomIndex).gameObject.SetActive(true);
    }
}
