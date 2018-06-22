using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class GameManager : MonoBehaviour {

    public TileManager TileManager;
    public GameObject Player;
    public Vector3 PlayerSpawn;

    private TileManager ExistingTileManager;
    private GameObject ExistingPlayer;

    private bool isGOActive = false;

    //public Canvas GameOverCanvas;


    // Use this for initialization
    void Start() {
        ExistingTileManager = Instantiate(TileManager, new Vector3(0, 0, 0), Quaternion.identity);
        ExistingPlayer = Instantiate(Player, PlayerSpawn, Quaternion.identity);
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }

    public void Reset()
    {
        DestroyObject(ExistingTileManager);
        DestroyObject(GameObject.Find("TileManager(Clone)"));
        DestroyObject(GameObject.Find("Explosion(Clone)"));
        DestroyObject(ExistingPlayer);
        DestroyObject(GameObject.Find("Player(Clone)"));
        // GameOverCanvas.enabled = true;

        ExistingTileManager = Instantiate(TileManager, new Vector3(0, 0, 0), Quaternion.identity);
        ExistingPlayer = Instantiate(Player, PlayerSpawn, Quaternion.identity);
        PlayerController.score = 0;
        BloodSaver.Reset();
    }
}
