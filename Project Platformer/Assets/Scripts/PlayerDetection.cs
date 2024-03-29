using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [Header("Ground Detection")]
    [SerializeField]
    private Vector2 _boxSize;
    [SerializeField]
    private float _groundCastDistance;
    [SerializeField]
    private LayerMask _groundLayer;

    [Header("Wall Detection")]
    [SerializeField]
    private float _wallCheckRadius;
    [SerializeField]
    private float _wallCastDistance;
    [SerializeField]
    private LayerMask _wallLayer;

    private bool isFacingRight = true;
    public bool GroundDetection()
    {
        return Physics2D.BoxCast(transform.position, _boxSize, 0, -transform.up, _groundCastDistance, _groundLayer);
    }

    public bool WallDetection(bool isFacingRight)
    {
        this.isFacingRight = isFacingRight;
        return (Physics2D.CircleCast(transform.position, _wallCheckRadius,
            isFacingRight ? transform.right : -transform.right,
            _wallCastDistance, _wallLayer));
        
    }

    private void OnDrawGizmos()
    {
        // Ground Detection Gizmo
        Gizmos.DrawWireCube(transform.position - transform.up * _groundCastDistance, _boxSize);

        // Wall Detection Gizmo
        Gizmos.DrawWireSphere(transform.position + (isFacingRight ? transform.right : -transform.right) * _wallCastDistance, _wallCheckRadius);
    }
}
