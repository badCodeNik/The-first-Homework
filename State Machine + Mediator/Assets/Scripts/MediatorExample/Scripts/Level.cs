using UnityEngine;

namespace MediatorExample.Scripts
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private int pointsPerLevel = 200;
        [SerializeField] private int interval = 1;
        private float _timer;
        private int _experiencePoints;

        private void Update()
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                GainExperience(20);
                _timer += interval;
            }
            Debug.Log(GetLevel());
        }

        private void GainExperience(int exp)
        {
            _experiencePoints += exp;
        }

        public void ResetLevel()
        {
            _experiencePoints = 0;
        }

        public float GetExperience()
        {
            return _experiencePoints;
        }

        public int GetLevel()
        {
             return _experiencePoints / pointsPerLevel;
        }
    }
}