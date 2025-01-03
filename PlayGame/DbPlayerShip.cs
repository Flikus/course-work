class DbPlayerShip 
{
    public List<List<char>> map {get; }
    public List<List<char>> MapPlayer;    
    public List<List<List<char>>> shipCoordPlayer;    
    public List<List<char>> UnreachableCellsPlayer;

    public DbPlayerShip()
    {
        map = new List<List<char>> {
            new List<char> {' ', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J'},
            new List<char> {'0', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.'},
            new List<char> {'1', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.'},
            new List<char> {'2', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.'},
            new List<char> {'3', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.'},
            new List<char> {'4', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.'},
            new List<char> {'5', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.'},
            new List<char> {'6', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.'},
            new List<char> {'7', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.'},
            new List<char> {'8', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.'},
            new List<char> {'9', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.'}
        };

        MapPlayer = new List<List<char>>();

        for(int i = 0; i < map.Count(); i++){
            MapPlayer.Add(new List<char>());
            for(int j = 0; j < map[i].Count(); j++)
                MapPlayer[i].Add(map[i][j]);            
        }


        shipCoordPlayer = new List<List<List<char>>> ();        
        UnreachableCellsPlayer = new List<List<char>>();
    }
}