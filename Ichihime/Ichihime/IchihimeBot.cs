using Ichihime.Localizing;
using Ichihime.ResourceSystem;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCord.Hosting.Gateway;
using NetCord.Hosting.Services;
using NetCord.Hosting.Services.ApplicationCommands;
using NetCord.Services.ApplicationCommands;
using System.Diagnostics.CodeAnalysis;

namespace Ichihime;

public class IchihimeBot {

	//======================================================================| Fields

	private IHost _host;
	private IHostApplicationLifetime _hostLifetime;

	private SpreadsheetClient _spreadsheetClient;
	private StringTables _stringTables;

	//======================================================================| Properties

	public Properties Properties { get; private set; }
	public bool IsRunning { get; private set; }

	public Action<IServiceCollection>? AttacheDI { get; set; }

	//======================================================================| Constructors

	public IchihimeBot() {
		Initialize();
	}

	//======================================================================| Methods

	[MemberNotNull(
		nameof(_host),
		nameof(_hostLifetime),
		nameof(_spreadsheetClient),
		nameof(_stringTables),
		nameof(Properties)
	)]
	public void Initialize() {

		var builder = Host.CreateApplicationBuilder();

		_spreadsheetClient = new("./credential.json");
		_stringTables = new(_spreadsheetClient);
		Properties = new(_spreadsheetClient);

		builder.Services
			.AddSingleton(_spreadsheetClient)
			.AddSingleton(_stringTables)
			.AddSingleton(Properties)
			.AddSingleton<IHaiPictureProvider>(
				new HaiPictureSvgFileProvider(Path.Combine("Resources", "HaiImageSvg"))
			)
			.AddDiscordGateway()
			.AddApplicationCommands(options => 
				options.LocalizationsProvider = new JsonLocalizationsProvider()
			);

		_host = builder.Build();
		_host.AddModules(typeof(Program).Assembly);
		_hostLifetime = _host.Services.GetRequiredService<IHostApplicationLifetime>();
		
		_hostLifetime.ApplicationStarted.Register(() => {
			IsRunning = true;
			Console.WriteLine("Application Started.");
		});

		_hostLifetime.ApplicationStopping.Register(() => 
			Console.WriteLine("Application Stopping...")
		);

		_hostLifetime.ApplicationStopped.Register(() => {
			IsRunning = false;
			Console.WriteLine("Application Stopped.");
		});

	}

	public async Task Start() {
		await _host.StartAsync();
	}

	public async Task Stop() {
		await _host.StopAsync();
		_host.Dispose();
	}

	public async Task WaitForShutdown() {
		await _host.WaitForShutdownAsync();
	}

}