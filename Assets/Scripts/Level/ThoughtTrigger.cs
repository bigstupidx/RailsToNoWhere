﻿using UnityEngine;
using System.Collections.Generic;
[RequireComponent(typeof(BoxCollider))]
public class ThoughtTrigger : MonoBehaviour {

    public List<string> ThoughtText;
    public bool Activated = false;

    private void OnTriggerEnter(Collider other) {
        if (!Activated && other.tag == "Player") {
            UI.ThoughtSequence(ThoughtText);
            Activated = true;
        }
    }
}
