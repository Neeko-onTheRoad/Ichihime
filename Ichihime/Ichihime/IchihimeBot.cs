using Microsoft.Extensions.Hosting;
using NetCord.Hosting.Gateway;

namespace Ichihime;

public class IchihimeBot {

	//======================================================================| Fields

	private readonly HostApplicationBuilder _builder;
	private readonly IHost _host;

	//======================================================================| Constructors

	public IchihimeBot() {

		_builder = Host.CreateApplicationBuilder();
		_builder.Services.AddDiscordGateway();

		_host = _builder.Build();

	}

	//======================================================================| Methods

	public void Initialize() {
		
	}

	public async Task Run() {
		await _host.RunAsync();
	}

}