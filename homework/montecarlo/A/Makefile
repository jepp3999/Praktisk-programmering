Out.txt: main.exe
	mono $< > $@

main.exe: main.cs montecarlo.dll vector.dll
	mcs $< -target:exe -reference:vector.dll,montecarlo.dll -out:$@

montecarlo.dll: montecarlo.cs vector.dll
	mcs $< -target:library -reference:vector.dll -out:$@	

MATHDIR = ~/repos/Praktisk-programmering/matlib
vector.dll: $(MATHDIR)/vector.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -r data.txt *.dll *.exe *.png