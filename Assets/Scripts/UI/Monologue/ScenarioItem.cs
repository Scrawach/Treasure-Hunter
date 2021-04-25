using System;
using UnityEngine;

namespace UI.Monologue
{
    [Serializable]
    public class ScenarioItem
    {
        public TextItem Talk;
        public Transform Who;
        public float Delay;
    }
}