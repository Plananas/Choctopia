using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public static Dictionary<int, ItemSpawner> spawners = new Dictionary<int, ItemSpawner>();
    private static int nextSpawnerId = 1;

    public int spawnerId;
    public bool hasItem = false;
    public Collider2D collider;
    int cooldown;

    private void Start()
    {
        hasItem = false;
        spawnerId = nextSpawnerId;
        nextSpawnerId++;
        spawners.Add(spawnerId, this);

        StartCoroutine(SpawnItem());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision");
        //if (other.CompareTag("Player"))
        //{
        Player _player = other.GetComponent<Player>();
        
        if (_player.AttemptPickupItem())
        {
            
            ItemPickedUp(_player.id);
        }
        //}
    }

    private IEnumerator SpawnItem()
    {
        int cooldown = Random.Range(10, 50);
        yield return new WaitForSeconds(cooldown);

        hasItem = true;
        collider.enabled = true;
        ServerSend.ItemSpawned(spawnerId);
    }

    private void ItemPickedUp(int _byPlayer)
    {
        hasItem = false;
        ServerSend.ItemPickedUp(spawnerId, _byPlayer);
        collider.enabled = false;

        StartCoroutine(SpawnItem());
    }
}