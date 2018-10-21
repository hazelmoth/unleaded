using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLoader : MonoBehaviour {

	public GameObject[] tilePrefabs;
	public GameObject player;
	public GameObject edgeColliderBack;
	public GameManager gameManager;

	private List<GameObject> tilesInScene = new List<GameObject>();
	private Vector3 lastTilePosition;

	void Start () {
		gameManager = FindObjectOfType<GameManager> ();

		GameObject startTile = GameObject.FindGameObjectWithTag ("Tile");
		tilesInScene.Add (startTile);
		lastTilePosition = new Vector3 (0, 0, 0);
	}

	void Update () {
		if (lastTilePosition.z - player.transform.position.z < 200)
		{
			InstantiateNewTile ();
			ResetBackEdgeCollider ();
			DeleteOldTiles ();
			ShiftTilesBack ();
			gameManager.IncrementDistance ();
		}
	}

	void InstantiateNewTile () {
		tilesInScene.Add(GameObject.Instantiate (tilePrefabs [Random.Range (0, tilePrefabs.Length)], new Vector3 (0, 0, lastTilePosition.z + 200), Quaternion.identity));
		lastTilePosition = new Vector3 (0, 0, lastTilePosition.z + 200);
	}

	void DeleteOldTiles () {
		foreach (GameObject tile in tilesInScene.ToArray())
		{
			if (player.transform.position.z - tile.transform.position.z > 400)
			{
				Destroy (tile);
				tilesInScene.Remove (tile);
			}
		}
	}

	void ResetBackEdgeCollider ()
	{
		edgeColliderBack.transform.position = new Vector3 (0, 10, player.transform.position.z - 70);
	}

	void ShiftTilesBack ()
	{
		Vector3 shiftVector = new Vector3 (0, 0, -200);
		foreach (GameObject tile in tilesInScene)
		{
			tile.transform.position += shiftVector;
		}
		player.transform.position += shiftVector;
		edgeColliderBack.transform.position += shiftVector;
		lastTilePosition += shiftVector;
	}
}
