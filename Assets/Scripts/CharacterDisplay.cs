using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

// Component for displaying a character with a specific Image, lines, and offset
public class CharacterDisplay : MonoBehaviour
{
    // single speech bubble object
    [SerializeField] private ChatBubble m_bubble;
    // double speech bubble object
    [SerializeField] private ChatBubble m_doubleBubble;
    // image component for the character
    [SerializeField] private Image m_image;

    // the initial position of the image
    private Vector3 m_basePosition;
    private void Awake()
    {
        // set the inital position of the image
        m_basePosition = m_image.transform.position;
    }

    // Called from DialogManager.cs
    public void SetData(Character character)
    {
        // Disable gameobject if there's no image
        if (character.image == null)
        {
            gameObject.SetActive(false);
            return;
        }

        gameObject.SetActive(true);

        // set the correct image from the data
        m_image.sprite = character.image;

        // base scale
        float scale = 1f;

        // Check to see how many lines the character has
        // if more than one, use the double speech bubble
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
        // if there's no lines, disable the speech bubble and scale the image
        else
        {
            m_bubble.gameObject.SetActive(false);
            m_doubleBubble.gameObject.SetActive(false);
            scale = 0.7f;
        }

        // Set the offset from the data
        Vector3 offset = m_basePosition;
        if (character.offset.x != 0) offset.x = character.offset.x;
        if (character.offset.y != 0) offset.y = character.offset.y;

        // Apply transformations from the data
        m_image.GetComponent<RectTransform>().anchoredPosition = offset;
        m_image.GetComponent<RectTransform>().localScale = new Vector3(scale, scale, 1);
        transform.SetSiblingIndex(character.zIndex);
    }
}
