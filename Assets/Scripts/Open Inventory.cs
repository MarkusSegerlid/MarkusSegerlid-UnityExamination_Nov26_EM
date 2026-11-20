using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenInventory : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects = new();
    private bool shown;
    public void Toggle(InputAction.CallbackContext input)
    {
        if (input.started) shown = !shown;
        foreach (GameObject element in objects) element.SetActive(shown);
    }
}
