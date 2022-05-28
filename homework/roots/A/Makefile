Out.txt: main.exe
	mono $< > $@

main.exe: main.cs roots.dll QRGS.dll matrix.dll vector.dll
	mcs $< -target:exe -reference:roots.dll,QRGS.dll,matrix.dll,vector.dll -out:$@

roots.dll: roots.cs QRGS.dll 
	mcs $< -target:library -reference:QRGS.dll,matrix.dll,vector.dll -out:$@	

MATHDIR = ~/repos/Praktisk-programmering/matlib
QRGS.dll: $(MATHDIR)/QRGS.cs
	mcs -target:library -reference:vector.dll,matrix.dll -out:./$@ $^

matrix.dll: $(MATHDIR)/matrix.cs
	mcs -target:library -reference:vector.dll -out:./$@ $^

vector.dll: $(MATHDIR)/vector.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -r data.txt *.dll *.exe *.png