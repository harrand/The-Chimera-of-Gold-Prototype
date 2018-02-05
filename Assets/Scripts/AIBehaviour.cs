﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chimera
{
    public class AIBehaviour : MonoBehaviour
    {
        public Vector3 target;
        public Vector3 origin;
        public int restMove;
        public bool meetObsracle = false;
        int horizontalMoves = 0;
        int verticalMoves = 0;
        bool upLock = false;
        bool downLock = false;

        public int Movement(int index, int moves)
        {
            //go to (x, y, z)
            for (int i = moves; i > 0; i--)
            {
                /*if (ObstacleManager.CheckObstacleTile((int)transform.position.x, (int)transform.position.y + 1) && restMove != 1)
                {
                    meetObsracle = true;
                }*/

                if (tileCheck((int)Mathf.Round(transform.position.x), (int)Mathf.Round(transform.position.y) + 1) && (!ObstacleManager.CheckObstacleTile((int)transform.position.x, (int)transform.position.y + 1) || (ObstacleManager.CheckObstacleTile((int)transform.position.x, (int)transform.position.y + 1) && restMove == 1)))
                {
                    target.y = Mathf.Round(transform.position.y) + 1;
                    target.x = Mathf.Round(transform.position.x);
                    transform.position = target;
                    verticalMoves++;
                    //Once the player goes up a floor, vertical moves now keep track of total moves made. 
                    //Allows changing direction on the new floor without messing up how many squares you moved on the previous floor
                    verticalMoves += Mathf.Abs(horizontalMoves);
                    horizontalMoves = 0;
                    continue;
                }
                else if (tileCheck((int)Mathf.Round(transform.position.x) - 1, (int)Mathf.Round(transform.position.y)) && (!ObstacleManager.CheckObstacleTile((int)transform.position.x - 1, (int)transform.position.y) || (ObstacleManager.CheckObstacleTile((int)transform.position.x - 1, (int)transform.position.y) && restMove == 1)))
                {
                    target.x = Mathf.Round(transform.position.x) - 1;
                    target.y = Mathf.Round(transform.position.y);
                    transform.position = target;
                    horizontalMoves--;
                    continue;
                }
                else if (tileCheck((int)Mathf.Round(transform.position.x) + 1, (int)Mathf.Round(transform.position.y)) && (!ObstacleManager.CheckObstacleTile((int)transform.position.x + 1, (int)transform.position.y) || (ObstacleManager.CheckObstacleTile((int)transform.position.x + 1, (int)transform.position.y) && restMove == 1)))
                {
                    target.x = Mathf.Round(transform.position.x) + 1;
                    target.y = Mathf.Round(transform.position.y);
                    transform.position = target;
                    horizontalMoves++;
                    continue;
                }
                //target = transform.position;
                //return ((Mathf.Abs(horizontalMoves)) + (Mathf.Abs(verticalMoves)));
            }
            return moves;
        }

        public void resetMoves()
        {
            horizontalMoves = 0;
            verticalMoves = 0;
            upLock = false;
            downLock = false;
            meetObsracle = false;
        }

        bool tileCheck(int x, int y)
        {
            if (y == -1 || x == -1 || y == 19 || x == 21)
            {
                return false;
            }
            if (y == 0)
            {
                return true;
            }
            else if (y == 1)
            {
                if (x == 0 || x == 4 || x == 8 || x == 12 || x == 16 || x == 20)
                    return true;
                else
                    return false;
            }
            else if (y == 2)
            {
                return true;
            }
            else if (y == 3 || y == 4)
            {
                if (x == 2 || x == 6 || x == 10 || x == 14 || x == 18)
                    return true;
                else
                    return false;
            }
            else if (y == 5)
            {
                if (x >= 2 && x <= 18)
                    return true;
                else
                    return false;
            }
            else if (y == 6)
            {
                if (x == 4 || x == 8 || x == 12 || x == 16)
                    return true;
                else
                    return false;
            }
            else if (y == 7)
            {
                if (x >= 4 && x <= 16)
                    return true;
                else
                    return false;
            }
            else if (y == 8 || y == 9)
            {
                if (x == 6 || x == 14)
                    return true;
                else
                    return false;
            }
            else if (y == 10)
            {
                if (x >= 6 && x <= 14)
                    return true;
                else
                    return false;
            }
            else if (y == 11)
            {
                if (x == 8 || x == 12)
                    return true;
                else
                    return false;
            }
            else if (y == 12)
            {
                if (x >= 8 && x <= 12)
                    return true;
                else
                    return false;
            }
            else if (y == 13)
            {
                if (x == 10)
                    return true;
                else
                    return false;
            }
            else if (y == 14)
            {
                if (x >= 4 && x <= 16)
                    return true;
                else
                    return false;
            }
            else if (y == 15 || y == 16 || y == 17)
            {
                if (x == 4 || x == 16)
                    return true;
                else
                    return false;
            }
            else if (y == 18)
            {
                if (x >= 4 && x <= 16)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

    }
}