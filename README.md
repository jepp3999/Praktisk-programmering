# Exam project 22: "Variational method with Lagrange multipliers".

### Author: Jeppe Surrow, Student ID: 201805168

My student ID is 201805168, thus I have the exam project 22. 
This project is the "Variational method with Lagrange multipliers".
Here we look at a real symmetric matrix, whose eigenvector and eigenvalue we would like to find.
We do that by considering the normal eigenvalue equation:
A v = E v, where A is the symmetric matrix, v is the eigenvector and E is the eigenvalue.
We put a constraint on the eigenvector and that is, that the eigenvector should have unit length.
We can then time the transposed vector from the left on both sides and obtain:

E = v<sup>T</sup> A v

To use the variational method without constraints, we subtract the constraint timed a Lagrange multiplier from the equation above.
This gives us a Lagrangian:

L(v,$\lambda$) = v<sup>T</sup> A v - $\lambda$ (v<sup>T</sup> v - 1)

Here lambda is the multiplier, and when we have minimized this equaiton, lambda will be equal to the eigenvalue and v will be the eigenvector of unit length. 
If we take the derivative of the Lagrangian w.r.t. the variables (v and $\lambda$) and set it equal to zero, we obtain the following equations to solve:

{Av-$\lambda$ v = 0, v<sup>T</sup>v-1=0}

We can put these into a function f, which will have dimension n+1, if v has dimension n.
The analytical Jacobian is then:

df<sub>i</sub>(x)/dv<sub>j</sub> = A<sub>ij</sub>-$\lambda$ delta<sub>ij</sub>, 

df<sub>i</sub>(x)/d $\lambda$= -v<sub>i</sub>,

df<sub>n+1</sub>(x)/d v<sub>j</sub> = 2v<sub>j</sub>,

df<sub>n+i</sub>(x)/d $\lambda$= 0

We can use this analytical Jacobian in our roots-finding routine from the homework, instead of the numerical one.

### Implementation

The first thing I did was to find the roots routine from the homework and alter it, by implementing the analytical Jacobian. This can be seen in:
    'lagrangeroots.cs'
Here I used the 1st equation from above, where I summed up over the different i's and j's stemming from the vector v. This gives the first n x n matrix. We have an n+1 x n+1, so we need the rest. This comes from the 2nd and 3rd equation, which gives the rows n+1 and the columns at n+1, except the point for (n+1,n+1) which is given by the last equation.

Then I altered the roots routine by making sure it includes two parameters, v and $\lambda$, who can be varied. We use Newton's method for this.
The roots routine include the QR Gram-Schmidt routine which I made in a homework. We use the analytical Jacobian in this and obtain a solution for the inital parameters. 
We add a small value dx and d $\lambda$ to v and $\lambda$, and see if this then minimize the function. If not we will solve the system with these new parameters and add some small values again.
This keeps going until the function is minimized.


I initially made a mistake here, where I didn't save the new value of $\lambda$. This resulted in the obvious error, that the loop kept running and I would never get a result.

I fixed the error by separating the routine into two. So instead of defining the function, which should be minimized, in the 'lagrangeroots.cs', I made a subroutine 'LMsearch.cs', where I define the function and make some initial guess on the eigenvector.
This helped localize the error, as I had to carefully set up the function. 

In the 'main.cs' file I have made a 5x5 symmetric matrix, and an initial guess of $\lambda$. This is plugged into the routine and it spits out the eigenvectors and eigenvalues, which approximately fullfill the conditions set upon them. That is, that they should solve the system, and fullfill the constraint on v.

### Evaluation: 6 points
I would consider myself to have fullfilled the minimum requirements to solve the exam problem. I have succesfully solved for the eigenvalue and eigenvector of a symmetric matrix using the variational method using Lagrange multipliers. 
I would have liked to have solved for the Hydrogen atom, but unfortunately there haven't been time for this. 
The reason for the 6 points evaluation is, that this is what the homeworks would grant for solving the first part.




