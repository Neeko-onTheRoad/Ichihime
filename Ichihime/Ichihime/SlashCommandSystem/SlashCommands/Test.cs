using System.Text;
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
	public string ApiTest(
		string cryHand = "",
		string hand = "",
		string dora = "",
		string last = ""
	) {
		var calcer = new Calculator();
		var info = new HandInfo(
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
		);
		var hands = Card.Parse(hand);
		var a = calcer.Calc(
			info,
			Card.Parse(cryHand),
			hands,
			Card.Parse(dora),
			[],
			Card.Parse(last).First(),
			out var form
		);
		var builder = new StringBuilder();
		if(form != null)
			builder.AppendLine(form.ToString());
		else {
			builder.Append("Hands: \n\t");
			builder.AppendJoin(",\n\t", hands);
			builder.AppendLine();
		}
		builder.AppendJoin('\n',
			a.Applied.Select(han => $"{yakuId.GetYakuName(han.Id, StringTableOfGuildLocale)} - {han.Han}"));
		var score = a.GetScore(info);
		builder.AppendLine();
		builder.AppendLine();
		
		if(a.IsYakuman)
			builder.AppendLine($"# {a.Han}배 역만");
		else
			builder.AppendLine($"{a.Han}판 {a.Fu}부");
		if(info.IsParent)
			builder.AppendLine($"ALL: {score.Child}");
		else
			builder.AppendLine($"오야: {score.Parent}, 자: {score.Child}");
		return builder.ToString();
	}
}