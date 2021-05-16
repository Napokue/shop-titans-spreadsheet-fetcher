# Table of Contents
- [Table of Contents](#table-of-contents)
- [Shop-titans-spreadsheet-fetcher](#shop-titans-spreadsheet-fetcher)
- [Usage](#usage)
- [Packages](#packages)
- [Acquiring Google Credential JSON](#acquiring-google-credential-json)

# Shop-titans-spreadsheet-fetcher
Data fetcher from the Shop Titans spreadsheet. Goal of this project is to provide an API via full typed models to easily work with data from the spreadsheet.

The ultimate goal is to be a building block for other applications that want to consume this data.

# Usage
Below an example how to use the library. Be aware, a credential json from Google is needed in order to have access to the Google Sheets API, see [Acquiring Google Credential JSON](#acquiring-google-credential-json).

```csharp
using System.IO;
using System.Linq;
using SheetModels.Blueprints;
using SheetServices;

var credentialFile = new FileInfo("path-to-credential-json");
var googleSheetsService = new GoogleSheetsService(credentialFile);            
var spreadsheetFetcher = new SpreadsheetFetcher(googleSheetsService);

var bluePrints = spreadsheetFetcher.FetchBluePrints().ToList();

// Can be exported to JSON
var bluePrintsToJson = bluePrints.Select(blueprint => blueprint.ToJson()).ToList();

// Can be imported from JSON
var bluePrintsFromJson = bluePrintsToJson.Select(Blueprint.FromJson).ToList();
```

# Packages
This project is split into multiple packages. Each package has its own responsibility.

| Package                                                                                                                              | Description                                  | NuGet                                                                                                                                                                                                                                                                                                                   |
| ------------------------------------------------------------------------------------------------------------------------------------ | -------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [ShopTitansSpreadsheetFetcher.SheetModels](https://github.com/Napokue/shop-titans-spreadsheet-fetcher/tree/main/src/SheetModels)     | Data models of the sheets.                   | [![Nuget](https://img.shields.io/nuget/v/ShopTitansSpreadsheetFetcher.SheetModels?label=%20&logo=nuget&style=flat-square)![Nuget](https://img.shields.io/nuget/dt/ShopTitansSpreadsheetFetcher.SheetModels?label=%20&style=flat-square)](https://www.nuget.org/packages/ShopTitansSpreadsheetFetcher.SheetModels)       |
| [ShopTitansSpreadsheetFetcher.SheetRanges](https://github.com/Napokue/shop-titans-spreadsheet-fetcher/tree/main/src/SheetRanges)     | Ranges that are used to excract models from. | [![Nuget](https://img.shields.io/nuget/v/ShopTitansSpreadsheetFetcher.SheetRanges?label=%20&logo=nuget&style=flat-square)![Nuget](https://img.shields.io/nuget/dt/ShopTitansSpreadsheetFetcher.SheetRanges?label=%20&style=flat-square)](https://www.nuget.org/packages/ShopTitansSpreadsheetFetcher.SheetRanges)       |
| [ShopTitansSpreadsheetFetcher.SheetServices](https://github.com/Napokue/shop-titans-spreadsheet-fetcher/tree/main/src/SheetServices) | Services used to fetch the sheets.           | [![Nuget](https://img.shields.io/nuget/v/ShopTitansSpreadsheetFetcher.SheetServices?label=%20&logo=nuget&style=flat-square)![Nuget](https://img.shields.io/nuget/dt/ShopTitansSpreadsheetFetcher.SheetServices?label=%20&style=flat-square)](https://www.nuget.org/packages/ShopTitansSpreadsheetFetcher.SheetServices) |

# Acquiring Google Credential JSON
The GoogleSheetsService requires a credential JSON, acquired from Google's API Key service. Please refer to Google its [excelent guide](https://developers.google.com/sheets/api/quickstart/dotnet) on how to work with this.






