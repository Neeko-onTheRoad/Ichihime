using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCord.Hosting.Gateway;
using NetCord.Hosting.Services;
using NetCord.Hosting.Services.ApplicationCommands;
using System.Diagnostics.CodeAnalysis;

namespace Ichihime;

public class IchihimeBot {

	//======================================================================| Fields

	private IHost _host;

	private SpreadsheetClient _spreadsheetClient;
	private StringTables _stringTables;

	//======================================================================| Constructors

	public IchihimeBot() {
		Initialize();
	}

	//======================================================================| Methods

	[MemberNotNull(nameof(_host))]
	[MemberNotNull(nameof(_spreadsheetClient))]
	[MemberNotNull(nameof(_stringTables))]
	public void Initialize() {

		var builder = Host.CreateApplicationBuilder();

		_spreadsheetClient = new("./credential.json");
		_stringTables = new(_spreadsheetClient);

		builder.Services
			.AddSingleton(_ => _stringTables)
			.AddDiscordGateway()
			.AddApplicationCommands();

		_host = builder.Build();

		_host.AddModules(typeof(Program).Assembly);

	}

	public async Task Run() {
		await _host.RunAsync();
	}

}