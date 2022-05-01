linspline.png: Out.txt Makefile
	echo '\
	set terminal png\n\
	set output "linspline.png"\n\
	set xlabel "$$x$$"\n\
	set ylabel "$$y$$"\n\
	set tics out\n\
	set grid\n\
	plot [-0.5:20.5] [-1.5:1.5] "Out.txt" index 0 using 1:2 with points title"Tabulated sin(x)",\ \n\
	"Out.txt" index 0 using 1:3 with points pointtype 1 title "Tabulated -cos(x)",\ \n\
	"Out.txt" index 1 using 1:2 with lines title "Linear interpolation",\ \n\
	"Out.txt" index 1 using 1:3 with lines title "Integral: -cos(x)"\n\
	'| tee log | pyxplot


Out.txt: main.exe
	mono $< > Out.txt

main.exe: main.cs linspline.dll
	mcs $< -target:exe -reference:linspline.dll -out:$@

linspline.dll: linspline.cs
	mcs $< -target:library -out:$@
