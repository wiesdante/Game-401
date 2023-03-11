using UnityEngine;
using UnityEngine.Serialization;

public class WeaponParent : MonoBehaviour
{
    public SpriteRenderer playerRenderer,weaponRenderer; // Needs to be set from inspector
    public Vector2 mousePosition;

    private bool _lookingRight = true;

    private void Update()
    {
        #region Looking at pointer

        var transform1 = transform;
        Vector2 direction = (mousePosition - (Vector2)transform1.position).normalized;
        transform1.right = direction;

        #endregion

        #region Mirroring when switching sides

        Vector2 scale = transform1.localScale;
        if (direction.x < 0 && _lookingRight)
        {
            scale.y *= -1;
            _lookingRight = !_lookingRight;
        }
        else if (direction.x > 0 && !_lookingRight)
        {
            scale.y *= -1;
            _lookingRight = !_lookingRight;
        }
        transform1.localScale = scale;

        #endregion

        #region Changing weapon render order depending on position

        if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
        {
            weaponRenderer.sortingOrder = playerRenderer.sortingOrder - 1;
        }
        else
        {
            weaponRenderer.sortingOrder = playerRenderer.sortingOrder + 1;
        }

        #endregion
        
    }
}
