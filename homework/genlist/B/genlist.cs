using System;
using static System.Console;


public class genlist<T>{
	public T[] data;
	public int size=0,capacity=8;
	public genlist(){ data = new T[capacity]; }
	public void push(T item){
		if(size==capacity){
			T[] newdata = new T[capacity*=2];
			for(int i=0;i<size;i++)newdata[i]=data[i];
			data=newdata;
		}
		data[size]=item;
		size++;
	}
	public void remove(int i){
		T[] newdata = new T[capacity];
		if (i>size) Write($"Error: input greater than size of list\n");
		for(int j=0; j<i; j++){
			newdata[j] = data[j];
		}
		for(int j=i+1; j<size; j++){
			newdata[j-1] = data[j];
		}
	data=newdata;
	size--;
	}
}


