using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
   public GameObject BeatTile;
   public Transform spawnPoint;

   public void SpawnBeat()
   {
      GameObject childObject = Instantiate(BeatTile, spawnPoint);
   }
}
