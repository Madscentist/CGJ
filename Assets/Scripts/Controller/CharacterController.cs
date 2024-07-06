using System;
using UnityEngine;

namespace Controller
{
    public class CharacterController : MonoBehaviour
    {
        public Inputs input;
        public Settings setting;

        private Rigidbody2D _rb;
        private CharacterInput _inputClass;

        [Serializable]
        public struct Inputs
        {
            public Vector2 movement;
        }

        [Serializable]
        public struct Settings
        {
            public float walkVelocity;
            public float jumpSpeed;
        }

        private void Awake()
        {
            _inputClass = new CharacterInput();
        }

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            _inputClass.Enable();
        }

        private bool _isJump;
        private float _jumpCoolTime;

        private void Update()
        {
            InputUpdate();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isJump = true;
                _jumpCoolTime = 0.5f;
            }
        }

        private void FixedUpdate()
        {
            if (_isJump)
            {
                _isJump = false;
                _rb.AddForce(setting.jumpSpeed * input.movement);
            }

            if (_jumpCoolTime <= 0f)
            {
                _rb.AddForce(input.movement * setting.walkVelocity);
            }
            else
            {
                _jumpCoolTime -= Time.fixedDeltaTime;
            }
        }

        private void InputUpdate()
        {
            input.movement = _inputClass.Player.movement.ReadValue<Vector2>();
        }
    }
}