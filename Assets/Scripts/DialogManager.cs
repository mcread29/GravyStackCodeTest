using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UI;

// Component for controlling the cutscene
public class DialogManager : MonoBehaviour
{
    // The data for the current cutscene
    [SerializeField] private DialogSequence m_sequence;
    // The Character on the left
    [SerializeField] private CharacterDisplay m_leftCharacter;
    // The Character in the center
    [SerializeField] private CharacterDisplay m_centerCharacter;
    // The Character on the right
    [SerializeField] private CharacterDisplay m_rightCharacter;
    // The CanvasGroup for the transition flash
    [SerializeField] private CanvasGroup m_transitionOverlay;

    // the index of the current shown dialog
    private int m_dialogIndex;

    private void Awake()
    {
        // set the index to 0 and show the first dialog
        m_dialogIndex = 0;
        presentDialog();
    }

    // Advance the dialog
    public void AdvanceDialog()
    {
        m_dialogIndex++;
        // if the index is less than the sequence length display the current index
        if (m_dialogIndex < m_sequence.dialogs.Length)
        {
            Debug.Log(m_dialogIndex + ", " + m_sequence.dialogs.Length);
            presentDialog();
        }
    }

    // present the dialog
    private void presentDialog()
    {
        // the dialog for the current index
        CharacterDialog dialog = m_sequence.dialogs[m_dialogIndex];
        // set the data for the left character
        m_leftCharacter.SetData(dialog.LeftCharacter);
        // set the data for the center character
        m_centerCharacter.SetData(dialog.CenterCharacter);
        // set the data for the right character
        m_rightCharacter.SetData(dialog.RightCharacter);

        // if the dialog is a transition, fade the transition flash image
        if (dialog.isTransition)
        {
            StartCoroutine(ShowTransition(0.75f));
        }
    }

    // lerp function for displaying a transition
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

        // advance the dialog on half transition
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
