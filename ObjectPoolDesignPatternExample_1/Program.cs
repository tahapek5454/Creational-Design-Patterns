


using System.Collections.Concurrent;
ObjectPool<X> pool = ObjectPool<X>.GetInstance;

var t1 = Task.Run(() =>
{
	while (true)
	{
		var x1 = pool.Get(() => new X());
		pool.Return(x1);


	}
});

var t2 = Task.Run(() =>
{
	var x2 = pool.Get(() => new X());
	pool.Return(x2);
});


await Task.WhenAll(t1, t2);

class ObjectPool<T>
	where T : class
{
	// genelde bu koleksiyon kullanılır pool islemlerinde
	readonly ConcurrentBag<T> _instances;
	readonly List<string> _types; 

	private ObjectPool()
	{
		_instances = new ConcurrentBag<T>();
		_types = new List<string>();
	}

	static ObjectPool<T> _objectPool;
	static ObjectPool()
		=> _objectPool = new ObjectPool<T>();

	public static ObjectPool<T> GetInstance { get => _objectPool; }

	public static Object _object = new Object();
	public T Get(Func<T>? objectGenerator = null)
	{
		// Havuzdan generic parametrede bildirilen tudeki nesneyi geri donderir

		lock (_object)
		{
			bool state = _instances.TryTake(out T instance);

			if (!state && !_types.Any(x => x == nameof(T)))
			{
				T generatedInstance = objectGenerator();
				_types.Add(nameof(T));
				return generatedInstance;
			}
			else
			{
				return instance;
			}
			 
		}

	}

	public void Return(T isntance)
	{
		// havuzdan alinan nesneyi geri iade eder
		_instances.Add(isntance);
	}
}

class X
{
	public int Count { get; set; }

	public void Write()
		=> Console.WriteLine(Count);

	public X()
	{
		Console.WriteLine("X üretim maliyeti");
	}

	~X()
	{
		Console.WriteLine("X imha maliyeti");
	}
}