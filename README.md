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

L(v,&lambda) = v<sup>T</sup> A v - &lambda (v<sup>T</sup> v - 1)

Here lambda is the multiplier, and when we have minimized this equaiton, lambda will be equal to the eigenvalue and v will be the eigenvector of unit length. 
If we take the derivative of the Lagrangian w.r.t. the variables (v and &lambda) and set it equal to zero, we obtain the following equations to solve:

{Av-&lambda v <lambda> = 0, v<sup>T</sup>v-1=0}

We can put these into a function f, which will have dimension n+1, if v has dimension n.

The analytical Jacobian is then:

df<sub>i</sub>(x)/dv<sub>j</sub> = A<sub>ij</sub>-&lambda delta<sub>ij</sub>

df<sub>i</sub>(x)/d &lambda= -v<sub>i</sub>

df<sub>n+1</sub>(x)/d v<sub>j</sub> = 2v<sub>j</sub>

df<sub>n+i</sub>(x)/d &lambda= 0

We can use this analytical Jacobian in our roots-finding routine from the homework, instead of the numerical one.

Implementation


