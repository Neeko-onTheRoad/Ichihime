namespace Ichihime;

public static class Program {

	public async static Task Main() {

		IchihimeBot ichihime = new();
		ichihime.Initialize();

		await ichihime.Run();

	}

}