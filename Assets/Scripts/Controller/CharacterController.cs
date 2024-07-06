using System;
using System.Collections.Generic;
using Controller.Tools;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controller
{
    public class CharacterController : MonoBehaviour
    {
        public Inputs input;
        public Settings setting;

        public Gps gps;
        public ToolList toolList;

        public bool infinite;
        private bool _shieldOn;
        
        [Serializable]
        public struct ToolList
        {
            public Tool tool1;
            public Tool tool2;
            public Tool tool3;
            public Tool tool4;
        }

        private Rigidbody2D _rb;
        private CharacterInput _inputClass;

        [Serializable]
        public struct Inputs
        {
            public Vector2 movement;
            public bool tool1;
            public bool tool2;
            public bool tool3;
            public bool tool4;

            public bool boost;
            public bool gps;
        }

        [Serializable]
        public struct Settings
        {
            public float walkVelocity;
            [FormerlySerializedAs("jumpSpeed")] public float boostSpeed;
            public float boostTime;
            public float boostCoolTime;
            public float gpsCoolTime;
        }

        private void Awake()
        {
            _inputClass = new CharacterInput();
        }

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _canMove = true;
        }

        private void OnEnable()
        {
            _inputClass.Enable();
        }

        private bool _inBoost;
        private float _boostApplyTime;
        private float _boostCoolTime;
        private bool _boostInCool;
        private bool _canMove;
        private bool _gpsCool;
        private float _gpsCoolTime;

        private void Update()
        {
            InputUpdate();
            ToolUpdate();

            if (input.boost && !_boostInCool)
            {
                _inBoost = true;
                _boostApplyTime = setting.boostTime;
                _boostInCool = true;
                _boostCoolTime = setting.boostCoolTime;
            }

            if (input.gps && !_gpsCool)
            {
                gps.Use(this);

                _gpsCool = true;
                _gpsCoolTime = setting.gpsCoolTime;

            }

            if (_gpsCool)
            {
                _gpsCoolTime -= Time.deltaTime;
                if (_gpsCoolTime < 0f)
                {
                    _gpsCool = false;
                }
            }

            if (_boostInCool)
            {
                _boostCoolTime -= Time.deltaTime;
                if (_boostCoolTime <= 0f)
                {
                    _boostInCool = false;
                }
            }
        }

        private void ToolUpdate()
        {
            if (input.tool1)
            {
                toolList.tool1.Use(this);
                return;
            }

            if (input.tool2)
            {
                toolList.tool2.Use(this);
                return;
            }

            if (input.tool3)
            {
                toolList.tool3.Use(this);
                return;
            }

            if (input.tool4)
            {
                toolList.tool4.Use(this);
            }
        }

        private void FixedUpdate()
        {
            if (_canMove)
            {
                if (_inBoost)
                {
                    _rb.AddForce(setting.boostSpeed * input.movement);
                }
                else
                {
                    _rb.AddForce(input.movement * (setting.walkVelocity * (1 + _accelerateRate
                        )));
                }
            }


            if (_boostApplyTime <= 0f)
            {
                _inBoost = false;
            }
            else
            {
                _boostApplyTime -= Time.fixedDeltaTime;
            }
        }

        private void InputUpdate()
        {
            input.movement = _inputClass.Player.movement.ReadValue<Vector2>();
            input.tool1 = _inputClass.Player.tool1.WasPerformedThisFrame();
            input.tool2 = _inputClass.Player.tool2.WasPerformedThisFrame();
            input.tool3 = _inputClass.Player.tool3.WasPerformedThisFrame();
            input.tool4 = _inputClass.Player.tool4.WasPerformedThisFrame();

            input.boost = _inputClass.Player.boost.WasPerformedThisFrame();
            input.gps = _inputClass.Player.gps.WasPerformedThisFrame();
        }

        public void EnableMove()
        {
            _canMove = true;
        }

        public void DisableMove()
        {
            _rb.velocity = Vector2.zero;
            _canMove = false;
        }

        public void DisableMove(float time)
        {
            _rb.velocity = Vector2.zero;
            _canMove = false;
            Invoke(nameof(EnableMove), time);
        }

        private float _accelerateRate;

        public void Accelerate(float rate, float time)
        {
            _accelerateRate = rate;
            Invoke(nameof(AccelerateEnd), time);
        }

        private void AccelerateEnd()
        {
            _accelerateRate = 0f;
        }

        public void ShieldOn()
        {
            _shieldOn = true;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Monster") && !infinite)
            {
                if (_shieldOn)
                {
                    _shieldOn = false;
                    return;
                }
                
                GameApi.GameApi.Instance.MonsterGetPlayer();
            }
        }
    }
}