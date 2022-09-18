dotnet build --configuration Release
dotnet pack --configuration Release

dotnet nuget push "AccessibleAI.Bots.Tables\bin\Release\AccessibleAI.Bots.Tables.0.0.7-dev.nupkg" --source "github"
dotnet nuget push "AccessibleAI.Bots.Blobs\bin\Release\AccessibleAI.Bots.Blobs.0.0.7-dev.nupkg" --source "github"
dotnet nuget push "AccessibleAI.Bots.CluHelpers\bin\Release\AccessibleAI.Bots.CluHelpers.0.0.7-dev.nupkg" --source "github"