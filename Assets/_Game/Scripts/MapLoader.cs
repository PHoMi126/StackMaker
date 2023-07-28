using System.Collections.Generic;
using UnityEngine;

public class MapLoader : MonoBehaviour
{
    public List<GameObject> mapPrefabs;

    void Start()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("Maps", typeof(TextAsset));
        string s = textAsset.text;
        s = s.Replace("\n", "");

        for (int i = 0; i < s.Length; i++)
        {

        }
    }
}
