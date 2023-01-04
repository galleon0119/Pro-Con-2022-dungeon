
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
            // ���o�����ʒu��񂩂�^�C���}�b�v�p�̈ʒu���(�Z�����W)���擾
            Vector3Int cellPosition = new Vector3Int(pos.x, pos.y, pos.z);

            // tilemap.HasTile -> �^�C�����ݒ�(�`��)����Ă�����W�ł��邩����
            if (tilemap.HasTile(cellPosition))
            {
                // �X�v���C�g����v���Ă��邩����
                if (tilemap.GetSprite(cellPosition) == sprite)
                {
                    // ����̃X�v���C�g�ƈ�v���Ă���ꍇ�͕ʂ̃^�C����ݒ肷��
                    tilemap.SetTile(cellPosition, replaceTile);
                }
            }
        }
    }
}