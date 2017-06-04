using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

using Rebellion.Presentation;
using Rebellion.Data;
using Rebellion.Game;

namespace Rebellion.EditorStuff
{
    public class GridManagerEditor : Editor
    {
        [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Active)]
        public static void OnDrawGizmos(RebellionGridManager gridManager, GizmoType gizmoType)
        {
            Vector3 origin = gridManager.transform.position;
            Vector3 position = origin;
            int rows = gridManager.Rows;
            int columns = gridManager.Columns;
            int gridSize = gridManager.GridSize;

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    position = origin;
                    position.x += gridSize * 0.5f;
                    position.z -= gridSize * 0.5f;

                    position.x += row * gridSize;
                    position.z += column * -gridSize;

                    Vector3 castPos = position;

                    castPos.y += 100f;

                    RaycastHit hit;

                    if (Physics.Raycast(castPos, Vector3.down, out hit, 1000f))
                    {
                        castPos = hit.point;
                    }

                    castPos.y += gridManager.TileUIOffset;

                    Gizmos.DrawWireCube(castPos, new Vector3(gridSize, 0f, gridSize));
                    Handles.Label(castPos, row + " : " + column);
                }
            }
        }
    }
}
