using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour
{
    [SerializeField] private ChatBubble m_bubble;
    [SerializeField] private ChatBubble m_doubleBubble;
    [SerializeField] private Image m_image;

    private Vector3 m_basePosition;
    private void Awake()
    {
        m_basePosition = m_image.transform.position;
        Debug.Log(m_basePosition);
    }

    public void SetData(Character character)
    {
        if (character == null || character.image == null)
        {
            gameObject.SetActive(false);
            return;
        }

        gameObject.SetActive(true);

        m_image.sprite = character.image;

        float scale = 1f;
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
            scale = 0.7f;
        }

        Vector3 offset = m_basePosition;
        if (character.offset.x != 0) offset.x = character.offset.x;
        if (character.offset.y != 0) offset.y = character.offset.y;

        Debug.Log(m_basePosition);
        m_image.GetComponent<RectTransform>().anchoredPosition = offset;
        m_image.GetComponent<RectTransform>().localScale = new Vector3(scale, scale, 1);
        transform.SetSiblingIndex(character.zIndex);
    }
}
