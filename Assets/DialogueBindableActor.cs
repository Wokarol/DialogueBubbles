using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBindableActor : MonoBehaviour
{
    [SerializeField] DialogueBindID id;
    [SerializeField] GameObject dialogueBubbleObject;
    [SerializeField] Animator dialogueBubbleAnimator;
    [SerializeField] TMPro.TMP_Text dialogueBubbleText;

    private void Awake() {
        DynamicDialogueBinder.Default.BindActor(id, dialogueBubbleObject, dialogueBubbleAnimator, dialogueBubbleText);
    }
}
