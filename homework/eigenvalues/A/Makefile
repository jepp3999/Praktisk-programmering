Out.txt: main.exe
	mono $< > $@

main.exe: main.cs matrix.dll eigenvalues.dll vector.dll
	mcs $< -target:exe -reference:matrix.dll,eigenvalues.dll -out:$@

eigenvalues.dll: eigenvalues.cs matrix.dll vector.dll
	mcs $< -target:library -reference:matrix.dll -out:$@	

MATHDIR = ~/repos/Praktisk-programmering/matlib
matrix.dll: $(MATHDIR)/matrix.cs $(MATHDIR)/vector.cs
	mcs -target:library -out:./$@ $^

vector.dll: $(MATHDIR)/vector.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -r data.txt *.dll *.exe *.png