using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ConnectFour
{
    public class LookAtPlayer : MonoBehaviour
    {
        [SerializeField] private TMP_Text _winnerText;
        private Transform _camera;

        private void Start()
        {
            _camera = Camera.main.transform;
        }


        private void Update()
        {
            _winnerText.transform.LookAt(_camera);
            _winnerText.transform.Rotate(0, 180, 0);
        }
    }
}
