using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BatterySpawner6 : MonoBehaviour
{
    public GameObject battery;
    public int batteriesToSpawn = 10;
    public GameObject[] walls;

    // Start is called before the first frame update
    void Start()
    {
        walls = GameObject.FindGameObjectsWithTag("Wall");
        for (int i = 0; i < batteriesToSpawn; i++)
        {
            Vector3 randomPosition;
            bool positionValid = false;

            do
            {
                float randomX = Random.Range(-19f, 29f);
                float randomZ = Random.Range(-19f, 29f);
                randomPosition = new Vector3(randomX, 1f, randomZ);

                bool intersectsWithWall = false;

                // проверка на старт и финиш
                if (randomX >= 20f && randomX <= 29f && randomZ >= -19f && randomZ <= -11f)
                {
                    intersectsWithWall = true;
                }
                else if (randomX >= -20f && randomX <= -9f && randomZ >= -20f && randomZ <= -9f)
                {
                    intersectsWithWall = true;
                }
                else
                {
                    foreach (GameObject wall in walls)
                    {
                        Vector3 wallPosition = wall.transform.position;
                        if (Vector3.Distance(randomPosition, wallPosition) < 5.0f)
                        {
                            intersectsWithWall = true;
                            break;
                        }
                    }
                }

                if (!intersectsWithWall)
                {
                    positionValid = true;
                }
            } while (!positionValid);

            Instantiate(battery, randomPosition, Quaternion.identity);
        }
    }
}
