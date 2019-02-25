using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DynamicDialogueBinder
{
    static DynamicDialogueBinder _default;
    public static DynamicDialogueBinder Default {
        get {
            if(_default == null) {
                _default = new DynamicDialogueBinder();
            }
            return _default;
        }
    }

    Dictionary<DialogueBindID, DialogueBind> binds = new Dictionary<DialogueBindID, DialogueBind>();
    public struct DialogueBind
    {
        public DialogueBind(GameObject dialogueBubbleObject, Animator dialogueBubbleAnimator, TMP_Text dialogueBubbleText) {
            DialogueBubbleObject = dialogueBubbleObject;
            DialogueBubbleAnimator = dialogueBubbleAnimator;
            DialogueBubbleText = dialogueBubbleText;
        }

        public readonly GameObject DialogueBubbleObject;
        public readonly Animator DialogueBubbleAnimator;
        public readonly TMP_Text DialogueBubbleText;
    }

    public void BindActor(DialogueBindID id, GameObject dialogueBubbleObject, Animator dialogueBubbleAnimator, TMP_Text dialogueBubbleText) {
        var bind = new DialogueBind(dialogueBubbleObject, dialogueBubbleAnimator, dialogueBubbleText);
        if (!binds.ContainsKey(id)) {
            binds.Add(id, bind);
        } else {
            binds[id] = bind;
        }
    }

    public DialogueBind? GetActor(DialogueBindID id) {
        if (binds.ContainsKey(id)) {
            return binds[id];
        } else {
            return null;
        }
    }
}
