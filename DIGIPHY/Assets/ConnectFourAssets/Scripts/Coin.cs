using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConnectFour
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private CoinType _coinType;
        private Vector3 _startPosition;
        private Quaternion _startRotation;

        public CoinType CoinType => _coinType;

        private void Awake()
        {
            _startPosition = transform.localPosition;
            _startRotation = transform.localRotation;
        }

        public void ResetPosition()
        {
            transform.localPosition = _startPosition;
            transform.localRotation = _startRotation;
        }
    }
}