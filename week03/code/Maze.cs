/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    /// 

    // Index constants for the boolean array: [left, right, up, down]
    private const int LEFT_INDEX = 0;
    private const int RIGHT_INDEX = 1;
    private const int UP_INDEX = 2;
    private const int DOWN_INDEX = 3;
    private const string WALL_MESSAGE = "Can't go that way!";

    //check location boudary 
    private void moving_X_Y(int wallIndex, int currentLocalX, int currentLocalY)
    {
        // 1. Get wall status for the current location.
        // Assumes current location exists, as per problem context.
        var walls = _mazeMap[(_currX, _currY)];

        // 2. Check the wall status for the intended direction.
        if (walls[wallIndex])
        {
            int newLocalX = _currX + currentLocalX;
            int newLocalY = _currY + currentLocalY;

            // 3. Boundary Check: Ensure the destination cell exists in the map.
            // This prevents KeyNotFoundException (e.g., trying to move to (2, 0)).
            if (_mazeMap.ContainsKey((newLocalX, newLocalY)))
            {
                // Destination is valid and mapped, update coordinates.
                _currX = newLocalX;
                _currY = newLocalY;
            }
            else
            {
                // Path was open, but hit the boundary/unmapped area.
                throw new InvalidOperationException(WALL_MESSAGE);
            }
        }
        else
        {
            // Hit an explicit wall (wall value is false).
            throw new InvalidOperationException(WALL_MESSAGE);
        }
    }
    public void MoveLeft()
    {
        {
            // coorednates: X-1, Y+0
            moving_X_Y(LEFT_INDEX, -1, 0);
        }
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // coorednates: X+1, Y+0
        moving_X_Y(RIGHT_INDEX, 1, 0);
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // coorednates: X+0, Y-1
        moving_X_Y(UP_INDEX, 0, -1);
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // coorednates: X+0, Y+1
        moving_X_Y(DOWN_INDEX, 0, 1);
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}