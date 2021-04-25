using UnityEngine;

namespace UI.Monologue
{
    public class TextBuilder : MonoBehaviour
    {
        [SerializeField] 
        private TextUI _template;

        public void Build(string text, Vector3 position, float time)
        {
            var instance = Instantiate(_template, position, _template.transform.rotation);
            instance.Construct(text, time);
        }
    }
}
