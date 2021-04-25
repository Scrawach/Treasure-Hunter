using System;
using TMPro;
using UI.Monologue;
using UnityEngine;

namespace UI
{
    public class FastLocalizationStaticString : MonoBehaviour
    {
        [SerializeField] 
        private string TextRus;
        
        [SerializeField] 
        private string TextEng;
        
        [SerializeField]
        private TextMeshProUGUI _textMesh;
        
        private void OnEnable()
        {
            MonologueSystem.LanguageChanged += OnLanguageChanged;
        }

        private void OnLanguageChanged(bool isEng)
        {
            _textMesh.text = isEng ? TextEng : TextRus;
        }
    }
}