using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;

    private int Count = 0;
    private float zRangeStart = 9f;
    private float zRangeEnd = 73f;
    private float xRangeStart = 0f;
    private float xRangeEnd = 50f;
    private float yRangeStart = 2f;
    private float yRangeEnd = 12f;
    public Transform targetPosition;

    private void Start()
    {
        Count = 0;
        targetPosition.position = GetRandomPosition();
    }

    private void OnTriggerEnter(Collider other)
    {
        Count += 1;
        CounterText.text = "Count : " + Count;
        Destroy(other.gameObject);
        targetPosition.position = GetRandomPosition();
    }

    private Vector3 GetRandomPosition() {
        float randomX = Random.Range(xRangeStart, xRangeEnd);
        float randomY = Random.Range(yRangeStart, yRangeEnd);
        float randomZ = Random.Range(zRangeStart, zRangeEnd);
        Vector3 newPos = new Vector3(randomX, randomY, randomZ);
        return newPos;
    }
}
