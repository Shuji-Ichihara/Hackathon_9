using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private PlayerTest _playerTest = null;

    private void Start()
    {
        if (_playerTest == null) { _playerTest = GetComponentInParent<PlayerTest>(); }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") == true)
        {
            _playerTest.IsDead = true;
        }
        else if (other.gameObject.CompareTag("Enemy") == false) { return; }
    }
}
