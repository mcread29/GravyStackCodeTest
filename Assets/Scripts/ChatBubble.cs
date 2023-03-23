using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ChatBubble : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] m_texts;

    public void SetText(string[] strings)
    {
        for (int i = 0; i < strings.Length; i++)
        {
            m_texts[i].SetText(strings[i]);
        }
    }
}
