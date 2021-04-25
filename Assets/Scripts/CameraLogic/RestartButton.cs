using UnityEngine;
using UnityEngine.SceneManagement;

namespace CameraLogic
{
    public class RestartButton : MonoBehaviour
    {
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
