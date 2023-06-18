using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private GameObject _gunMiddle;
    [SerializeField] private GameObject _mainObject;
    [SerializeField] private SpriteRenderer _gunSprite;

    private Camera _camera;
    private Vector2 _mousePosition;
    private bool _lookingRight = true;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        MouseLoook();
        Flip();
    }

    private void MouseLoook()
    {
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        _gunMiddle.transform.right = _mousePosition - new Vector2(_gunMiddle.transform.position.x, _gunMiddle.transform.position.y);
    }

    private void Flip()
    {
        if (_gunMiddle.transform.eulerAngles.z > 90f && _gunMiddle.transform.eulerAngles.z < 270f && _lookingRight)
        {
            _gunSprite.flipY = true;
            _mainObject.transform.Rotate(0, 180, 0);
            _lookingRight = false;
        }
        else if (_gunMiddle.transform.eulerAngles.z < 90f && !_lookingRight || _gunMiddle.transform.eulerAngles.z > 270f && !_lookingRight)
        {
            _gunSprite.flipY = false;
            _mainObject.transform.Rotate(0, -180, 0);
            _lookingRight = true;
        }
    }
}
