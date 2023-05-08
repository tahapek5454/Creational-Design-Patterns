

DataBaseCreator dataBaseCreator = new DataBaseCreator();
DataBase dataBase = dataBaseCreator.CreateInstance(new OracleFactory());

Console.WriteLine(dataBase.Connection);



enum DataBaseType
{
    Oracle,
    MsSql,
    MySql,
    PostgreSql
}
class DataBase
{
    public DataBaseType Type { get; set; }
    public AbstractConnection Connection { get; set; }
    public AbstractCommand Command { get; set; }

    public DataBase(DataBaseType type, AbstractConnection connection, AbstractCommand command)
    {
        Type = type;
        Connection = connection;
        Command = command;
    }
    public DataBase()
    {

    }
}

enum ConnectionState
{
    Open, Close
}

//AbstractProduct
abstract class AbstractConnection
{
    public abstract string ConnectionString { get; set; }
    public abstract ConnectionState ConnectionState { get; set; }
    public abstract bool Connect();
    public abstract bool DisConnect();
}

//Concrete Product
class Connection: AbstractConnection
{
    private string _connectionString;
    public Connection(string connectionString)
    {
        _connectionString = connectionString;
    }

    public Connection()
    {

    }

    override public string ConnectionString { get => _connectionString; set =>_connectionString=value ; }
    override public ConnectionState ConnectionState { get; set; }
    override public bool Connect()
    {
        //process
        return true;
    }

    public override bool DisConnect()
    {
        //process
        return true;
    }
}


//Abstract Product
abstract class AbstractCommand
{
    public abstract void Execute(string query);
}

//Concrete Product
class Command: AbstractCommand
{
    override public void Execute(string query)
    {
        //execute
    } 
}


//Abstract Factory
abstract class AbstractDatabaseFactory
{
    public abstract AbstractConnection CreateConnection();
    public abstract AbstractCommand CreateCommand();
}

//Concrete Factory
class MsSqlFactory : AbstractDatabaseFactory
{
    public override AbstractCommand CreateCommand()
    {
        Command command = new Command();
        return command;
    }

    public override AbstractConnection CreateConnection()
    {
        Connection connection = new Connection();
        connection.ConnectionString = "MsSql";
        return connection;
    }
}

class OracleFactory : AbstractDatabaseFactory
{
    public override AbstractCommand CreateCommand()
    {
        Command command = new Command();
        return command;
    }

    public override AbstractConnection CreateConnection()
    {
        Connection connection = new Connection();
        connection.ConnectionString = "Oracle";
        return connection;
    }
}


//Creator
class DataBaseCreator
{
    AbstractConnection connection;
    AbstractCommand command;

    public DataBase CreateInstance(AbstractDatabaseFactory adf)
    {
        connection= adf.CreateConnection();
        command= adf.CreateCommand();


        return new()
        {
            Command = command,
            Connection = connection,
            @Type = (DataBaseType)Enum.Parse(typeof(DataBaseType), adf.GetType().Name.Replace("Factory", ""))
        };
    }

}