using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace Rebellion.Game
{
    public class RebellionGridManager : MonoBehaviour
    {
        public class GridTile
        {
            public Image ImageReference;

            public GridTile(Image sprite)
            {
                ImageReference = sprite;
            }
        }

        public int GridSize = 100;
        public int Rows = 6;
        public int Columns = 6;
        public float TileUIOffset = 0.5f;

        public GameObject GridTilePrefab;

        private List<GridTile> mGridTiles = new List<GridTile>();

        public void Init()
        {
            mGridTiles = new List<GridTile>();

            Vector3 position = transform.position;

            for(int i = 0; i < Columns; i++)
            {
                for(int j = 0; j < Rows; j++)
                {
                    position = transform.position;
                    position.x += GridSize * 0.5f;
                    position.z -= GridSize * 0.5f;

                    position.x += j * GridSize;
                    position.z += i * -GridSize;

                    Vector3 castPos = position;

                    castPos.y += 100f;

                    RaycastHit hit;

                    if (Physics.Raycast(castPos, Vector3.down, out hit, 1000f))
                    {
                        castPos = hit.point;
                    }

                    castPos.y += TileUIOffset;

                    GameObject tile = GameObject.Instantiate(GridTilePrefab);
                    tile.transform.SetParent(transform, false);
                    tile.transform.position = castPos;

                    GridTile newTile = new GridTile(tile.GetComponent<Image>());

                    mGridTiles.Add(newTile);
                }
            }
        }

        public void OnDrawGizmos()
        {
            Vector3 origin = transform.position;

            Vector3 lineStart = origin;
            Vector3 lineEnd = origin;

            for (int i = 0; i <= Columns; i++)
            {
                lineStart = origin;
                lineStart.z -= GridSize * i;
                lineEnd = origin;
                lineEnd.z -= GridSize * i;
                lineEnd.x += Rows * GridSize;

                Gizmos.DrawLine(lineStart, lineEnd);
            }

            for (int i = 0; i <= Rows; i++)
            {
                lineStart = origin;
                lineStart.x += GridSize * i;
                lineEnd = origin;
                lineEnd.x += GridSize * i;
                lineEnd.z -= Columns * GridSize;

                Gizmos.DrawLine(lineStart, lineEnd);
            }
        }
    }
}
