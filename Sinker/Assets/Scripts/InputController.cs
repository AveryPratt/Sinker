using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private static InputController _instance;
    public static InputController Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<InputController>();
            }
            return _instance;
        }
    }

    private Vector3 _mouseWorldPosition;
    public Vector3 MouseWorldPosition
    {
        get
        {
            return _mouseWorldPosition;
        }
        private set
        {
            value.z = 0;
            _mouseWorldPosition = value;
        }
    }

    public Movable GrabbedObject { get; set; }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        MouseWorldPosition = hit.point;
        if (Input.GetMouseButtonDown(0))
        {
            Movable movable = hit.transform.GetComponent<Movable>();
            if (movable && movable.Grab())
            {
                GrabbedObject = movable;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            GrabbedObject.Handle.Release();
        }
    }
}
