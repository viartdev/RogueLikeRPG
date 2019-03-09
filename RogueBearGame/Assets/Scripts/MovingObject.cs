using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{

    public LayerMask blockingLayer;

    private bool stepFinished = true;

    protected BoxCollider2D boxCollider;

    private IEnumerator coroutine;

    public enum Side
    {
        Up,
        Down,
        Left,
        Right
    }


    void Start()
    {
    }

    // Update is called once per frame

    IEnumerator MoveFromTo(GameObject objectToMove, Vector3 startPosition, Vector3 endPosition, float speed)
    {
        stepFinished = false;
        float step = (speed / (startPosition - endPosition).magnitude) * Time.fixedDeltaTime;
        float t = 0;
        while (t <= 1.0f)
        {
            t += step;
            objectToMove.transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return new WaitForFixedUpdate();
        }

        objectToMove.transform.position = endPosition;
        stepFinished = true;

    }

    Vector3 GetPosition(GameObject gameObject)
    {
        return gameObject.transform.position;
    }

    public void MoveObject(GameObject movingObject, Side movingSide)
    {
        Vector3 startPosition = GetPosition(movingObject);
        Vector3 endPosition = CalculateSideVector(startPosition, movingSide);

        RaycastHit2D hit;
        boxCollider.enabled = false;
        hit = Physics2D.Linecast(startPosition, endPosition, blockingLayer);
        boxCollider.enabled = true;

        if (hit.transform==null && stepFinished)
        {
            coroutine = MoveFromTo(movingObject, startPosition, endPosition, 5.0f);
            StartCoroutine(coroutine);
        }

    }

    private Vector3 CalculateSideVector(Vector3 vector, Side side)
    {
        switch (side)
        {
            case Side.Up:
                vector.y += 1;
                break;
            case Side.Down:
                vector.y -= 1;
                break;
            case Side.Left:
                vector.x -= 1;
                break;
            case Side.Right:
                vector.x += 1;
                break;
        }

        return vector;
    }



}
