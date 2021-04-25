using System;
using UnityEngine;

namespace UI.Monologue
{
    public class DialogueZone : MonoBehaviour
    {
        [SerializeField] 
        private MonologueSystem _system;

        [SerializeField] 
        private ScenarioView _scenario;

        private void OnTriggerEnter(Collider other)
        {
            _system.PlayScenario(_scenario);
            gameObject.SetActive(false);
        }
    }
}