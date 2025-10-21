.PHONY: install build test run

install:
	@(dotnet restore)
	@(cd src/Demo.Web ; npm i ; npm ci)
build:
	@(dotnet build)
test:
	@(dotnet test --logger quackers)
run:
	@echo "(1) backend"
	@echo "(2) frontend"
	@echo ""
	@read -p "Please select 1-2: " app ; \
	case $$app in \
		1) (dotnet run --project src/Demo.App) ;; \
		2) (cd src/Demo.Web && npm run -s dev) ;; \
		*) echo "Invalid option" ;; \
	esac
