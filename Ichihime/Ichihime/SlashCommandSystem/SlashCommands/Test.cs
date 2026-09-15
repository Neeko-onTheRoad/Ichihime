using Ichihime.Localizing;
using MahJongAutoCalculator;
using NetCord.Services.ApplicationCommands;
namespace Ichihime.SlashCommand;

public class TestCommand(
	StringTables stringTables,
	Properties properties,
	YakuId yakuId
) : SlashCommand(stringTables, properties) {

	[SlashCommand("api_test", "Description")]
	public string apiTest(
		string cryHand = "",
		string hand = "",
		string dora = "",
		string last = ""
	) {
		var calcer = new Calculator();
		var a = calcer.Calc(
			new(
				true,
				WindDirection.East,
				WindDirection.East,
				0,
				true,
				true,
				false,
				false,
				false,
				true,
				true,
				false,
				false
			),
			Card.Parse(cryHand),
			Card.Parse(hand),
			Card.Parse(dora),
			[],
			Card.Parse(last).First(),
			out _
		);
		return string.Join('\n', a.Applied.Select(han => $"{yakuId.GetYakuName(han.Id, StringTableOfGuildLocale)} - {han.Han}"));
	}
}