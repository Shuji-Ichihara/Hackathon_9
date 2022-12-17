using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    [SerializeField]
    private string _playerObjectName = "Player";
    private GameObject _playerObject = null;

    private Transform _transform = null;

    [SerializeField]
    private float _movePlayerPower = 500.0f;          // プレイヤーの移動速度
    [SerializeField]
    private float _rotatePlayerSpeed = 90.0f;

    public bool IsDead { get; set; }                   // プレイヤーの死亡フラグ

    private Rigidbody _rb = null;

    // Start is called before the first frame update
    void Start()
    {
        _playerObject = GameObject.Find(_playerObjectName);
        // プレイヤーオブジェクトにコンポーネントを追加する
        _rb = _playerObject.AddComponent<Rigidbody>() as Rigidbody;

        // 各コンポーネントのパラメータを初期化
        _playerObject.AddComponent<CapsuleCollider>();
        _transform = _playerObject.gameObject.transform;
        _transform.position = new Vector3(0.0f, 1.0f, 0.0f);
        _rb.freezeRotation = true;

        IsDead = false;
    }

    private void Update()
    {
        PlayerDeath();
        AjustPlayerDirection();
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
        if (Input.GetKey(KeyCode.W))
        {
            _rb.AddForce(_transform.rotation * Vector3.forward * _movePlayerPower * Time.deltaTime);
        }
        // 後移動
        if (Input.GetKey(KeyCode.S))
        {
            _rb.AddForce(_transform.rotation * Vector3.back * _movePlayerPower * Time.deltaTime);
        }
        /*
        // 左移動
        if (Input.GetKey(KeyCode.A))
        {
            _rb.AddForce(Vector3.left * _movePlayerSpeed * Time.deltaTime);
        }
        // 右移動
        if (Input.GetKey(KeyCode.D))
        {
            _rb.AddForce(Vector3.right * _movePlayerSpeed * Time.deltaTime);
        }
        */
    }

    /// <summary>
    /// プレイヤーの正面の向きの調整
    /// </summary>
    private void AjustPlayerDirection()
    {
        // 左移動
        if (Input.GetKey(KeyCode.A))
        {
            _transform.rotation *= Quaternion.AngleAxis(-_rotatePlayerSpeed * Time.deltaTime, Vector3.up);
        }
        // 右移動
        if (Input.GetKey(KeyCode.D))
        {
            _transform.rotation *= Quaternion.AngleAxis(_rotatePlayerSpeed * Time.deltaTime, Vector3.up);
        }

    }

    /// <summary>
    /// プレイヤーのジャンプ
    /// </summary>
    private void JumpPlayer()
    {

    }

    private void PlayerDeath()
    {
        if (true == IsDead)
        {
            /* Player が死ぬ*/
            _playerObject.gameObject.SetActive(false);
        }

    }
}
