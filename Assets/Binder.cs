using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(PlayableDirector))]
public class Binder : MonoBehaviour
{
    [SerializeField] int actorNum = 1;
    [SerializeField] DialogueBindID actorID;
    PlayableDirector director;

    private void Start() {
        director = GetComponent<PlayableDirector>();
        var regex = new Regex($@"\[A{actorNum}(:(?<tag>.*?))?\]");

        var bind = DynamicDialogueBinder.Default.GetActor(actorID);
        if(bind.HasValue) {
            var outputs = director.playableAsset.outputs;
            foreach (var output in outputs) {
                var match = regex.Match(output.streamName);
                if (match.Success) {
                    ProcessBind(output, match.Groups["tag"].Value, bind.Value);
                }
            }
        }
    }

    private void ProcessBind(PlayableBinding output, string tag, DynamicDialogueBinder.DialogueBind bind) {
        if(output.outputTargetType == typeof(Animator)) {
            director.SetGenericBinding(output.sourceObject, bind.DialogueBubbleAnimator);
        } else if (output.outputTargetType == typeof(GameObject)) {
            director.SetGenericBinding(output.sourceObject, bind.DialogueBubbleObject);
        } else if (output.outputTargetType == typeof(TMPro.TMP_Text)) {
            director.SetGenericBinding(output.sourceObject, bind.DialogueBubbleText);
        } else {
            Debug.LogError($"Unsupported binding {output.outputTargetType} : {tag}");
        }
    }
}
