using UnityEngine;
using System.Collections;

public class StopOnTouch : MonoBehaviour
{

    Vector2 MinPos;
    Vector2 MaxPos;
    Vector2 targetPos;
    public float Speed = 2;
    public float thresholdStopDistance = .3f;

    void Start()
    {
        Vector2 Size = GetComponent<SpriteRenderer>().bounds.extents;
        MinPos = (Vector2)Camera.main.ViewportToWorldPoint(new Vector2(0, 0)) + Size;
        MaxPos = (Vector2)Camera.main.ViewportToWorldPoint(new Vector2(1, 1)) - Size;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = (Input.mousePosition);
             targetPos= new Vector2(Camera.main.ScreenToWorldPoint(mousePos).x, Camera.main.ScreenToWorldPoint(mousePos).y);

            targetPos.x = Mathf.Clamp(targetPos.x, MinPos.x, MaxPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y, MinPos.y, MaxPos.y);

            transform.position = Vector2.Lerp(transform.position, targetPos, Time.deltaTime * Speed);
        }
        else if (!Input.GetMouseButton(0) && Vector2.Distance(targetPos, transform.position) > thresholdStopDistance)
        {
            transform.position = Vector2.Lerp(transform.position, targetPos, Speed * Time.deltaTime);
        }
    }


}
