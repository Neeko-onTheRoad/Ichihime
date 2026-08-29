//using NetCord.Services.ApplicationCommands;

//namespace Ichihime;

//public class StringTableLocalizeProvider(StringTables stringTables) : ILocalizationsProvider {

//	//======================================================================| Fields

//	private readonly StringTables _stringTables = stringTables;

//	//======================================================================| Methods

//	public ValueTask<IReadOnlyDictionary<string, string>?> GetLocalizationsAsync(
//		IReadOnlyList<LocalizationPathSegment> path,
//		CancellationToken cancellationToken = default
//	) {

//		if (path is { Count: < 2 } or [not ApplicationCommandLocalizationPathSegment, ..])
//			return ValueTask.FromResult<IReadOnlyDictionary<string, string>?>(null);

//		IReadOnlyDictionary<string, string>? result = path[^1] switch {



//		}

//	}

//}