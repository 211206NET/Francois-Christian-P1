namespace UI;

public class HomePage : IMenu
{
    private IBL _bl;
    

    public HomePage(IBL bl)
    { 
        _bl = bl;
    }

    public void Start()
    {            
        bool loginMenuLoop = false;
        while(!loginMenuLoop)
        {
            Console.WriteLine("Welcome to PaintLocker\nThe #1 spot for replica paintings");
            Console.WriteLine("1. Log in\n2. Create account\n3. Close");
            String? loginPick = Console.ReadLine();  
            if (!String.IsNullOrWhiteSpace(loginPick))
            {       
                switch(loginPick)
                {
                    case "1":                                        
                        MenuFactory.GetMenu("customer").Start();                                                               
                    break;
                    case "2":
                        MenuFactory.GetMenu("create").Start();
                    break;
                    case "3":
                        loginMenuLoop = true;
                    break;
                    case "1738":                                         
                        MenuFactory.GetMenu("admin").Start();
                    break;
                    default:
                    break;
                }
            }
            else
            {
                {
                    Console.WriteLine("Please enter valid input");
                }
            }
        }
    }
}