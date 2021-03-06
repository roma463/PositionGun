using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private SpriteRenderer _pointCollisionLine;
    [SerializeField] private LayerMask _lineCollision;
    [SerializeField] private Transform _gunPoint;
    public void TrajectoryBullet(Vector2 velosity)
    {
        Vector3[] points = new Vector3[500];
        points[0] = (Vector2)_gunPoint.position;
        for (int i = 1; i < points.Length; i++)
        {
            float time = i * .1f;
            points[i] = ((Vector2)transform.position + (velosity) * time + (Physics2D.gravity * Mathf.Pow(time, 2) / 2f));
            var hit = Physics2D.Raycast(points[i - 1], (points[i] - points[i - 1]).normalized, Vector2.Distance(points[i - 1], points[i]), _lineCollision);
            if (hit == true)
            {
                if (hit.collider.TryGetComponent(out CollisionSurface collision))
                {
                    _pointCollisionLine.color = Color.green;
                }
                else
                {
                    _pointCollisionLine.color = Color.red;
                }
                _pointCollisionLine.transform.position = hit.point;
                _lineRenderer.positionCount = i;
                break;
            }
        }
        _lineRenderer.SetPositions(points);
    }
}
