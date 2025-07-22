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
    public void MoveLeft()
    {
           // Get the current cell's valid directions
        bool[] directions = _mazeMap[(_currX, _currY)];

        // Index 0 = Left
        if (!directions[0])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        // Update the position to move left
        _currX--;
    }
    

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
       public void MoveRight()
    {
        // Get the current cell's valid directions
        bool[] directions = _mazeMap[(_currX, _currY)];

        // Index 1 = Right
        if (!directions[1])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        // Update the position to move right
        _currX++;
    }


    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
           // Get the current cell's valid directions
        bool[] directions = _mazeMap[(_currX, _currY)];

        // Index 2 = Up
        if (!directions[2])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        // Update the position to move up
        _currY--;
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
       // Get the current cell's valid directions
        bool[] directions = _mazeMap[(_currX, _currY)];

        // Index 3 = Down
        if (!directions[3])
        {
            throw new InvalidOperationException("cant go that way!");
        }

        // Update the position to move down
        _currY++;
    }
   /// Returns the current position inside the maze.
    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}