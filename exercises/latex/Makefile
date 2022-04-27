all:ms.pdf

ms.pdf: exp_function.tex exp.pyxplot.png
	pdflatex $<
	pdflatex $<
#	bibtex $<	# if multiple references
#	bibtex $<

exp.pyxplot.png: exp.data.txt Makefile
	echo '\
	set terminal png ;\
	set output "$@" ;\
	set xlabel "$$x$$" ;\
	set ylabel "$$y$$" ;\
	set tics out ;\
	set title "Exponential function" ;\
	set key left top ;\
	plot [-5:5] [-5:125] "$<" index 0 using 1:2 with points pointtype 3 title "Approximation ",\
	"$<" using 1:3 with lines title "Exp(x)" \
	'| tee log.pyx.gpi | pyxplot

exp.data.txt: main.exe
	mono $< > $@

main.exe: main.cs
	mcs -target:exe -out:$@ $<

clean:
	rm -f main.exe Out.txt

