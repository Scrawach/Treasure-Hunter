using System.Collections;
using TMPro;
using UnityEngine;

namespace UI.Monologue
{
    [RequireComponent(typeof(CanvasGroup))]
    public class TextUI : MonoBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI _textMeshProUGUI;

        private CanvasGroup _canvasGroup;

        private void Awake() => 
            _canvasGroup = GetComponent<CanvasGroup>();

        public void Construct(string text, float lifeTime)
        {
            _textMeshProUGUI.text = text;
            StartCoroutine(Fading(lifeTime));
        }

        private IEnumerator Fading(float time)
        {
            var step = Time.fixedDeltaTime / time;
            var transformStep = Vector3.up * Time.fixedDeltaTime;
            var t = 0f;
            
            while (t < 1)
            {
                _canvasGroup.alpha = 1 - t;
                transform.localPosition += transformStep;
                t += step;
                yield return new WaitForFixedUpdate();
            }

            Destroy(gameObject);
        }
    }
}