using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class HookMovement : MonoBehaviour
{
    [SerializeField] private float min_Z = -55f, max_Z = 55f;
    [SerializeField] private float rotate_Speed;

    private float _rotate_Angle;
    private bool _rotate_Right;
    private bool _canRotate;

    [SerializeField] private float move_Speed = 3f;
    private float _inital_Move_Speed;

    [SerializeField] private float min_Y = -5f;
    public float _inital_Y { get; set; }
    public bool moveDown { get; set; }

    [SerializeField] private GameObject _button;
    [SerializeField] private AudioManager _audioManager;
    private UIManager _uiManager;
    private TagManager _tagManager;

    private Animator _animator;


    private RopeRenderer _ropeRenderer;

    private void Awake()
    {
        _tagManager = GameObject.Find("TagManager").GetComponent<TagManager>();
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        _animator = GameObject.Find("Player").GetComponent<Animator>();
        _ropeRenderer = GetComponent<RopeRenderer>();
        _animator.SetBool("Pull", false);
    }


    private void Start()
    {
        _inital_Y = transform.position.y;
        _inital_Move_Speed = move_Speed;

        _canRotate = true;



    }

    private void Update()
    {
        Rotate();
        GetInput();
        MoveRope();
    }


    private void Rotate()
    {
        if (!_canRotate)
            return;

        if (_rotate_Right)
        {
            _rotate_Angle += rotate_Speed * Time.deltaTime;
        }

        else
        {
            _rotate_Angle -= rotate_Speed * Time.deltaTime;
        }

        transform.rotation = Quaternion.AngleAxis(_rotate_Angle, Vector3.forward);


        if (_rotate_Angle >= max_Z)
        {
            _rotate_Right = false;
        }
        else if (_rotate_Angle <= min_Z)
        {
            _rotate_Right = true;
        }
    }


    private void GetInput()
    {
        if (Input.GetMouseButton(0) && EventSystem.current.currentSelectedGameObject == null)
        {
            if (_canRotate)
            {
                _canRotate = false;
                moveDown = true;
            }
        }
        else if (Input.GetMouseButton(0) && EventSystem.current.currentSelectedGameObject == _button)
        {
            return;
        }

    }


    private void MoveRope()
    {
        if (_canRotate)
        {
            _audioManager.transform.GetChild(0).gameObject.SetActive(false);
            return;
        }
        

        if (!_canRotate)
        {
            if (_uiManager._isGamePaused == false)
            {
                _audioManager.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                _audioManager.transform.GetChild(0).gameObject.SetActive(false);
            }

            Vector3 temp = transform.position;
            if (moveDown)
            {
                temp -= transform.up * Time.deltaTime * move_Speed;
                _animator.SetBool("Pull", true);
            }
            else
            {
                temp += transform.up * Time.deltaTime * move_Speed;
                _animator.SetBool("Pull", true);

            }

            transform.position = temp;

            if (temp.y <= min_Y)
            {
                moveDown = false;
            }

            if (temp.y >= _inital_Y)
            {
                _animator.SetBool("Pull", false);

                _canRotate = true;
                _ropeRenderer.RenderLine(temp, false);

                move_Speed = _inital_Move_Speed;


            }

            _ropeRenderer.RenderLine(transform.position,true);

        }
    }
}
