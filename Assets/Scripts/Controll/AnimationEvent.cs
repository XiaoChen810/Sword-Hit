using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    public PawnController controller;

    public void Event_ActionToNone()
    {
        controller.Action = ActionType.None;
    }
}
