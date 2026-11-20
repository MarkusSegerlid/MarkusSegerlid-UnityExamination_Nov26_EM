using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI textBox;
    [SerializeField] private Button nextButton;
    [SerializeField] private List<string> dialogue;

    [SerializeField] private UnityEvent onStartDialogue,onEndDialogue;

    private int currentIndex = -1;

    public void NextDialogue()
    {
        if (currentIndex < 0) onStartDialogue?.Invoke();
        
        currentIndex++;
        if (currentIndex < dialogue.Count) textBox.text = dialogue[currentIndex];
        else
        {
            onEndDialogue?.Invoke();
            Reset();
        }
    }

    private void Reset()
    {
        currentIndex = -1;
        textBox.text = "";
    } 
}