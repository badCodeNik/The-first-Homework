using UnityEngine;

namespace MediatorExample.Scripts
{
    public class LevelManager : MonoBehaviour
    {
        private int _level;
        private int _lastLevel;
        private int _hp;
        private int _exp;
        private int _levelTreshold = 10;

        private void Start()
        {
            _level = 1;
        }

        private void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.A)) _exp++;
        }

        private void LevelUp()
        {
            if (_exp >= _levelTreshold)
            {
                _level++;
                _levelTreshold += _level;
            }
        }
        
        private void ResetLevel
    }
}