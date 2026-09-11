using Ichihime.ResourceSystem;
using Microsoft.Extensions.DependencyInjection;

namespace Ichihime;

public static class Program {

	public static async Task Main() {

		IchihimeBot ichihime = new() {
			AttacheDI = service => service
				.AddSingleton<IHaiPictureProvider>(
					new HaiPictureSvgFileProvider(Path.Combine("Resources", "HaiImageSvg"))
				)
		};

		await ichihime.Start();
		await ichihime.WaitForShutdown();

	}

}