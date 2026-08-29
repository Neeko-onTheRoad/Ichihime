using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace Ichihime;

public class SpreadsheetClient {

	//======================================================================| Fields

	private readonly SheetsService _service;

	//======================================================================| Constructors

	public SpreadsheetClient(string credentialPath) {
	
		var credential = CredentialFactory
			.FromFile<ServiceAccountCredential>(credentialPath)
			.ToGoogleCredential()
			.CreateScoped(SheetsService.Scope.Spreadsheets);

		_service = new(new BaseClientService.Initializer {
			HttpClientInitializer = credential,
			ApplicationName = "Ichihime-GoogleSpreadSheet"
		});
	
	}

	//======================================================================| Methods

	public IList<IList<object>> Read(string spreadsheetId, string range) {
		
		var request = _service.Spreadsheets.Values.Get(spreadsheetId, range);
		var response = request.Execute();

		return response.Values ?? [];

	}

	public async Task<IList<IList<object>>> ReadAsync(string spreadsheetId, string range) {

		var request = _service.Spreadsheets.Values.Get(spreadsheetId, range);
		var response = await request.ExecuteAsync();

		return response.Values ?? [];

	}

	public void Write(string spreadsheetId, string range, IList<IList<object>> values) {

		var body = new ValueRange {
			Values = values
		};

		var request = _service.Spreadsheets.Values.Update(body, spreadsheetId, range);

		request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest
			.ValueInputOptionEnum.USERENTERED;

		request.Execute();

	}

	public async Task WriteAsync(string spreadsheetId, string range, IList<IList<object>> values) {
	
		var body = new ValueRange {
			Values = values
		};

		var request = _service.Spreadsheets.Values.Update(body, spreadsheetId, range);

		request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest
			.ValueInputOptionEnum.USERENTERED;

		await request.ExecuteAsync();

	}

}