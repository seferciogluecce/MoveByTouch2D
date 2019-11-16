using UnityEngine;

public class MoveWithOffset : MonoBehaviour
{
    Vector2 MinPos;
    Vector2 MaxPos;
    Vector2 mousePos;
    Vector2 Offset;

    void Start()
    {
        Vector2 Size = GetComponent<SpriteRenderer>().bounds.extents;
        MinPos = (Vector2)Camera.main.ViewportToWorldPoint(new Vector2(0, 0)) + Size;
        MaxPos = (Vector2)Camera.main.ViewportToWorldPoint(new Vector2(1, 1)) - Size;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = (Input.mousePosition);
            Vector2 mouseInitialPosition = new Vector2(Camera.main.ScreenToWorldPoint(mousePos).x, Camera.main.ScreenToWorldPoint(mousePos).y);
            Offset = mouseInitialPosition-(Vector2)transform.position  ;
        }
       else if (Input.GetMouseButton(0))
        {
            mousePos = (Input.mousePosition);
            Vector2 targetPos = new Vector2(Camera.main.ScreenToWorldPoint(mousePos).x, Camera.main.ScreenToWorldPoint(mousePos).y);

            targetPos.x = Mathf.Clamp(targetPos.x - Offset.x, MinPos.x, MaxPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y - Offset.y, MinPos.y, MaxPos.y);
            transform.position = targetPos;
        }
    }
}
