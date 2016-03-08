using System;

using UnityEngine;

namespace Rebellion.Game
{
    public class RebellionGridManager : MonoBehaviour
    {
        public int GridSize = 100;
        public int Rows = 6;
        public int Columns = 6;

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
