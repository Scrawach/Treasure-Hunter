using System;
using UnityEngine;

namespace UI.Monologue
{
    [RequireComponent(typeof(TextBuilder))]
    public class MonologueZone : MonoBehaviour
    {
        [SerializeField]
        private ScenarioItem _scenario;
        
        private TextBuilder _textBuilder;

        private void Awake()
        {
            _textBuilder = GetComponent<TextBuilder>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var text = MonologueSystem.IsEnglish ? _scenario.Talk.Eng : _scenario.Talk.Rus;
            _textBuilder.Build(text, other.transform.position, _scenario.Delay);
            gameObject.SetActive(false);
        }
    }
}