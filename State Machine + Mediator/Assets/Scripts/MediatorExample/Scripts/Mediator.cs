using UnityEngine;

namespace MediatorExample.Scripts
{
    public class Mediator : MonoBehaviour
    {
        [SerializeField] private Level level;
        [SerializeField] private Health health;
        [SerializeField] private RestartPanel panel;

        private void OnEnable()
        {
            panel.Restart.onClick.AddListener(ResetData);
            health.Death += OnDied;
        }

        private void OnDisable()
        {
            health.Death -= OnDied;
            panel.Restart.onClick.RemoveListener(ResetData);
        }

        private void OnDied()
        {
            panel.Show();
        }

        private void ResetData()
        {
            health.ResetHealth();
            level.ResetLevel();
            panel.Hide();
        }
    }
}