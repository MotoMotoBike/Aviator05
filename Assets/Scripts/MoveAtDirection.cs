using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAtDirection : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] Direction direction;
    [SerializeField] float lifeTime;
    float currentLifeTime = 0;

    void Update()
    {
        ChekLifeTime();
        MovePosition();
    }

    void MovePosition()
    {
        transform.position += (direction == Direction.Up ? Vector3.up : Vector3.down)
            * speed
            * Time.deltaTime;
    }

    void ChekLifeTime()
    {
        currentLifeTime += Time.deltaTime;
        if (currentLifeTime >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    public enum Direction
    {
        Up, Down
    }
}
