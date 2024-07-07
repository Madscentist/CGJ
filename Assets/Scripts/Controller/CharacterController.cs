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

        public Point point;
        public ToolList toolList;

        public bool infinite;

        public GameObject shieldEffector;

        public SpriteRenderer renderer;
        
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

            public Vector2 lookAt;
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

        private float _imageRotateMax = 30f;
        private float _imageRotateMin = -30f;
        private float _imageTargetRotate;
        private float _imageCurrentRotate;
        
        private void Update()
        {
            InputUpdate();
            ToolUpdate();
            SpriteUpdate();
            
            shieldEffector.SetActive(_shieldOn);

            
            
            if (input.boost && !_boostInCool)
            {
                _inBoost = true;
                _boostApplyTime = setting.boostTime;
                _boostInCool = true;
                _boostCoolTime = setting.boostCoolTime;
            }

            if (input.gps && !_gpsCool)
            {
                point.Use(this);

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

        private bool _imageFirstRotate;
        private float _imageTargetRotateX;
        private float _imageCurrentRotateX;
        private void SpriteUpdate()
        {

            renderer.color = _shieldOn ? Color.yellow : Color.white;
            
            if (input.movement.x > 0f)
            {
                renderer.flipX = false;
                _imageTargetRotate = _imageRotateMax;
            }

            if (input.movement.x < 0f)
            {
                renderer.flipX = true;
                _imageTargetRotate = _imageRotateMin;
            }

            if (input.movement.x == 0)
            {
                _imageTargetRotate = 0f;
            }

            if (input.movement.y > 0f)
            {
                _imageTargetRotateX = 30f;
            }

            if (input.movement.y < 0f)
            {
                _imageTargetRotateX = -30f;

            }

            if (input.movement.y == 0f)
            {
                _imageTargetRotateX = 0f;

            }
            
            // if (input.movement.magnitude > 0.1f)
            // {
            //     
            //     if (_imageFirstRotate)
            //     {
            //         _imageTargetRotate = _imageRotateMax;
            //         _imageFirstRotate = false;
            //     }
            //     
            //     if (Mathf.Abs(_imageCurrentRotate - _imageRotateMax) < 0.1f)
            //     {
            //         _imageTargetRotate = _imageRotateMax;
            //     }
            //
            //     if (Mathf.Abs(_imageCurrentRotate - _imageRotateMin) < 0.1f)
            //     {
            //         _imageTargetRotate = _imageRotateMin;
            //     }
            // }
            // else
            // {
            //     _imageFirstRotate = true;
            //     _imageTargetRotate = 0f;
            // }
            _imageCurrentRotate = Mathf.Lerp(_imageCurrentRotate, _imageTargetRotate, 10f * Time.deltaTime);
            _imageCurrentRotateX = Mathf.Lerp(_imageCurrentRotateX, _imageTargetRotateX, 10f * Time.deltaTime);
            
            renderer.transform.eulerAngles = new Vector3(_imageCurrentRotateX, 0f, _imageCurrentRotate);

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

            if (_shieldOn)
            {
                _shieldExitTime -= Time.deltaTime;
                if (_shieldExitTime < 0f)
                {
                    _shieldOn = false;
                }
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

            gameObject.tag = _inBoost ? "Untagged" : "Player";

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

        public Vector2 Velocity()
        {
            return _rb.velocity;
        }

        private void AccelerateEnd()
        {
            _accelerateRate = 0f;
        }

        private float _shieldExitTime;

        public void ShieldOn()
        {
            _shieldOn = true;
            _shieldExitTime = 10f;
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