using UI;
//For Serilog
Log.Logger = new LoggerConfiguration()
.WriteTo.File(@"..\DL\customerLog.txt")
.CreateLogger();
MenuFactory.GetMenu("home").Start();