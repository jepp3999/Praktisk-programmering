linspline.png: Out.txt Makefile
	echo '\
	set terminal png\n\
	set output "linspline.png"\n\
	set xlabel "$$x$$"\n\
	set ylabel "$$y$$"\n\
	set tics out\n\
	set grid\n\
	set key top left \n\
	plot [0:10.5] [0:51] "Out.txt" index 0 using 1:2 with points title"Tab. x",\ \n\
	"Out.txt" index 0 using 1:3 with points pointtype 1 title "Tab. $$x^2/2$$",\ \n\
	"Out.txt" index 1 using 1:2 with lines title "LinInterp: x",\ \n\
	"Out.txt" index 1 using 1:3 with lines title "LinInteg: $$x^2/2$$"\n\
	'| tee log | pyxplot


Out.txt: main.exe
	mono $< > Out.txt

main.exe: main.cs linspline.dll
	mcs $< -target:exe -reference:linspline.dll -out:$@

linspline.dll: linspline.cs
	mcs $< -target:library -out:$@
clean:
	rm -r data.txt *.dll *.exe *.png

