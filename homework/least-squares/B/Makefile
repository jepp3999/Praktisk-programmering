ls.pyxplot.png: Out.txt Makefile
	echo '\
	set terminal png ;\
	set output "$@" ;\
	set xlabel "$$x$$" ;\
	set ylabel "$$log(y)$$" ;\
	set title "Activity" ;\
	set ticks out ;\
	set key right;\
	plot "Out.txt" index 1 using 1:2:3 with errorbars title "Data",\ \n\
	"Out.txt" index 3 using 1:2 with lines title "Fitted function"\
	'| tee log.gpi | pyxplot

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs matrix.dll QRGS.dll vector.dll leastsquares.dll
	mcs $< -target:exe -reference:matrix.dll,QRGS.dll,leastsquares.dll -out:$@

leastsquares.dll: leastsquares.cs matrix.dll QRGS.dll
	mcs $< -target:library -reference:matrix.dll,QRGS.dll -out:$@	

MATHDIR = ~/repos/Praktisk-programmering/matlib
QRGS.dll:  $(MATHDIR)/QRGS.cs matrix.dll
	mcs -target:library -reference:matrix.dll -out:./$@ $<
	
matrix.dll: $(MATHDIR)/matrix.cs $(MATHDIR)/vector.cs
	mcs -target:library -out:./$@ $^

vector.dll: $(MATHDIR)/vector.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -r data.txt *.dll *.exe *.png