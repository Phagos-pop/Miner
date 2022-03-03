using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombMaker : MonoBehaviour
{
    public Tilemap destructibleTilemap;
    public Tilemap bombTilemap;
    public Tile[] tileOfBomb;
    public Tile[] tileOfExplosion;
    public Hero hero;


    public void PlantingBomb(Vector2 position)
    {
        StartCoroutine(Planting(position));       
    }

    private IEnumerator Planting(Vector2 position)
    {
        Vector3Int positionOfBomb = bombTilemap.LocalToCell(position);
        Debug.Log(positionOfBomb);
        Vector3Int[] positionOfExplosion = new Vector3Int[]
        {
            positionOfBomb + new Vector3Int(0, 1, 0),
            positionOfBomb + new Vector3Int(0, -1, 0),
            positionOfBomb + new Vector3Int(-1, 0, 0),
            positionOfBomb + new Vector3Int(1, 0, 0)
        };
        for (int i = 0; i < tileOfBomb.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);
            bombTilemap.SetTile(positionOfBomb, tileOfBomb[i]);
            yield return new WaitForSeconds(0.5f);
            if (i == tileOfBomb.Length - 1)
            {
                for (int o = 0; o < positionOfExplosion.Length; o++)
                {
                    destructibleTilemap.SetTile(positionOfExplosion[o], tileOfExplosion[o]);
                    bombTilemap.SetTile(positionOfExplosion[o], tileOfExplosion[o]);
                }
                yield return new WaitForSeconds(0.5f);
                for (int o = 0; o < positionOfExplosion.Length; o++)
                {
                    destructibleTilemap.SetTile(positionOfExplosion[o], null);
                    bombTilemap.SetTile(positionOfExplosion[o], null);
                }
            }            
        }        
        bombTilemap.SetTile(positionOfBomb, null);
    }
}
