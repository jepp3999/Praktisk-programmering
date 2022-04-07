all: Out.txt
	cat $<

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs table.dll
	mcs -target:exe -out:$@ $< -reference:table.dll main.cs

table.dll: table.cs
	mcs -target:library -out:table.dll table.cs
clean:
	rm -f Out.txt main.exe
