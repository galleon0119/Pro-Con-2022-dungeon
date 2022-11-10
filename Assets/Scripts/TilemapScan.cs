
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
 
public class TilemapScan : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase replaceTile;
    public Sprite sprite;

    public void replaceTilemap()
    {
        foreach (var pos in tilemap.cellBounds.allPositionsWithin)
        {
            // 取り出した位置情報からタイルマップ用の位置情報(セル座標)を取得
            Vector3Int cellPosition = new Vector3Int(pos.x, pos.y, pos.z);

            // tilemap.HasTile -> タイルが設定(描画)されている座標であるか判定
            if (tilemap.HasTile(cellPosition))
            {
                // スプライトが一致しているか判定
                if (tilemap.GetSprite(cellPosition) == sprite)
                {
                    // 特定のスプライトと一致している場合は別のタイルを設定する
                    tilemap.SetTile(cellPosition, replaceTile);
                }
            }
        }
    }
}