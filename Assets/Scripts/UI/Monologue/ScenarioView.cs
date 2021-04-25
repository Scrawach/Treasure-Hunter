using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UI.Monologue
{
    public class ScenarioView : MonoBehaviour
    {
        public List<ScenarioItem> Dialogue;
        public UnityEvent Done;

        public void InvokeDone()
        {
            Done?.Invoke();
        }
    }
}