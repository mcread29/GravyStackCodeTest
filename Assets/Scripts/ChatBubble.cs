using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

// Component for displaying text
public class ChatBubble : MonoBehaviour
{
    // TextMeshPro components to display text
    [SerializeField] private TextMeshProUGUI[] m_texts;

    // Called from CharacterDiaplay.cs
    // Set the text for the number of lines
    public void SetText(string[] strings)
    {
        for (int i = 0; i < strings.Length; i++)
        {
            m_texts[i].SetText(strings[i]);
        }
    }
}
