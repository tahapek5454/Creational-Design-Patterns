

var sql = DataBase.GetInstance("sql");
var oracle = DataBase.GetInstance("oracle");
var mongo = DataBase.GetInstance("mongo");

var sql2 = DataBase.GetInstance("sql");
var oracle2 = DataBase.GetInstance("oracle");
var mongo2 = DataBase.GetInstance("mongo");

class DataBase
{
	private DataBase()
	{
		Console.WriteLine($"{nameof(DataBase)} has been created.");
	}

	// dictionary olarak tutma yapacagiz
	private static Dictionary<string, DataBase> _dataBases = new();

	public static DataBase GetInstance(string key)
	{
		if(!_dataBases.ContainsKey(key))
			_dataBases[key] = new DataBase();

		return _dataBases[key];
	}
}