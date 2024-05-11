using UnityEngine;
using UnityEngine.UI;

namespace MediatorExample.Scripts
{
    public class RestartPanel : MonoBehaviour
    {
        [SerializeField] private Button restart;

        public Button Restart => restart;

        private void OnEnable()
        {
            restart.onClick.AddListener(OnRestartClick);
        }

        private void OnDisable()
        {
            restart.onClick.RemoveListener(OnRestartClick);
        }

        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);


        private void OnRestartClick()
        {
            restart.onClick.Invoke();
        }
    }
}