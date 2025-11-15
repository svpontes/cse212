public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }
    private const int LEFT_INDEX = 0;
    private const int RIGHT_INDEX = 1;
    private const int UP_INDEX = 2;
    private const int DOWN_INDEX = 3;
    private const string WALL_MESSAGE = "Can't go that way!";

    //check location boudary 
    private void moving_X_Y(int wallIndex, int currentLocalX, int currentLocalY)
    {
        
        var walls = _mazeMap[(_currX, _currY)];

        
        if (walls[wallIndex])
        {
            int newLocalX = _currX + currentLocalX;
            int newLocalY = _currY + currentLocalY;

           
            if (_mazeMap.ContainsKey((newLocalX, newLocalY)))
            {
                
                _currX = newLocalX;
                _currY = newLocalY;
            }
            else
            {
                
                throw new InvalidOperationException(WALL_MESSAGE);
            }
        }
        else
        {
            
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