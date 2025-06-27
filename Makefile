.PHONY: build test run

build:
	@ dotnet build
test:
	@ dotnet test --logger quackers
run:
	@ dotnet run --project src/Demo.App
