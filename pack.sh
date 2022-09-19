dotnet build --configuration Release
dotnet pack --configuration Release

dotnet nuget push "AccessibleAI.Bots.Tables\bin\Release\AccessibleAI.Bots.Tables.0.0.8-dev.nupkg" --source "github"
dotnet nuget push "AccessibleAI.Bots.Blobs\bin\Release\AccessibleAI.Bots.Blobs.0.0.8-dev.nupkg" --source "github"
dotnet nuget push "AccessibleAI.Bots.LanguageUnderstanding\bin\Release\AccessibleAI.Bots.LanguageUnderstanding.0.0.8-dev.nupkg" --source "github"