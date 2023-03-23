using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour
{
    const int BASE_INDEX = 3;

    [SerializeField] private ChatBubble m_bubble;
    [SerializeField] private ChatBubble m_doubleBubble;
    [SerializeField] private Image m_image;

    public void SetData(Character character)
    {
        if (character == null || character.image == null)
        {
            gameObject.SetActive(false);
            return;
        }

        gameObject.SetActive(true);

        m_image.sprite = character.image;

        if (character.lines.Length > 1)
        {
            m_doubleBubble.gameObject.SetActive(true);
            m_bubble.gameObject.SetActive(false);
            m_doubleBubble.SetText(character.lines);
        }
        else if (character.lines.Length == 1)
        {
            m_bubble.gameObject.SetActive(true);
            m_doubleBubble.gameObject.SetActive(false);
            m_bubble.SetText(character.lines);
        }
        else
        {
            m_bubble.gameObject.SetActive(false);
            m_doubleBubble.gameObject.SetActive(false);
        }

        transform.SetSiblingIndex(BASE_INDEX - character.zIndex);
    }
}
