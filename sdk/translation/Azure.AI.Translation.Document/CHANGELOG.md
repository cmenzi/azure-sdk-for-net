# Release History

## 1.0.0-beta.6 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.5 (2021-09-08)

### Breaking Changes
- `DocumentFilter.CreatedAfter` and `DocumentFilter.CreatedBefore` are now nullable properties.
- Renamed method `GetAllTranslationStatuses` to `GetTranslationStasuses`.
- Renamed method `GetAllDocumentStatuses` to `GetDocumentStasuses`.
- Renamed type `TranslationFilter` to `GetTranslationStatusesOptions`.
- Renamed type `DocumentFilter` to `GetDocumentStatusesOptions`.
- Renamed type `DocumentStatus` to `DocumentStatusResult`.
- Renamed type `TranslationStatus` to `TranslationStatusResult`.
- Renamed type `FileFormat` to `DocumentTranslationFileFormat`.
- Renamed property `TranslatedTo` to `TranslatedToLanguageCode` in `DocumentStatusResult`.
- Renamed parameter `asc` to `ascending` in `DocumentStatusResult` constructor.
- Changed spelling of `cancelled`/`cancelling` to `canceled`/`cancelling`. The following changes have been made:
  - property `DocumentsCancelled` to `DocumentsCanceled` in `DocumentTranslationOperation`
  - property `DocumentsCancelled` to `DocumentsCanceled` in `TranslationStatusResult`
  - value `Cancelled` to `Canceled` in `DocumentTranslationOperation`
  - value `Cancelling` to `Canceling` in `DocumentTranslationOperation`
  - parameter `Cancelled` to `Canceled` in function `DocumentTranslationModelFactory.TranslationStatus` 

### Bugs Fixed
- `GetDocumentStasus` and `GetDocumentStatusesAsync` no longer set CreatedAfter and CreatedBefore if the user doesn't set it.
- In `GetTranslationStasuses`, `GetDocumentStasuses` and their async counterparts; URL parameters for `Ids`, `Statuses`, and `OrderBy` are no longer included in the request URL if the user does not set them.

## 1.0.0-beta.4 (2021-08-10)

### Features Added
- Added filtering options to methods `GetAllTranslationStatuses`, `GetAllDocumentStatuses` and their async equivalent.
- Added `DocumentTranslationModelFactory` static class to support mocking model types. 

### Breaking Changes
- Properties `Suffix` and `Prefix` are now available under `TranslationSource` instead of in type `DocumentFilter`.
- Type `DocumentTranslationError` is now a struct.
- Type `StorageInputType` is now a regular enum instead of an extensible enum.

## 1.0.0-beta.3 (2021-07-07)
### Breaking changes

- Renamed property `DocumentId` to `Id`in `DocumentStatusResult`.
- Renamed property `TranslationId` to `Id`in `TranslationStatusResult`
- Renamed type `TranslationStatusResult` to `TranslationStatus`.
- Renamed type `DocumentStatusResult` to `DocumentStatus`.
- Renamed enum `TranslationStatus` to `DocumentTranslationStatus`.
- Renamed method `GetDocumentFormats` to `GetSupportedDocumentFormats`.
- Renamed method `GetGlossaryFormats` to `GetSupportedGlossaryFormats`.
- Removed property `HasCompleted` from types `DocumentStatusResult` and `TranslationStatusResult`.

## 1.0.0-beta.2 (2021-06-08)

### New Features

- Added support for authentication with Azure Active Directory.

### Breaking changes

- This version of the SDK defaults to the latest supported service version, which currently is `v1.0`.
- Renamed method `GetTranslations` to `GetAllTranslationStatuses` and same for the async equivalent method.
- Renamed property `TranslateTo` to `TranslatedTo` in type `DocumentStatusResult`.

## 1.0.0-beta.1 (2021-04-06)

This is the first beta package of the Azure.AI.Translation.Document client library that targets the service version `1.0-preview.1`.
This package's documentation and samples demonstrate the new API.
