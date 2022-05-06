qspline.png: Out.txt Makefile
	echo '\
	set terminal png\n\
	set output "qspline.png"\n\
	set xlabel "$$x$$"\n\
	set ylabel "$$y$$"\n\
	set tics out\n\
	set grid\n\
	set nokey \n\
	plot "Out.txt" index 0 using 1:2 with points title"Tab. $$x^2$$/2",\ \n\
	"Out.txt" index 0 using 1:3 with points pointtype 1 title "Tab. $$x$$",\ \n\
	"Out.txt" index 1 using 1:2 with lines title "qIntPol: $$x^2$$/2",\ \n\
	"Out.txt" index 1 using 1:3 with lines title "qDeriv: $$x$$",\ \n\
	"Out.txt" index 0 using 1:4 with point pointtype 1 title "Tab. $$x^3$$/6",\ \n\
	"Out.txt" index 1 using 1:4 with lines title "qInteg: $$x^3$$/6"\ \n\
	'| tee log | pyxplot


Out.txt: main.exe
	mono $< > Out.txt

main.exe: main.cs qspline.dll
	mcs $< -target:exe -reference:qspline.dll -out:$@

qspline.dll: qspline.cs
	mcs $< -target:library -out:$@
clean:
	rm -r data.txt *.dll *.exe *.png
