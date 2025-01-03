class DbPlayerShipRepository 
{
    DbPlayerShip Player;
    public DbPlayerShipRepository(DbPlayerShip player)
    {
        Player = player;
    }
    
    public int GetPlayerMapCountY()
    {
        return Player.MapPlayer.Count();
    }

    public List<List<List<char>>> GetShipCoordPlayer()
    {
        return Player.shipCoordPlayer;
    }


    public List<List<char>> GetUnreachableCellsPlayer()
    {
        return Player.UnreachableCellsPlayer;
    }


    public List<List<char>> GetMapPlayer()
    {
        return Player.MapPlayer;
    }

    public List<List<char>> Getmap()
    {
        return Player.map;
    }




    public void ClearUnreachableCellsPlayer()
    {
        Player.UnreachableCellsPlayer = new List<List<char>>();
    }


    public bool ChekUnreachableCells(List<List<char>> ShipPlayer)
    {
        for(int i = 0; i < ShipPlayer.Count(); i++){ 
            List<char> chek = new List<char> (ShipPlayer[i]);

            for(int j = 0; j < Player.UnreachableCellsPlayer.Count(); j++){
                if(chek[0] == Player.UnreachableCellsPlayer[j][0] && chek[1] == Player.UnreachableCellsPlayer[j][1])
                return true;                
            }
        }

        return false;
    }
}