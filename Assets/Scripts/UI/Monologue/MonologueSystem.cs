using System;
using System.Collections;
using JetBrains.Annotations;
using Player;
using UnityEngine;
using UnityEngine.Events;

namespace UI.Monologue
{
    [RequireComponent(typeof(TextBuilder))]
    public class MonologueSystem : MonoBehaviour
    {
        public static bool IsEnglish;
        public static event Action<bool> LanguageChanged;
        
        public ScenarioView Scenario;
        private TextBuilder _textBuilder;

        private ScenarioView _currentScenario;

        public UnityEvent MonologueStart;
        public UnityEvent MonologueEnded;

        [SerializeField]
        private bool _isEng;

        private Coroutine _coroutine;
        
        private void Awake()
        {
            _textBuilder = GetComponent<TextBuilder>();
            IsEnglish = _isEng;
        }

        public void PlayScenario(ScenarioView scenario)
        {
            _currentScenario = scenario;

            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
            
            MonologueStart?.Invoke();
            _coroutine = StartCoroutine(Playing());
        }

        private IEnumerator Playing()
        {
            var dialoguePointer = 0;
            yield return new WaitForSeconds(2f);
            while (_currentScenario.Dialogue.Count > dialoguePointer)
            {
                var item = _currentScenario.Dialogue[dialoguePointer];
                var text = IsEnglish ? item.Talk.Eng : item.Talk.Rus;
                _textBuilder.Build(text, item.Who.position, item.Delay);
                yield return new WaitForSeconds(item.Delay);
                dialoguePointer++;
            }
            
            _currentScenario.InvokeDone();
            MonologueEnded?.Invoke();
        }

        [UsedImplicitly]
        public void SetEng()
        {
            _isEng = true;
            IsEnglish = true;
            LanguageChanged?.Invoke(IsEnglish);
        }

        [UsedImplicitly]
        public void SetRus()
        {
            _isEng = false;
            IsEnglish = false;
            LanguageChanged?.Invoke(IsEnglish);
        }
        
        public void Skip()
        {
            if (_coroutine == null) 
                return;
            
            StopCoroutine(_coroutine);
            _coroutine = null;
            
            _currentScenario.InvokeDone();
            MonologueEnded?.Invoke();
        }
    }
}
