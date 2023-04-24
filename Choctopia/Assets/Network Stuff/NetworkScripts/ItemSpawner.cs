using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public int spawnerId;
    public bool hasItem;
    public SpriteRenderer itemSprite;

    public float itemRotationSpeed = 50f;
    public float itemBobSpeed = 2f;
    private Vector3 basePosition;

    private void Update()
    {
        //if (hasItem)
        //{
        //    transform.Rotate(Vector3.up, itemRotationSpeed * Time.deltaTime, Space.World);
        //    transform.position = basePosition + new Vector3(0f, 0.25f * Mathf.Sin(Time.time * itemBobSpeed), 0f);
        //}
    }

    public void Initialize(int _spawnerId, bool _hasItem)
    {
        spawnerId = _spawnerId;
        hasItem = _hasItem;
        itemSprite.enabled = _hasItem;

        basePosition = transform.position;
    }

    public void ItemSpawned()
    {
        Debug.Log("Item Spawned");
        hasItem = true;
        itemSprite.enabled = true;
    }

    public void ItemPickedUp()
    {
        Debug.Log("Item Picked Up");
        hasItem = false;
        itemSprite.enabled = false;
    }
}
