using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using Rebellion.Data;

namespace Rebellion.Game
{
    public class RebellionGridManager : MonoBehaviour
    {
        public class GridTile
        {
            public EntityData TileOccupantEntity;
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

        //private List<GridTile> mGridTiles = new List<GridTile>();
        private GridTile[,] mGridTiles = new GridTile[0, 0];

        public void Init()
        {
            mGridTiles = new GridTile[Rows, Columns];

            Vector3 position = transform.position;

            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    position = transform.position;
                    position.x += GridSize * 0.5f;
                    position.z -= GridSize * 0.5f;

                    position.x += row * GridSize;
                    position.z += column * -GridSize;

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

                    mGridTiles[row, column] = newTile;
                }
            }
        }

        public Vector3 GetWorldPositionOfTile(int rowIndex, int columnIndex)
        {
            Vector3 tempPos = Vector3.zero;

            try
            {
                tempPos = mGridTiles[rowIndex, columnIndex].ImageReference.transform.position;
            }
            catch (System.IndexOutOfRangeException e)
            {
                Debug.Log(string.Format("Tried to find position of tile at row {0} column {1}, but that address is out of range", rowIndex, columnIndex));
            }

            return tempPos;
        }

        public bool AddOccupantToTile(int rowIndex, int columnIndex, EntityData entity)
        {
            try
            {
                if (mGridTiles[rowIndex, columnIndex].TileOccupantEntity == null)
                {
                    mGridTiles[rowIndex, columnIndex].TileOccupantEntity = entity;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.IndexOutOfRangeException e)
            {
                Debug.Log(string.Format("Tried to add entity as occupant of row {0} column {1}, but that address is out of range", rowIndex, columnIndex));
                return false;
            }
        }

        public EntityData GetOccupantForTile(int rowIndex, int columnIndex)
        {
            EntityData tempData = null;

            try
            {
                tempData = mGridTiles[rowIndex, columnIndex].TileOccupantEntity;
            }
            catch (System.IndexOutOfRangeException e) 
            {
                Debug.Log(string.Format("Tried to find entity at row {0} column {1}, but that address is out of range", rowIndex, columnIndex));
            }

            return tempData;
        }

        public void OnDrawGizmos()
        {
            //Vector3 origin = transform.position;
            //Vector3 position = origin;

            //for (int row = 0; row < Rows; row++)
            //{
            //    for (int column = 0; column < Columns; column++)
            //    {
            //        position = origin;
            //        position.x += GridSize * 0.5f;
            //        position.z -= GridSize * 0.5f;

            //        position.x += row * GridSize;
            //        position.z += column * -GridSize;

            //        Vector3 castPos = position;

            //        castPos.y += 100f;

            //        RaycastHit hit;

            //        if (Physics.Raycast(castPos, Vector3.down, out hit, 1000f))
            //        {
            //            castPos = hit.point;
            //        }

            //        castPos.y += TileUIOffset;

            //        Gizmos.DrawWireCube(castPos, new Vector3(GridSize, 0f, GridSize));
            //    }
            //}


            //Vector3 lineStart = origin;
            //Vector3 lineEnd = origin;

            //for (int i = 0; i <= Columns; i++)
            //{
            //    lineStart = origin;
            //    lineStart.z -= GridSize * i;
            //    lineEnd = origin;
            //    lineEnd.z -= GridSize * i;
            //    lineEnd.x += Rows * GridSize;

            //    Gizmos.DrawLine(lineStart, lineEnd);
            //}

            //for (int i = 0; i <= Rows; i++)
            //{
            //    lineStart = origin;
            //    lineStart.x += GridSize * i;
            //    lineEnd = origin;
            //    lineEnd.x += GridSize * i;
            //    lineEnd.z -= Columns * GridSize;

            //    Gizmos.DrawLine(lineStart, lineEnd);
            //}
        }
    }
}
