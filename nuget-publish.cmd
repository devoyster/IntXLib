@cd IntXLib
..\.nuget\nuget.exe pack IntXLib.csproj -Prop Configuration=Release
..\.nuget\nuget.exe push IntX.1.0.0.0.nupkg -ApiKey
@pause
