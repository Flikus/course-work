class Program 
{	
	static void AddComand(FabricCommand terminal, PlayerService adminPlayer, GameService adminGame, RegisteredAccountService adminRegisteredAccount)
	{
		terminal.AddCommand(new CommandCreateAccount(adminPlayer));
		terminal.AddCommand(new CommandCreateGame(adminGame));

		terminal.AddCommand(new CommandImagePlayer(adminPlayer));
		terminal.AddCommand(new CommandImageAllPlayer(adminPlayer));
		terminal.AddCommand(new CommandImagePlayerGame(adminPlayer));
		terminal.AddCommand(new CommandImageAllGame(adminGame));

		terminal.AddCommand(new CommandLoginPlayer(adminPlayer, adminRegisteredAccount));
		terminal.AddCommand(new CommandLogoutPlayer(adminPlayer, adminRegisteredAccount));
		terminal.AddCommand(new CommandMyStat(adminPlayer, adminRegisteredAccount));		
		terminal.AddCommand(new CommandPlayGame(adminPlayer, adminGame, adminRegisteredAccount));
		terminal.AddCommand(new CommandUpdateUserName(adminPlayer, adminRegisteredAccount));
		terminal.AddCommand(new CommandUpdateUserPassword(adminPlayer, adminRegisteredAccount));

		terminal.AddCommand(new CommandDeleteAccount(adminPlayer, adminRegisteredAccount));
		terminal.AddCommand(new CommandDeleteGame(adminGame));


	}

	static int Main() {
    	DbContext dbContext = new DbContext();
		RegisteredAccount registeredAccount = new RegisteredAccount();

		PlayerService adminPlayer = new PlayerService(dbContext);
		GameService	  adminGame  = new GameService(dbContext);
		RegisteredAccountService adminRegisteredAccount = new RegisteredAccountService(registeredAccount);

		FabricCommand terminal = new FabricCommand();		

		AddComand(terminal, adminPlayer, adminGame, adminRegisteredAccount);

		Console.Clear();
		
		adminPlayer.CreateAccont("zxc", "zxc", "Pay");
		adminPlayer.CreateAccont("asd", "zxc", "Pay");

		adminGame.CreateGame("Standart", 90);



		do{
			Console.Write("\n\nВведіть команду: ");

		} while(terminal.Command(Console.ReadLine()));

		return 0;
	}
}

