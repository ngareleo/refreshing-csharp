# Matatu Problem

This is a custom problem I try to solve after learning a programming language. I try to build a state machine that includes:

1. A matatu (van)
2. A conductor
3. A person

The matatu problem should be a simulation of a real-life matatu

1. People randomly enter the matatu after intervals
2. When the matatu reaches a capacity, the conductor bangs the matatu
3. The driver accelerates the matatu until it reaches a stable speed
4. After sometime, the n number of people need to alight, they will alight
5. The conductor bangs the matatu
6. The matatu decelerates until it reaches zero
7. The people alight
8. The matatu waits until a certain time decided by (number of people left and a random number that decides the likelihood of people getting on) The conductor waits until certain time reaches, then bangs the matatu to go
9. The matatu accelerates back to stable speed
10. More people alight and some enter, but the matatu can never exceed its capacity.
11. The matatu will go a max of x turns before alighting.

All these requirements must be reached by the state machine I construct.
