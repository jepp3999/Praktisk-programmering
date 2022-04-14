using System;
using static System.Console;


public class list<T>{
        public node<T> first=null,current=null;
        public void push(T item){
                if(first==null){
                        first=new node<T>(item);
                        current=first;
                }
                else{
                        current.next = new node<T>(item);
                        current=current.next;
                }
        }
        public void start(){ current=first; }
        public void next(){ current=current.next; }
}
public class main{
        public static void Main(){
                list<int> a = new list<int>();
                a.push(1);
                a.push(2);
                a.push(3);
                for( a.start(); a.current != null; a.next()){
                        WriteLine(a.current.item);
                } } }
