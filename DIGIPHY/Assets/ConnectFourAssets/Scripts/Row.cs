using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConnectFour
{
    public class Row : MonoBehaviour
    {
        [SerializeField] private int _rowIndex;

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent<Coin>(out Coin coin))
            {
                GameManager.Instance.AddCoin(coin.CoinType, _rowIndex);
            }
        }
    }
}
