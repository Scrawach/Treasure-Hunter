using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CameraLogic
{
    public class EngGameCutScene : MonoBehaviour
    {
        [SerializeField] 
        private GameObject Hero;

        [SerializeField] 
        private GameObject _chestOnTheThrone;

        [SerializeField] 
        private CanvasGroup _fade;
        
        [SerializeField] 
        private Camera _camera;

        [SerializeField] 
        private TextMeshProUGUI _lastWord;

        [SerializeField] 
        private GameObject _restartButton;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                GameEnd();
            }
        }

        public void GameEnd()
        {
            StartCoroutine(Fading());
        }

        private IEnumerator Fading()
        {
            _fade.gameObject.SetActive(true);
            var startValue = _fade.alpha;
            var t = 0f;

            while (t < 1f)
            {
                t += Time.fixedDeltaTime / 3;
                _fade.alpha = Mathf.Lerp(0, 1, t);
                yield return new WaitForFixedUpdate();
            }
            
            Hero.gameObject.SetActive(false);
            _chestOnTheThrone.SetActive(true);
            _camera.GetComponent<CameraFollow>().enabled = false;
            _camera.GetComponent<Animator>().enabled = true;
            var notActivateText = true;

            t = 1f;
            while (t > 0)
            {
                t -= Time.fixedDeltaTime / 10;
                
                if (t < 0.5 && notActivateText)
                {
                    _lastWord.gameObject.SetActive(true);
                    notActivateText = false;
                }
                
                _fade.alpha = Mathf.Lerp(1, 0, t);
                yield return new WaitForFixedUpdate();
            }
            
            _restartButton.gameObject.SetActive(true);
        }
    }
}