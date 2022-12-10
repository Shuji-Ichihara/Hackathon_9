using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerTest : MonoBehaviour
{
    [SerializeField]
    private float _movePlayerSpeed = 0.0f;          // プレイヤーの移動速度

    private Rigidbody _rb = null;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }

    private void Update()
    {
        Debug.Log(this.transform.position);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    /// <summary>
    /// プレイヤーの移動
    /// </summary>
    private void MovePlayer()
    {
        // 前移動
        if(Input.GetKey(KeyCode.W))
        {
            _rb.AddForce(new Vector3(_movePlayerSpeed * Time.deltaTime
                                    ,0.0f
                                    ,0.0f));
        }
        // 後移動
        if (Input.GetKey(KeyCode.S))
        {
            _rb.AddForce(new Vector3(-(_movePlayerSpeed * Time.deltaTime)
                                    ,0.0f
                                    ,0.0f));
        }
        // 左移動
        if (Input.GetKey(KeyCode.A))
        {
            _rb.AddForce(new Vector3(0.0f
                                    ,0.0f
                                    ,-(_movePlayerSpeed * Time.deltaTime)));
        }
        // 右移動
        if (Input.GetKey(KeyCode.D))
        {
            _rb.AddForce(new Vector3(0.0f
                                    ,0.0f
                                    ,_movePlayerSpeed * Time.deltaTime));
        }
    }
}
