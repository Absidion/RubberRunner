using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BloodSaver
{
    public static List<int> sections = new List<int>();
    public static List<Vector3> locations = new List<Vector3>();
    public static List<int> oldSections = new List<int>();
    public static List<Vector3> oldLocations = new List<Vector3>();
    public static int currentTile = -1;
    private static GameObject bloodSplatter = Resources.Load("BloodSplatter") as GameObject;
    private static GameObject LastCollidedTile;

    static BloodSaver()
    {
        //// Load sizes
        //int sectionCount = PlayerPrefs.GetInt("sectionCount");
        //int locationCount = PlayerPrefs.GetInt("locationCount");

        //// Load sections
        //for (int i = 0; i < sectionCount; i++)
        //{
        //    int element = PlayerPrefs.GetInt("section" + i);
        //    sections.Add(element);
        //}

        //// Load locations
        //for (int i = 0; i < locationCount; i++)
        //{
        //    float elementX = PlayerPrefs.GetFloat("locationX" + i);
        //    float elementY = PlayerPrefs.GetFloat("locationY" + i);
        //    float elementZ = PlayerPrefs.GetFloat("locationZ" + i);
        //    Vector3 location = new Vector3(elementX, elementY, elementZ);
        //    locations.Add(location);
        //}
    }

    public static void IncrementTile()
    {
        currentTile++;
    }

    public static void InitialSpawn()
    {
        int i = 0;
        while (i < 4)
        {
            if (sections.Count > 0)
            {
                if (sections[0] == i)
                {
                    SpawnInstance();
                }
                else
                {
                    i++;
                }
            }
            else
            {
                return;
            }
        }
    }

    public static void CheckForTile()
    {
        if (sections.Count > 0)
        {
            int difference = sections[0] - currentTile;

            if (difference == 4)
            {
                SpawnInstance();
            }
        }
    }

    private static void SpawnInstance()
    {
        if (locations.Count > 0 && sections.Count > 0)
        {
            Vector3 position = locations[0];
            MonoBehaviour.Instantiate(bloodSplatter, position, bloodSplatter.transform.rotation);
            locations.RemoveAt(0);
            sections.RemoveAt(0);
        }
    }

    public static void AddSplatter(Vector3 position)
    {
        //bool dupe = false;

        //Save blood splatter
        sections.Add(currentTile);
        locations.Add(position);

        //// Save tile
        //for (int i = 0; i < sections.Count; i++)
        //{
        //    string name = "section" + i;
        //    PlayerPrefs.SetInt(name, sections[i]);
        //}

        //// Save position
        //for (int i = 0; i < locations.Count; i++)
        //{
        //    string nameX = "locationX" + i;
        //    string nameY = "locationY" + i;
        //    string nameZ = "locationZ" + i;
        //    PlayerPrefs.SetFloat(nameX, position.x);
        //    PlayerPrefs.SetFloat(nameY, position.y);
        //    PlayerPrefs.SetFloat(nameZ, position.z);
        //}

        //// Save array sizes
        //PlayerPrefs.SetInt("sectionCount", sections.Count);
        //PlayerPrefs.SetInt("locationCount", locations.Count);

        //if (oldLocations.Count == 0)
        //{
        //    oldSections.Add(currentTile);
        //    oldLocations.Add(position);
        //    return;
        //}

        //for (int i = 0; i < oldLocations.Count; i++)
        //{
        //    if (position == oldLocations[i])
        //    {
        //        dupe = true;
        //    }
        //}

        //if (dupe == false)
        //{
        //    oldSections.Add(currentTile);
        //    oldLocations.Add(position);

        //    return;
        //}
    }

    public static void Reset()
    {
        currentTile = -1;
    }

    public static void SetLastCollidedTile(GameObject prefab)
    {
        LastCollidedTile = prefab;
    }

    public static GameObject GetLastCollidedTile()
    {
        return LastCollidedTile;
    }
}
