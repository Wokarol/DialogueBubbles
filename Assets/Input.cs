using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Input : MonoBehaviour
{
    [SerializeField] PlayableDirector director;

    private void Update() {
        if (UnityEngine.Input.GetKeyDown(KeyCode.G)) {
            director.Play();
        }
    }
}
