Out.txt: hello.exe
	mono hello.exe > Out.txt

hello.exe: hello.cs
	mcs.hello.cs -target:exe -out:hell.exe

.PHONEY: clean
clean:
	rm -rf Out.txt hello.exe

test: 

