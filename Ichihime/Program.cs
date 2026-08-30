namespace Ichihime;

public static class Program {

	private static readonly IchihimeBot _ichihime = new();

	public static async Task Main() {

		await _ichihime.Start();

		while (_ichihime.IsRunning) {

			if (!Console.KeyAvailable) {
				await Task.Delay(10);
				continue;
			}

			if (Console.ReadKey(true).Key != ConsoleKey.F5)
				continue;

			Console.Clear();
			Console.WriteLine("Restarting...");

			await _ichihime.Stop();
			_ichihime.Initialize();
			await _ichihime.Start();

			Console.WriteLine("Restarted.");

		}

		await _ichihime.Stop();

	}

}