namespace Ichihime;

public static class Program {

	public async static Task Main() {

		IchihimeBot ichihime = new();
		await ichihime.Run();

	}

}