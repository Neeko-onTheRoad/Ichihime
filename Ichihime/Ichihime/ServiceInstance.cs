namespace Ichihime;

public abstract class ServiceInstance {

	public abstract Type Type { get; }
	public abstract object Instance { get; }

	public void Deconstruct(out Type type, out object instance) {
		type = Type;
		instance = Instance;
	}

}

public class ServiceInstance<TService>(TService instance) : ServiceInstance where TService : class {

	public override Type Type => typeof(TService);
	public override object Instance => instance;

}