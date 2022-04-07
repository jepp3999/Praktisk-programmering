all: Out.txt
	cat $<

Out.txt: main.exe
	mono $< < input.txt > $@

main.exe: main.cs genlist.dll
	mcs -target:exe -out:$@  -reference:genlist.dll main.cs

genlist.dll: genlist.cs
	mcs -target:library -out:genlist.dll genlist.cs
clean:
	rm -f Out.txt main.exe genlist.dll
