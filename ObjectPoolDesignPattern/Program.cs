


using System.Collections.Concurrent;




ObjectPool<X> pool = ObjectPool<X>.GetInstance;
var x1 = pool.Get(()=> new X());

pool.Return(x1);

var x2 = pool.Get(() => new X());
pool.Return(x2);

class ObjectPool<T>
	where T : class
{
	// genelde bu koleksiyon kullanılır pool islemlerinde
	readonly ConcurrentBag<T> _instances;

	private ObjectPool()
	{
		_instances= new ConcurrentBag<T>();
	}

	static ObjectPool<T> _objectPool;
	static ObjectPool()
		=> _objectPool = new ObjectPool<T>();

	public static ObjectPool<T> GetInstance { get => _objectPool; }
		

	public T Get(Func<T>? objectGenerator = null)
	{
		// Havuzdan generic parametrede bildirilen tudeki nesneyi geri donderir

		return _instances.TryTake(out T instance) ? instance : objectGenerator();
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