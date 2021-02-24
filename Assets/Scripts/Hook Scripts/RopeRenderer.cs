using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{

    private LineRenderer _lineRenderer;
    [SerializeField] private Transform _startPosition;

    private float _line_Width = 0.05f;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.startWidth = _line_Width;
        _lineRenderer.enabled = false;
    }


    public void RenderLine(Vector3 endPosition, bool enableRenderer)
    {
        if (enableRenderer)
        {
            if (!_lineRenderer.enabled)
            {
                _lineRenderer.enabled = true;
            }

            _lineRenderer.positionCount = 2;
        }

        else
        {
            _lineRenderer.positionCount = 0;

            if (_lineRenderer.enabled)
            {
                _lineRenderer.enabled = false;
            }
        }

        if (_lineRenderer.enabled)
        {
            Vector3 temp = _startPosition.position;
            temp.z = -10f;

            _startPosition.position = temp;

            temp = endPosition;
            temp.z = 0f;

            endPosition = temp;
            _lineRenderer.SetPosition(0, _startPosition.position);
            _lineRenderer.SetPosition(1, endPosition);
        }
    }

}
