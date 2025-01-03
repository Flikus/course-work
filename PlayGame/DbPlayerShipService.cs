class DbPlayerShipService {
    DbPlayerShipRepository PlayerRepository;

    public DbPlayerShipService(DbPlayerShipRepository PlayerRepositoryObj) {
        PlayerRepository = PlayerRepositoryObj;
    }

    public void ClearMap()
    {
       for(int i = 0; i < PlayerRepository.GetMapPlayer().Count(); i++)
            for(int j = 0; j < PlayerRepository.GetMapPlayer()[i].Count(); j++)
               PlayerRepository.GetMapPlayer()[i][j] = PlayerRepository.Getmap()[i][j];
    }

    public void ClearUnreachableCellsPlayer()
    {
        PlayerRepository.ClearUnreachableCellsPlayer();
    }

    public void PrintStringPlayerMap(int ind)
    {
        if(ind >= 0 && ind <= PlayerRepository.GetMapPlayer().Count()) {
            for(int j = 0; j < PlayerRepository.GetMapPlayer()[ind].Count(); j++)
                Console.Write(PlayerRepository.GetMapPlayer()[ind][j] + " ");             
        }
    }

    public void PrintPlayerMap()
    {
        for(int i = 0; i < PlayerRepository.GetMapPlayer().Count(); i++){
            for(int j = 0; j < PlayerRepository.GetMapPlayer()[i].Count(); j++){
                Console.Write(PlayerRepository.GetMapPlayer()[i][j] + " ");
            }
            Console.WriteLine();            
        }
    }


    public bool ChekUnreachableCells(List<List<char>> ShipPlayer)
    {
        for(int i = 0; i < ShipPlayer.Count(); i++){ 
            List<char> chek = new List<char> (ShipPlayer[i]);

            for(int j = 0; j < PlayerRepository.GetUnreachableCellsPlayer().Count(); j++){
                if(chek[0] == PlayerRepository.GetUnreachableCellsPlayer()[j][0] && chek[1] == PlayerRepository.GetUnreachableCellsPlayer()[j][1])
                return true;                
            }
        }

        return false;
    }

    public int GetPlayerMapCountY()
    {
        return PlayerRepository.GetPlayerMapCountY();
    }

    public List<List<List<char>>> GetShipCoordPlayer() {
        return PlayerRepository.GetShipCoordPlayer();
    }

    public void UnreachableCells(List<List<char>> ShipPlayer)
    {
        List<int> Border = BorderOfSunkShip(ShipPlayer);

        for(int i = Border[2]; i <= Border[3]; i++) {  
            for(int j = Border[0]; j <= Border[1]; j++) {
                List<char> row = [(char)(j + 'a'), (char)(i + '0')];
                if(PlayerRepository.GetUnreachableCellsPlayer().FindIndex(list => list.SequenceEqual(row)) == -1)
                    PlayerRepository.GetUnreachableCellsPlayer().Add(row);                             
            }                 
        }
    } 
    
    public List<int> BorderOfSunkShip(List<List<char>> ShipPlayer)
    {
 
        int xMin;
        int xMax;
        int yMin;
        int yMax;

        if(ShipPlayer[0][0] - 'a' - 1 < 0)
            xMin = ShipPlayer[0][0] - 'a';
        else
            xMin = ShipPlayer[0][0] - 'a' - 1;

        if(ShipPlayer[ShipPlayer.Count() - 1][0] - 'a'  + 1 > 9) 
            xMax =  ShipPlayer[ShipPlayer.Count() - 1][0] - 'a';
        else
            xMax =  ShipPlayer[ShipPlayer.Count() - 1][0] - 'a' + 1;


        if(ShipPlayer[0][1] - '0' - 1 < 0)
            yMin = ShipPlayer[0][1] - '0';
        else
            yMin = ShipPlayer[0][1] - '0' - 1;

        if(ShipPlayer[ShipPlayer.Count() - 1][1] - '0' + 1 > 9) 
            yMax = ShipPlayer[ShipPlayer.Count() - 1][1] - '0';
        else
            yMax = ShipPlayer[ShipPlayer.Count() - 1][1] - '0' + 1;  

        return new List<int> { xMin, xMax, yMin, yMax };    
    }

    public List<List<char>> GetUnreachableCellsPlayer()
    {
        return PlayerRepository.GetUnreachableCellsPlayer();
    }

       public void AddMissedShipPlayerMap(List<char> coord)
    {
        PlayerRepository.GetMapPlayer()[coord[1] - '0' + 1][coord[0] - 'a' + 1] = 'x';          
    }


    public void AddPaddedShipPlayerMap(List<char> coord)
    {
        PlayerRepository.GetMapPlayer()[coord[1] - '0' + 1][coord[0] - 'a' + 1] = 'u';          
    }


    public void AddPlayerMap(List<List<char>> shipCoord)
    {
        for(int i = 0; i < shipCoord.Count(); i++) 
            PlayerRepository.GetMapPlayer()[shipCoord[i][1] - '0' + 1][shipCoord[i][0] - 'a' + 1] = 'O';              
    }
}