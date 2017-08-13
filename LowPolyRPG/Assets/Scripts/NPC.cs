using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public Dialogue dialogue;

    public override void Interact()
    {
        base.Interact();
        if (dialogue != null)
        {
            DialogueManager.instance.StartDialogue(dialogue);
        }
    }
}