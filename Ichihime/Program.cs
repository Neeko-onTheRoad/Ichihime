using Ichihime.ResourceSystem;
using Microsoft.Extensions.DependencyInjection;

namespace Ichihime;

public static class Program {

	public static async Task Main() {

		IchihimeBot ichihime = new();

		await ichihime.Start();
		await ichihime.WaitForShutdown();

	}

}