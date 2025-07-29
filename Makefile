.PHONY: install build test run

install:
	@ \
	cd src/Demo.Web ; npm i ; cd ../.. ; \
	cd src/Demo.Web ; npm ci ; cd ../..
build:
	@ dotnet build
test:
	@ dotnet test --logger quackers
run:
	@ \
	echo "(1) backend" ; \
	echo "(2) frontend" ; \
	echo "" ; \
	echo "Please select 1-2: " ; \
	read app ; \
	if test $$app -eq "1" ; then \
		dotnet run --project src/Demo.App ; \
	fi ; \
	if test $$app -eq "2" ; then \
		cd src/Demo.Web ; npm run -s dev ; cd ../.. ; \
	fi
