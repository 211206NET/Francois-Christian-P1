namespace UI;

public static class MenuFactory
{
    public static IMenu GetMenu(String menuString)
    {
        String connectionString = File.ReadAllText("connectionString.txt");
        IRepo repo = new DBRepo(connectionString);
        IBL bl = new RRBL(repo); 
        menuString = menuString.ToLower();
        

        switch(menuString)
        {
            //Since we are return we dont use a break on case
            case "home":
            return new HomePage(bl);

            case "create":
            return new CreateUser(bl);

            case "customer":
            return new CustomerMenu(bl);

            case "admin":
            return new AdminMenu(bl);

            default:
            return new HomePage(bl);
        }
    }
    
}