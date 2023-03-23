using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private DialogSequence m_sequence;
    [SerializeField] private CharacterDisplay m_leftCharacter;
    [SerializeField] private CharacterDisplay m_centerCharacter;
    [SerializeField] private CharacterDisplay m_rightCharacter;
    [SerializeField] private CanvasGroup m_transitionOverlay;

    private int m_dialogIndex;

    private void Awake()
    {
        m_dialogIndex = 0;
        presentDialog();
    }

    public void AdvanceDialog()
    {
        if (m_dialogIndex < m_sequence.dialogs.Length)
        {
            m_dialogIndex++;
            presentDialog();
            Debug.Log(m_dialogIndex);
        }
    }

    private void presentDialog()
    {
        CharacterDialog dialog = m_sequence.dialogs[m_dialogIndex];
        m_leftCharacter.SetData(dialog.LeftCharacter);
        m_centerCharacter.SetData(dialog.CenterCharacter);
        m_rightCharacter.SetData(dialog.RightCharacter);

        if (dialog.isTransition)
        {
            StartCoroutine(ShowTransition(0.75f));
        }
    }

    private IEnumerator ShowTransition(float duration)
    {
        float timeElapsed = 0f;
        while (timeElapsed < duration)
        {
            float alpha = Mathf.Lerp(0f, 1f, timeElapsed / duration);
            m_transitionOverlay.alpha = alpha;

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        AdvanceDialog();

        timeElapsed = 0f;
        while (timeElapsed < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, timeElapsed / duration);
            m_transitionOverlay.alpha = alpha;

            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}
