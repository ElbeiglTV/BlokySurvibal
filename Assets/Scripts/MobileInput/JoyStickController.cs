using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickController : Controller, IDragHandler, IEndDragHandler
{
    Vector3 _initialPos;
    [SerializeField] float _maxMagnitude = 100;

    private void Start()
    {
        _initialPos = transform.position;
    }

    public override Vector3 GetMovementInput()
    {
        Vector3 modifiedMoveDir = new Vector3(_moveDir.x, 0, _moveDir.y);
        modifiedMoveDir = modifiedMoveDir / _maxMagnitude;
        return modifiedMoveDir;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _moveDir = Vector3.ClampMagnitude((Vector3)eventData.position - _initialPos, _maxMagnitude);
        transform.position = _initialPos + _moveDir;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = _initialPos;
        _moveDir = Vector3.zero;
    }
}
