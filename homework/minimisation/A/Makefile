Out.txt: main.exe
	mono $< > $@

main.exe: main.cs min.dll matrix.dll vector.dll
	mcs $< -target:exe -reference:min.dll,matrix.dll,vector.dll -out:$@

min.dll: min.cs matrix.dll vector.dll
	mcs $< -target:library -reference:matrix.dll,vector.dll -out:$@	

MATHDIR = ~/repos/Praktisk-programmering/matlib
matrix.dll: $(MATHDIR)/matrix.cs
	mcs -target:library -reference:vector.dll -out:./$@ $^

vector.dll: $(MATHDIR)/vector.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -r data.txt *.dll *.exe *.png