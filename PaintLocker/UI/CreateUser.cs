namespace UI;

public class CreateUser : IMenu
{
    private IBL _bl;

    public CreateUser(IBL bl)
    {
        _bl = bl;
    }

    public void Start()
    {
        bool exit = false;
        do
        {
            Console.WriteLine("Create account screen");
            CreateUser: 
            Console.WriteLine("1. Create account\n2. Return to HomePage");
            switch(Console.ReadLine())
            {
                case "1":                                                     
                    Console.Write("Create Username: ");
                    String? createUsername = Console.ReadLine();                     
                    Console.Write("Create Password: ");
                    String? createPassword = Console.ReadLine();    
                    try
                    {                                             
                    Customer newCustomer = new Customer
                    {                                
                        Username = createUsername,
                        Password = createPassword
                    };
                    _bl.AddCustomer(newCustomer);
                    Console.WriteLine("Your account has been successfully created");
                    }
                    catch (InputInvalidException ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto CreateUser;
                    }                 
                break;
                case "2":
                exit = true;
                break;
                default:
                break;
            }
        }
        while(!exit);      
    }
}